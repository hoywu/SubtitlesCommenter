using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SubtitlesCommenter.Bean;
using SubtitlesCommenter.Utils;

namespace SubtitlesCommenter
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            SetMainFormTitle();
            HideAdvOptions();
            SetBetterFont();
        }

        /// <summary>
        /// 尝试为UI元素设置更美观的字体
        /// </summary>
        private void SetBetterFont()
        {
            String[] fontNameList = { "Sarasa Fixed SC", "微软雅黑" };
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
        /// 在主窗口标题最后面添加版本号
        /// </summary>
        private void SetMainFormTitle()
        {
            Text += " " + Constants.VERSION;
        }
        /// <summary>
        /// 修改主窗口大小隐藏高级选项
        /// </summary>
        private void HideAdvOptions()
        {
            ClientSize = new Size(573, 349);
        }
        /// <summary>
        /// 修改主窗口大小显示高级选项
        /// </summary>
        private void ShowAdvOptions()
        {
            ClientSize = new Size(573, 458);
        }

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
    }
}
