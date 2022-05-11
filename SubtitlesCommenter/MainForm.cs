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

            String[] fontNameList = { "Sarasa Fixed SC", "΢���ź�", "����" };
            SetBetterFont(fontNameList);
            AddToMainFormTitle(Constants.VERSION);
            HideAdvOptions();
        }
        /// <summary>
        /// ���ѡ����Ļ�ļ���ť��ѡ���ļ���newһ���µ�MyTask����
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
        /// ������밴ť
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
                    //����ģʽ����Ƿ��й�������
                    if (singleLineRadioButton.Checked)
                    {
                        int lineNumber = MainFormUtils.CheckOverLengthLine(contentTextBox.Text, showTimeTextBox.Text);
                        if (lineNumber != 0)
                        {
                            MessageBoxButtons boxButtons = MessageBoxButtons.OKCancel;
                            DialogResult result = MessageBox.Show(MainFormConstants.NOTICE_MESSAGE_LINETOOLONG + "\n�кţ�" + lineNumber, "������Ļ", boxButtons);
                            if (result == DialogResult.Cancel) return;
                        }
                    }

                    //ִ�в���
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
        /// ���ݴ��������õ����ݹ���DTO����
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

                //����Ӧ����ʱ��
                if (autoShowTimeCheckBox.Checked)
                {
                    retObj.autoShowTime = true;
                }

                // �߼�ѡ��
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

                //���Ч��
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
                // ��Ӧִ�е��˴�
                throw new Exception(Constants.ERROR_MESSAGE_PROGRAMING_ERROR);
            }
        }


        #region �޸�UI��ط���
        /// <summary>
        /// ����ΪUIԪ�����ø����۵�����
        /// </summary>
        /// <param name="fontNameList">��������ȫ����String����</param>
        private void SetBetterFont(String[] fontNameList)
        {
            Font? font = MainFormUtils.GetExistingFont(fontNameList);
            if (font == null)
            {
                return;
            }
            // ���÷��佫this����������namespaceΪSystem.Windows.Forms���ֶε�Font��������Ϊfont
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
        /// �������ڱ���������ָ���ı�
        /// </summary>
        private void AddToMainFormTitle(String s)
        {
            Text += " " + s;
        }
        /// <summary>
        /// ��ʾ/���ظ߼�ѡ��
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
        /// �޸������ڴ�С���ظ߼�ѡ��
        /// </summary>
        private void HideAdvOptions()
        {
            ClientSize = new Size(ClientSize.Width, ClientSize.Height - (int)(advGroupBox.Size.Height * 1.16));
        }
        /// <summary>
        /// �޸������ڴ�С��ʾ�߼�ѡ��
        /// </summary>
        private void ShowAdvOptions()
        {
            ClientSize = new Size(ClientSize.Width, ClientSize.Height + (int)(advGroupBox.Size.Height * 1.16));
        }
        /// <summary>
        /// �����ʽѡ��������
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
