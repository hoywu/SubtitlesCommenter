using SubtitlesCommenter.Bean;
using SubtitlesCommenter.Utils;
using System;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace SubtitlesCommenter
{
    public partial class MainForm : Form
    {
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
        private void openSubFileButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "选择字幕文件";
            openFileDialog.Filter = "ASS Subtitles File|*.ass";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                subFileNameTextBox.Text = System.IO.Path.GetFullPath(openFileDialog.FileName);
            }
        }
        /// <summary>
        /// 显示/隐藏高级选项
        /// </summary>
        private void advCheckBox_CheckedChanged(object sender, EventArgs e)
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

        #region 供调用的方法
        /// <summary>
        /// 尝试为UI元素设置更美观的字体
        /// </summary>
        /// <param name="fontNameList">包含字体全名的String数组</param>
        private void SetBetterFont(String[] fontNameList)
        {
            Font font = MainFormUtils.GetExistingFont(fontNameList);
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
        /// 修改主窗口大小隐藏高级选项
        /// </summary>
        private void HideAdvOptions()
        {
            ClientSize = new Size(Constants.MAIN_FORM_WIDTH, Constants.MAIN_FORM_HEIGHT_HIDE_ADV);
        }
        /// <summary>
        /// 修改主窗口大小显示高级选项
        /// </summary>
        private void ShowAdvOptions()
        {
            ClientSize = new Size(Constants.MAIN_FORM_WIDTH, Constants.MAIN_FORM_HEIGHT_SHOW_ADV);
        }
        #endregion
    }
}
