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
        // ѡ���ļ����ж��ļ��������ڴ�
        private Encoding SubtitlesFileEncoding;
        // ����Ļ�ļ�������Ļ�ļ��е�������ʽ
        private SubtitlesStyleBase[] StyleArray;

        public MainForm()
        {
            InitializeComponent();

            String[] fontNameList = { "Sarasa Fixed SC", "΢���ź�", "����" };
            SetBetterFont(fontNameList);
            AddToMainFormTitle(Constants.VERSION);
            HideAdvOptions();
        }
        /// <summary>
        /// ���ѡ����Ļ�ļ���ť
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
                    // ������ʾ��FillStyleComboBox�����
                    return;
                }
                subFileNameTextBox.Text = Path.GetFullPath(openFileDialog.FileName);
                styleComboBox.SelectedIndex = 0;
            }
        }
        /// <summary>
        /// ��ȡ��Ļ�ļ������ʽѡ�������򣬴���this.StyleArray�������쳣����MessageBox��ʾ�û�������false
        /// </summary>
        private bool FillStyleComboBox(string SubtitlesFilePath)
        {
            SubtitlesStyleBase[] styles;
            #region ȡ����Ļ�ļ���������ʽ����ŵ�styles���飬�����쳣����ʾ�û�
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
            // ���鳤�Ȳ���Ϊ0��GetSubtitlesStyles�����ѵ���GetStyleNumber�������ʽ����
            for (int i = 0; i < styles.Length; i++)
            {
                styleComboBox.Items.Add(styles[i].Name);
            }
            this.StyleArray = styles;
            return true;
        }


        /// <summary>
        /// ������밴ť
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
        /// ���ݴ��������õ����ݹ���DTO����
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
            ClientSize = new Size(MainFormConstants.MAIN_FORM_WIDTH, MainFormConstants.MAIN_FORM_HEIGHT_HIDE_ADV);
        }
        /// <summary>
        /// �޸������ڴ�С��ʾ�߼�ѡ��
        /// </summary>
        private void ShowAdvOptions()
        {
            ClientSize = new Size(MainFormConstants.MAIN_FORM_WIDTH, MainFormConstants.MAIN_FORM_HEIGHT_SHOW_ADV);
        }
        #endregion
    }
}
