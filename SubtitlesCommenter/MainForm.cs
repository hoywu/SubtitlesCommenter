using SubtitlesCommenter.Bean;
using SubtitlesCommenter.CustomException;
using SubtitlesCommenter.Modules;
using SubtitlesCommenter.Utils;
using System.Reflection;
using System.Text;

namespace SubtitlesCommenter
{
    public partial class MainForm : Form
    {
        // 选择文件后判断文件编码存放在此
        private Encoding SubtitlesFileEncoding;
        // 打开字幕文件后存放字幕文件中的所有样式
        private SubtitlesStyleBase[] StyleArray;

        public MainForm()
        {
            InitializeComponent();

            String[] fontNameList = { "Sarasa Fixed SC", "微软雅黑", "黑体" };
            SetBetterFont(fontNameList);
            AddToMainFormTitle(Constants.VERSION);
            HideAdvOptions();
        }
        /// <summary>
        /// 点击选择字幕文件按钮
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
                    this.SubtitlesFileEncoding = WriteSubtitlesFileUtils.GetFileEncoding(openFileDialog.FileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(MainFormConstants.ERROR_MESSAGE_UNKNOWN_ENCODING + "\n" + ex.Message, MainFormConstants.ERROR_MESSAGE_TITLE);
                    return;
                }
                if (!FillStyleComboBox(openFileDialog.FileName))
                {
                    // 错误提示在FillStyleComboBox中完成
                    return;
                }
                subFileNameTextBox.Text = Path.GetFullPath(openFileDialog.FileName);
                styleComboBox.SelectedIndex = 0;
            }
        }
        /// <summary>
        /// 读取字幕文件填充样式选择下拉框，存入this.StyleArray，捕获到异常则以MessageBox提示用户并返回false
        /// </summary>
        private bool FillStyleComboBox(string SubtitlesFilePath)
        {
            SubtitlesStyleBase[] styles;
            #region 取出字幕文件中所有样式，存放到styles数组，捕获异常并提示用户
            try
            {
                styles = ReadSubtitlesFile.GetSubtitlesStyles(SubtitlesFilePath, this.SubtitlesFileEncoding);
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show(MainFormConstants.ERROR_MESSAGE_FILE_NOT_FOUND, MainFormConstants.ERROR_MESSAGE_TITLE);
                return false;
            }
            catch (IOException e)
            {
                MessageBox.Show(MainFormConstants.ERROR_MESSAGE_FILE_READ_FAILURE + "\n" + e.Message, MainFormConstants.ERROR_MESSAGE_TITLE);
                return false;
            }
            catch (EmptyFileException)
            {
                MessageBox.Show(MainFormConstants.ERROR_MESSAGE_EMPTY_FILE, MainFormConstants.ERROR_MESSAGE_TITLE);
                return false;
            }
            catch (UnknownStyleException e)
            {
                MessageBox.Show(MainFormConstants.ERROR_MESSAGE_UNKNOWN_STYLE + "\n" + e.Message, MainFormConstants.ERROR_MESSAGE_TITLE);
                return false;
            }
            catch (Exception e)
            {
                MessageBox.Show(MainFormConstants.ERROR_MESSAGE_UNKNOWN_ERROR + "\n" + e.Message, MainFormConstants.ERROR_MESSAGE_TITLE);
                return false;
            }
            #endregion

            styleComboBox.Items.Clear();
            // 数组长度不会为0，GetSubtitlesStyles方法已调用GetStyleNumber检查了样式数量
            for (int i = 0; i < styles.Length; i++)
            {
                styleComboBox.Items.Add(styles[i].Name);
            }
            this.StyleArray = styles;
            return true;
        }


        /// <summary>
        /// 点击插入按钮
        /// </summary>
        private void DoneButton_Click(object sender, EventArgs e)
        {
            doneButton.Enabled = false;
            try
            {
                if (styleComboBox.SelectedIndex == -1 || StyleArray == null)
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
                    WriteSubtitlesFile.SaveToSubtitlesFile(BuildAddContentConfig());
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
            if (Constants.STYLE_FORMAT_V4P.Equals(StyleArray[0].SubtitlesStyleFormat))
            {
                AddContentConfigV4PDTO retObj = new();
                retObj.SubtitlesStyleFormat = Constants.STYLE_FORMAT_V4P;
                retObj.Encoding = this.SubtitlesFileEncoding;
                retObj.FilePath = subFileNameTextBox.Text;
                retObj.AddMode = singleLineRadioButton.Checked ? Constants.ADD_MODE_SINGLE_LINE : Constants.ADD_MODE_MULTI_LINE;
                retObj.AddLocation = commLocTextBox.Text;
                retObj.ShowTime = showTimeTextBox.Text;
                retObj.StyleName = StyleArray[styleComboBox.SelectedIndex].Name;
                retObj.Text = contentTextBox.Text;
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
            ClientSize = new Size(MainFormConstants.MAIN_FORM_WIDTH, MainFormConstants.MAIN_FORM_HEIGHT_HIDE_ADV);
        }
        /// <summary>
        /// 修改主窗口大小显示高级选项
        /// </summary>
        private void ShowAdvOptions()
        {
            ClientSize = new Size(MainFormConstants.MAIN_FORM_WIDTH, MainFormConstants.MAIN_FORM_HEIGHT_SHOW_ADV);
        }
        #endregion
    }
}
