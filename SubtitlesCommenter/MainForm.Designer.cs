namespace SubtitlesCommenter
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.label1 = new System.Windows.Forms.Label();
            this.subFileNameTextBox = new System.Windows.Forms.TextBox();
            this.openSubFileButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.commLocTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.showTimeTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.contentTextBox = new System.Windows.Forms.TextBox();
            this.singleLineRadioButton = new System.Windows.Forms.RadioButton();
            this.multiLineRadioButton = new System.Windows.Forms.RadioButton();
            this.doneButton = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.styleComboBox = new System.Windows.Forms.ComboBox();
            this.advCheckBox = new System.Windows.Forms.CheckBox();
            this.advGroupBox = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.customTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.customCheckBox = new System.Windows.Forms.CheckBox();
            this.alphaTextBox = new System.Windows.Forms.TextBox();
            this.alphaCheckBox = new System.Windows.Forms.CheckBox();
            this.fadMsLabe = new System.Windows.Forms.Label();
            this.fadMsTextBox = new System.Windows.Forms.TextBox();
            this.fadCheckBox = new System.Windows.Forms.CheckBox();
            this.advGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 14);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "字幕文件：";
            // 
            // subFileNameTextBox
            // 
            this.subFileNameTextBox.Enabled = false;
            this.subFileNameTextBox.Location = new System.Drawing.Point(89, 11);
            this.subFileNameTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.subFileNameTextBox.Name = "subFileNameTextBox";
            this.subFileNameTextBox.Size = new System.Drawing.Size(467, 23);
            this.subFileNameTextBox.TabIndex = 1;
            // 
            // openSubFileButton
            // 
            this.openSubFileButton.Location = new System.Drawing.Point(564, 8);
            this.openSubFileButton.Margin = new System.Windows.Forms.Padding(4);
            this.openSubFileButton.Name = "openSubFileButton";
            this.openSubFileButton.Size = new System.Drawing.Size(88, 29);
            this.openSubFileButton.TabIndex = 2;
            this.openSubFileButton.Text = "浏览";
            this.openSubFileButton.UseVisualStyleBackColor = true;
            this.openSubFileButton.Click += new System.EventHandler(this.OpenSubFileButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 44);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "注释添加位置：";
            // 
            // commLocTextBox
            // 
            this.commLocTextBox.Location = new System.Drawing.Point(113, 41);
            this.commLocTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.commLocTextBox.Name = "commLocTextBox";
            this.commLocTextBox.Size = new System.Drawing.Size(116, 23);
            this.commLocTextBox.TabIndex = 4;
            this.commLocTextBox.Text = "0:00:00.00";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(281, 44);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(145, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "每行/整段显示持续时间：";
            // 
            // showTimeTextBox
            // 
            this.showTimeTextBox.Location = new System.Drawing.Point(434, 41);
            this.showTimeTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.showTimeTextBox.Name = "showTimeTextBox";
            this.showTimeTextBox.Size = new System.Drawing.Size(122, 23);
            this.showTimeTextBox.TabIndex = 6;
            this.showTimeTextBox.Text = "0:00:05.00";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 74);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 17);
            this.label4.TabIndex = 7;
            this.label4.Text = "注释内容：";
            // 
            // contentTextBox
            // 
            this.contentTextBox.AcceptsTab = true;
            this.contentTextBox.AllowDrop = true;
            this.contentTextBox.Location = new System.Drawing.Point(13, 95);
            this.contentTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.contentTextBox.Multiline = true;
            this.contentTextBox.Name = "contentTextBox";
            this.contentTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.contentTextBox.Size = new System.Drawing.Size(639, 238);
            this.contentTextBox.TabIndex = 8;
            this.contentTextBox.WordWrap = false;
            // 
            // singleLineRadioButton
            // 
            this.singleLineRadioButton.AutoSize = true;
            this.singleLineRadioButton.Checked = true;
            this.singleLineRadioButton.Location = new System.Drawing.Point(370, 344);
            this.singleLineRadioButton.Margin = new System.Windows.Forms.Padding(4);
            this.singleLineRadioButton.Name = "singleLineRadioButton";
            this.singleLineRadioButton.Size = new System.Drawing.Size(74, 21);
            this.singleLineRadioButton.TabIndex = 9;
            this.singleLineRadioButton.TabStop = true;
            this.singleLineRadioButton.Text = "单行显示";
            this.singleLineRadioButton.UseVisualStyleBackColor = true;
            // 
            // multiLineRadioButton
            // 
            this.multiLineRadioButton.AutoSize = true;
            this.multiLineRadioButton.Location = new System.Drawing.Point(370, 368);
            this.multiLineRadioButton.Margin = new System.Windows.Forms.Padding(4);
            this.multiLineRadioButton.Name = "multiLineRadioButton";
            this.multiLineRadioButton.Size = new System.Drawing.Size(74, 21);
            this.multiLineRadioButton.TabIndex = 10;
            this.multiLineRadioButton.Text = "整段显示";
            this.multiLineRadioButton.UseVisualStyleBackColor = true;
            // 
            // doneButton
            // 
            this.doneButton.Location = new System.Drawing.Point(452, 341);
            this.doneButton.Margin = new System.Windows.Forms.Padding(4);
            this.doneButton.Name = "doneButton";
            this.doneButton.Size = new System.Drawing.Size(200, 51);
            this.doneButton.TabIndex = 11;
            this.doneButton.Text = "插入字幕";
            this.doneButton.UseVisualStyleBackColor = true;
            this.doneButton.Click += new System.EventHandler(this.DoneButton_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 344);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 17);
            this.label5.TabIndex = 12;
            this.label5.Text = "注释样式：";
            // 
            // styleComboBox
            // 
            this.styleComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.styleComboBox.FormattingEnabled = true;
            this.styleComboBox.Location = new System.Drawing.Point(89, 341);
            this.styleComboBox.Margin = new System.Windows.Forms.Padding(4);
            this.styleComboBox.Name = "styleComboBox";
            this.styleComboBox.Size = new System.Drawing.Size(177, 25);
            this.styleComboBox.TabIndex = 13;
            // 
            // advCheckBox
            // 
            this.advCheckBox.AutoSize = true;
            this.advCheckBox.Location = new System.Drawing.Point(16, 371);
            this.advCheckBox.Margin = new System.Windows.Forms.Padding(4);
            this.advCheckBox.Name = "advCheckBox";
            this.advCheckBox.Size = new System.Drawing.Size(207, 21);
            this.advCheckBox.TabIndex = 14;
            this.advCheckBox.Text = "显示高级选项 [增加其他特效代码]";
            this.advCheckBox.UseVisualStyleBackColor = true;
            this.advCheckBox.CheckedChanged += new System.EventHandler(this.AdvCheckBox_CheckedChanged);
            // 
            // advGroupBox
            // 
            this.advGroupBox.Controls.Add(this.label7);
            this.advGroupBox.Controls.Add(this.customTextBox);
            this.advGroupBox.Controls.Add(this.label6);
            this.advGroupBox.Controls.Add(this.customCheckBox);
            this.advGroupBox.Controls.Add(this.alphaTextBox);
            this.advGroupBox.Controls.Add(this.alphaCheckBox);
            this.advGroupBox.Controls.Add(this.fadMsLabe);
            this.advGroupBox.Controls.Add(this.fadMsTextBox);
            this.advGroupBox.Controls.Add(this.fadCheckBox);
            this.advGroupBox.Location = new System.Drawing.Point(16, 405);
            this.advGroupBox.Name = "advGroupBox";
            this.advGroupBox.Size = new System.Drawing.Size(636, 83);
            this.advGroupBox.TabIndex = 16;
            this.advGroupBox.TabStop = false;
            this.advGroupBox.Text = "高级";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(431, 52);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(12, 17);
            this.label7.TabIndex = 24;
            this.label7.Text = "}";
            // 
            // customTextBox
            // 
            this.customTextBox.Enabled = false;
            this.customTextBox.Location = new System.Drawing.Point(278, 49);
            this.customTextBox.Name = "customTextBox";
            this.customTextBox.Size = new System.Drawing.Size(150, 23);
            this.customTextBox.TabIndex = 23;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(265, 52);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(12, 17);
            this.label6.TabIndex = 22;
            this.label6.Text = "{";
            // 
            // customCheckBox
            // 
            this.customCheckBox.AutoSize = true;
            this.customCheckBox.Location = new System.Drawing.Point(161, 51);
            this.customCheckBox.Name = "customCheckBox";
            this.customCheckBox.Size = new System.Drawing.Size(111, 21);
            this.customCheckBox.TabIndex = 21;
            this.customCheckBox.Text = "自定义特效标签";
            this.customCheckBox.UseVisualStyleBackColor = true;
            this.customCheckBox.CheckedChanged += new System.EventHandler(this.CustomCheckBox_CheckedChanged);
            // 
            // alphaTextBox
            // 
            this.alphaTextBox.Enabled = false;
            this.alphaTextBox.Location = new System.Drawing.Point(70, 49);
            this.alphaTextBox.Name = "alphaTextBox";
            this.alphaTextBox.Size = new System.Drawing.Size(54, 23);
            this.alphaTextBox.TabIndex = 20;
            this.alphaTextBox.Text = "0~255";
            // 
            // alphaCheckBox
            // 
            this.alphaCheckBox.AutoSize = true;
            this.alphaCheckBox.Location = new System.Drawing.Point(9, 51);
            this.alphaCheckBox.Margin = new System.Windows.Forms.Padding(4);
            this.alphaCheckBox.Name = "alphaCheckBox";
            this.alphaCheckBox.Size = new System.Drawing.Size(63, 21);
            this.alphaCheckBox.TabIndex = 19;
            this.alphaCheckBox.Text = "透明度";
            this.alphaCheckBox.UseVisualStyleBackColor = true;
            this.alphaCheckBox.CheckedChanged += new System.EventHandler(this.AlphaCheckBox_CheckedChanged);
            // 
            // fadMsLabe
            // 
            this.fadMsLabe.AutoSize = true;
            this.fadMsLabe.Location = new System.Drawing.Point(125, 24);
            this.fadMsLabe.Name = "fadMsLabe";
            this.fadMsLabe.Size = new System.Drawing.Size(25, 17);
            this.fadMsLabe.TabIndex = 18;
            this.fadMsLabe.Text = "ms";
            // 
            // fadMsTextBox
            // 
            this.fadMsTextBox.Enabled = false;
            this.fadMsTextBox.Location = new System.Drawing.Point(82, 21);
            this.fadMsTextBox.Name = "fadMsTextBox";
            this.fadMsTextBox.Size = new System.Drawing.Size(42, 23);
            this.fadMsTextBox.TabIndex = 17;
            this.fadMsTextBox.Text = "200";
            // 
            // fadCheckBox
            // 
            this.fadCheckBox.AutoSize = true;
            this.fadCheckBox.Location = new System.Drawing.Point(9, 23);
            this.fadCheckBox.Margin = new System.Windows.Forms.Padding(4);
            this.fadCheckBox.Name = "fadCheckBox";
            this.fadCheckBox.Size = new System.Drawing.Size(75, 21);
            this.fadCheckBox.TabIndex = 16;
            this.fadCheckBox.Text = "渐出渐入";
            this.fadCheckBox.UseVisualStyleBackColor = true;
            this.fadCheckBox.CheckedChanged += new System.EventHandler(this.FadCheckBox_CheckedChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(665, 500);
            this.Controls.Add(this.advGroupBox);
            this.Controls.Add(this.advCheckBox);
            this.Controls.Add(this.styleComboBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.doneButton);
            this.Controls.Add(this.multiLineRadioButton);
            this.Controls.Add(this.singleLineRadioButton);
            this.Controls.Add(this.contentTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.showTimeTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.commLocTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.openSubFileButton);
            this.Controls.Add(this.subFileNameTextBox);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "注释字幕添加器";
            this.advGroupBox.ResumeLayout(false);
            this.advGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private TextBox subFileNameTextBox;
        private Button openSubFileButton;
        private Label label2;
        private TextBox commLocTextBox;
        private Label label3;
        private TextBox showTimeTextBox;
        private Label label4;
        private TextBox contentTextBox;
        private RadioButton singleLineRadioButton;
        private RadioButton multiLineRadioButton;
        private Button doneButton;
        private Label label5;
        private ComboBox styleComboBox;
        private CheckBox advCheckBox;
        private GroupBox advGroupBox;
        private CheckBox fadCheckBox;
        private Label fadMsLabe;
        private TextBox fadMsTextBox;
        private TextBox alphaTextBox;
        private CheckBox alphaCheckBox;
        private Label label7;
        private TextBox customTextBox;
        private Label label6;
        private CheckBox customCheckBox;
    }
}