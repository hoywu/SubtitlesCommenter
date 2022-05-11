using SubtitlesCommenter.Bean;
using SubtitlesCommenter.Enum;
using SubtitlesCommenter.Utils;
using System.Reflection;

namespace SubtitlesCommenter
{
    public partial class MainForm : Form
    {
        private MyTask task;

        public MainForm()
        {
            InitializeComponent();

            String[] fontNameList = { "Sarasa Fixed SC", "微软雅黑", "黑体" };
            SetBetterFont(fontNameList);
            AddToMainFormTitle(Constants.VERSION);
            HideAdvOptions();
        }
        /// <summary>
        /// 点击选择字幕文件按钮，选择文件后new一个新的MyTask对象
        /// </summary>
        private void OpenSubFileButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new();
            openFileDialog.Title = MainFormConstants.OPEN_FILE_DIALOG_TITLE;
            openFileDialog.Filter = MainFormConstants.OPEN_FILE_DIALOG_FILTER;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    task = new MyTask(Path.GetFullPath(openFileDialog.FileName));
                }
                catch (Exception ex)
                {
                    MessageBox.Show(MainFormConstants.ERROR_MESSAGE_FILE_READ_FAILURE + "\n" + ex.Message, MainFormConstants.ERROR_MESSAGE_TITLE);
                    return;
                }
                FillStyleComboBox(task.StyleArray);
                subFileNameTextBox.Text = task.FilePath;
                styleComboBox.SelectedIndex = 0;
            }
        }


        /// <summary>
        /// 点击插入按钮
        /// </summary>
        private void DoneButton_Click(object sender, EventArgs e)
        {
            doneButton.Enabled = false;
            try
            {
                if (styleComboBox.SelectedIndex == -1 || task == null)
                {
                    MessageBox.Show(MainFormConstants.ERROR_MESSAGE_NO_STYLE_SELECTED, MainFormConstants.ERROR_MESSAGE_TITLE);
                    return;
                }
                if (string.IsNullOrEmpty(contentTextBox.Text.Replace("\n", "").Replace("\r", "")))
                {
                    MessageBox.Show(MainFormConstants.ERROR_MESSAGE_EMPTY_CONTENT, MainFormConstants.ERROR_MESSAGE_TITLE);
                    return;
                }

                try
                {
                    //单行模式检查是否有过长的行
                    if (singleLineRadioButton.Checked)
                    {
                        int lineNumber = MainFormUtils.CheckOverLengthLine(contentTextBox.Text, showTimeTextBox.Text);
                        if (lineNumber != 0)
                        {
                            MessageBoxButtons boxButtons = MessageBoxButtons.OKCancel;
                            DialogResult result = MessageBox.Show(MainFormConstants.NOTICE_MESSAGE_LINETOOLONG + "\n行号：" + lineNumber, "插入字幕", boxButtons);
                            if (result == DialogResult.Cancel) return;
                        }
                    }

                    //执行插入
                    task.WriteContant(BuildAddContentConfig());
                }
                catch (Exception ex)
                {
                    MessageBox.Show(MainFormConstants.ERROR_MESSAGE_ADD_FAILURE + "\n" + ex.Message, MainFormConstants.ERROR_MESSAGE_TITLE);
                    return;
                }
                MessageBox.Show(MainFormConstants.NOTICE_MESSAGE_SUCCEED, MainFormConstants.NOTICE_MESSAGE_TITLE);
            }
            finally
            {
                doneButton.Enabled = true;
            }
        }

        /// <summary>
        /// 根据窗口中设置的内容构造DTO对象
        /// </summary>
        private AddContentConfigBaseDTO BuildAddContentConfig()
        {
            if (task.StyleStandard == StyleStandardEnum.V4P)
            {
                AddContentConfigV4PDTO retObj = new();
                retObj.AddMode = singleLineRadioButton.Checked ? AddModeEnum.SINGLE_LINE : AddModeEnum.MULTI_LINE;
                retObj.AddLocation = commLocTextBox.Text;
                retObj.ShowTime = showTimeTextBox.Text;
                retObj.Style = task.StyleArray[styleComboBox.SelectedIndex];
                retObj.Text = contentTextBox.Text;

                //自适应持续时间
                if (autoShowTimeCheckBox.Checked)
                {
                    retObj.autoShowTime = true;
                }

                // 高级选项
                if (advCheckBox.Checked)
                {
                    retObj.AdvOption = true;
                    retObj.fad = fadCheckBox.Checked ? int.Parse(fadMsTextBox.Text) : 0;
                    retObj.alpha = alphaCheckBox.Checked ? int.Parse(alphaTextBox.Text) : 0;
                    retObj.italics = italicsCheckBox.Checked ? 1 : 0;
                    retObj.boldface = boldfaceCheckBox.Checked ? 1 : 0;
                    retObj.underlined = underlinedCheckBox.Checked ? 1 : 0;
                    retObj.strikeout = strikeoutCheckBox.Checked ? 1 : 0;
                    retObj.custom = customCheckBox.Checked ? customTextBox.Text : string.Empty;
                }
                else
                {
                    retObj.AdvOption = false;
                }

                //横幅效果
                if (bannerCheckBox.Checked)
                {
                    retObj.banner = true;
                    retObj.bannerSpeed = int.Parse(bannerSpeedTextBox.Text);
                    retObj.bannerDirection = bannerDir0RadioButton.Checked ? 0 : 1;
                }
                else
                {
                    retObj.banner = false;
                }

                return retObj;
            }
            else
            {
                // 不应执行到此处
                throw new Exception(Constants.ERROR_MESSAGE_PROGRAMING_ERROR);
            }
        }


        #region 修改UI相关方法
        /// <summary>
        /// 尝试为UI元素设置更美观的字体
        /// </summary>
        /// <param name="fontNameList">包含字体全名的String数组</param>
        private void SetBetterFont(String[] fontNameList)
        {
            Font? font = MainFormUtils.GetExistingFont(fontNameList);
            if (font == null)
            {
                return;
            }
            // 利用反射将this中所有类型namespace为System.Windows.Forms的字段的Font属性设置为font
            Type type = this.GetType();
            FieldInfo[] fieldInfos = type.GetFields(BindingFlags.NonPublic | BindingFlags.Instance);
            foreach (FieldInfo fieldInfo in fieldInfos)
            {
                Type fieldType = fieldInfo.FieldType;
                if (fieldType.Namespace == "System.Windows.Forms")
                {
                    try
                    {
                        PropertyInfo propertyInfo = fieldType.GetProperty("Font");
                        Object obj = fieldInfo.GetValue(this);
                        propertyInfo.SetValue(obj, font);
                    }
                    catch (Exception) { }
                }
            }
        }

        /// <summary>
        /// 在主窗口标题最后添加指定文本
        /// </summary>
        private void AddToMainFormTitle(String s)
        {
            Text += " " + s;
        }
        /// <summary>
        /// 显示/隐藏高级选项
        /// </summary>
        private void AdvCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (advCheckBox.Checked)
            {
                ShowAdvOptions();
            }
            else
            {
                HideAdvOptions();
            }
        }
        /// <summary>
        /// 修改主窗口大小隐藏高级选项
        /// </summary>
        private void HideAdvOptions()
        {
            ClientSize = new Size(ClientSize.Width, ClientSize.Height - (int)(advGroupBox.Size.Height * 1.16));
        }
        /// <summary>
        /// 修改主窗口大小显示高级选项
        /// </summary>
        private void ShowAdvOptions()
        {
            ClientSize = new Size(ClientSize.Width, ClientSize.Height + (int)(advGroupBox.Size.Height * 1.16));
        }
        /// <summary>
        /// 填充样式选择下拉框
        /// </summary>
        private void FillStyleComboBox(SubtitlesStyleBase[] styles)
        {
            styleComboBox.Items.Clear();
            for (int i = 0; i < styles.Length; i++)
            {
                styleComboBox.Items.Add(styles[i].Name);
            }
        }

        private void FadCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (fadCheckBox.Checked)
            {
                fadMsTextBox.Enabled = true;
            }
            else
            {
                fadMsTextBox.Enabled = false;
            }
        }
        private void AlphaCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (alphaCheckBox.Checked)
            {
                if ("0~255".Equals(alphaTextBox.Text))
                {
                    alphaTextBox.Clear();
                }
                alphaTextBox.Enabled = true;
            }
            else
            {
                if ("".Equals(alphaTextBox.Text))
                {
                    alphaTextBox.Text = "0~255";
                }
                alphaTextBox.Enabled = false;
            }
        }
        private void CustomCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (customCheckBox.Checked)
            {
                customTextBox.Enabled = true;
            }
            else
            {
                customTextBox.Enabled = false;
            }
        }
        private void BannerCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (bannerCheckBox.Checked)
            {
                bannerSpeedTextBox.Enabled = true;
                bannerDir0RadioButton.Enabled = true;
                bannerDir1RadioButton.Enabled = true;
            }
            else
            {
                bannerSpeedTextBox.Enabled = false;
                bannerDir0RadioButton.Enabled = false;
                bannerDir1RadioButton.Enabled = false;
            }
        }
        private void AutoShowTimeCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (autoShowTimeCheckBox.Checked)
            {
                showTimeTextBox.Enabled = false;
            }
            else
            {
                showTimeTextBox.Enabled = true;
            }
        }
        #endregion

    }
}
