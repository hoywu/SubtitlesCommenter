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
            this.bannerDir1RadioButton = new System.Windows.Forms.RadioButton();
            this.bannerDir0RadioButton = new System.Windows.Forms.RadioButton();
            this.bannerSpeedTextBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.bannerCheckBox = new System.Windows.Forms.CheckBox();
            this.strikeoutCheckBox = new System.Windows.Forms.CheckBox();
            this.underlinedCheckBox = new System.Windows.Forms.CheckBox();
            this.boldfaceCheckBox = new System.Windows.Forms.CheckBox();
            this.italicsCheckBox = new System.Windows.Forms.CheckBox();
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
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "字幕文件：";
            // 
            // subFileNameTextBox
            // 
            this.subFileNameTextBox.Enabled = false;
            this.subFileNameTextBox.Location = new System.Drawing.Point(93, 11);
            this.subFileNameTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.subFileNameTextBox.Name = "subFileNameTextBox";
            this.subFileNameTextBox.Size = new System.Drawing.Size(489, 23);
            this.subFileNameTextBox.TabIndex = 1;
            // 
            // openSubFileButton
            // 
            this.openSubFileButton.Location = new System.Drawing.Point(591, 7);
            this.openSubFileButton.Margin = new System.Windows.Forms.Padding(4);
            this.openSubFileButton.Name = "openSubFileButton";
            this.openSubFileButton.Size = new System.Drawing.Size(92, 27);
            this.openSubFileButton.TabIndex = 2;
            this.openSubFileButton.Text = "浏览";
            this.openSubFileButton.UseVisualStyleBackColor = true;
            this.openSubFileButton.Click += new System.EventHandler(this.OpenSubFileButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 41);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "注释添加位置：";
            // 
            // commLocTextBox
            // 
            this.commLocTextBox.Location = new System.Drawing.Point(119, 39);
            this.commLocTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.commLocTextBox.Name = "commLocTextBox";
            this.commLocTextBox.Size = new System.Drawing.Size(121, 23);
            this.commLocTextBox.TabIndex = 4;
            this.commLocTextBox.Text = "0:00:00.00";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(295, 41);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(145, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "每行/整段显示持续时间：";
            // 
            // showTimeTextBox
            // 
            this.showTimeTextBox.Location = new System.Drawing.Point(455, 39);
            this.showTimeTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.showTimeTextBox.Name = "showTimeTextBox";
            this.showTimeTextBox.Size = new System.Drawing.Size(127, 23);
            this.showTimeTextBox.TabIndex = 6;
            this.showTimeTextBox.Text = "0:00:05.00";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 69);
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
            this.contentTextBox.Location = new System.Drawing.Point(13, 89);
            this.contentTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.contentTextBox.Multiline = true;
            this.contentTextBox.Name = "contentTextBox";
            this.contentTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.contentTextBox.Size = new System.Drawing.Size(669, 224);
            this.contentTextBox.TabIndex = 8;
            this.contentTextBox.WordWrap = false;
            // 
            // singleLineRadioButton
            // 
            this.singleLineRadioButton.AutoSize = true;
            this.singleLineRadioButton.Checked = true;
            this.singleLineRadioButton.Location = new System.Drawing.Point(387, 324);
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
            this.multiLineRadioButton.Location = new System.Drawing.Point(387, 347);
            this.multiLineRadioButton.Margin = new System.Windows.Forms.Padding(4);
            this.multiLineRadioButton.Name = "multiLineRadioButton";
            this.multiLineRadioButton.Size = new System.Drawing.Size(74, 21);
            this.multiLineRadioButton.TabIndex = 10;
            this.multiLineRadioButton.Text = "整段显示";
            this.multiLineRadioButton.UseVisualStyleBackColor = true;
            // 
            // doneButton
            // 
            this.doneButton.Location = new System.Drawing.Point(473, 321);
            this.doneButton.Margin = new System.Windows.Forms.Padding(4);
            this.doneButton.Name = "doneButton";
            this.doneButton.Size = new System.Drawing.Size(209, 48);
            this.doneButton.TabIndex = 11;
            this.doneButton.Text = "插入字幕";
            this.doneButton.UseVisualStyleBackColor = true;
            this.doneButton.Click += new System.EventHandler(this.DoneButton_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 324);
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
            this.styleComboBox.Location = new System.Drawing.Point(93, 321);
            this.styleComboBox.Margin = new System.Windows.Forms.Padding(4);
            this.styleComboBox.Name = "styleComboBox";
            this.styleComboBox.Size = new System.Drawing.Size(185, 25);
            this.styleComboBox.TabIndex = 13;
            // 
            // advCheckBox
            // 
            this.advCheckBox.AutoSize = true;
            this.advCheckBox.Location = new System.Drawing.Point(17, 349);
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
            this.advGroupBox.Controls.Add(this.bannerDir1RadioButton);
            this.advGroupBox.Controls.Add(this.bannerDir0RadioButton);
            this.advGroupBox.Controls.Add(this.bannerSpeedTextBox);
            this.advGroupBox.Controls.Add(this.label8);
            this.advGroupBox.Controls.Add(this.bannerCheckBox);
            this.advGroupBox.Controls.Add(this.strikeoutCheckBox);
            this.advGroupBox.Controls.Add(this.underlinedCheckBox);
            this.advGroupBox.Controls.Add(this.boldfaceCheckBox);
            this.advGroupBox.Controls.Add(this.italicsCheckBox);
            this.advGroupBox.Controls.Add(this.label7);
            this.advGroupBox.Controls.Add(this.customTextBox);
            this.advGroupBox.Controls.Add(this.label6);
            this.advGroupBox.Controls.Add(this.customCheckBox);
            this.advGroupBox.Controls.Add(this.alphaTextBox);
            this.advGroupBox.Controls.Add(this.alphaCheckBox);
            this.advGroupBox.Controls.Add(this.fadMsLabe);
            this.advGroupBox.Controls.Add(this.fadMsTextBox);
            this.advGroupBox.Controls.Add(this.fadCheckBox);
            this.advGroupBox.Location = new System.Drawing.Point(17, 381);
            this.advGroupBox.Name = "advGroupBox";
            this.advGroupBox.Size = new System.Drawing.Size(666, 78);
            this.advGroupBox.TabIndex = 16;
            this.advGroupBox.TabStop = false;
            this.advGroupBox.Text = "高级";
            // 
            // bannerDir1RadioButton
            // 
            this.bannerDir1RadioButton.AutoSize = true;
            this.bannerDir1RadioButton.Enabled = false;
            this.bannerDir1RadioButton.Location = new System.Drawing.Point(559, 43);
            this.bannerDir1RadioButton.Name = "bannerDir1RadioButton";
            this.bannerDir1RadioButton.Size = new System.Drawing.Size(74, 21);
            this.bannerDir1RadioButton.TabIndex = 33;
            this.bannerDir1RadioButton.Text = "从左到右";
            this.bannerDir1RadioButton.UseVisualStyleBackColor = true;
            // 
            // bannerDir0RadioButton
            // 
            this.bannerDir0RadioButton.AutoSize = true;
            this.bannerDir0RadioButton.Checked = true;
            this.bannerDir0RadioButton.Enabled = false;
            this.bannerDir0RadioButton.Location = new System.Drawing.Point(559, 21);
            this.bannerDir0RadioButton.Name = "bannerDir0RadioButton";
            this.bannerDir0RadioButton.Size = new System.Drawing.Size(74, 21);
            this.bannerDir0RadioButton.TabIndex = 32;
            this.bannerDir0RadioButton.TabStop = true;
            this.bannerDir0RadioButton.Text = "从右到左";
            this.bannerDir0RadioButton.UseVisualStyleBackColor = true;
            // 
            // bannerSpeedTextBox
            // 
            this.bannerSpeedTextBox.Enabled = false;
            this.bannerSpeedTextBox.Location = new System.Drawing.Point(519, 42);
            this.bannerSpeedTextBox.Name = "bannerSpeedTextBox";
            this.bannerSpeedTextBox.Size = new System.Drawing.Size(36, 23);
            this.bannerSpeedTextBox.TabIndex = 31;
            this.bannerSpeedTextBox.Text = "5";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(485, 45);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(44, 17);
            this.label8.TabIndex = 30;
            this.label8.Text = "速度：";
            // 
            // bannerCheckBox
            // 
            this.bannerCheckBox.AutoSize = true;
            this.bannerCheckBox.Location = new System.Drawing.Point(488, 22);
            this.bannerCheckBox.Name = "bannerCheckBox";
            this.bannerCheckBox.Size = new System.Drawing.Size(75, 21);
            this.bannerCheckBox.TabIndex = 29;
            this.bannerCheckBox.Text = "横幅滚动";
            this.bannerCheckBox.UseVisualStyleBackColor = true;
            this.bannerCheckBox.CheckedChanged += new System.EventHandler(this.bannerCheckBox_CheckedChanged);
            // 
            // strikeoutCheckBox
            // 
            this.strikeoutCheckBox.AutoSize = true;
            this.strikeoutCheckBox.Location = new System.Drawing.Point(337, 21);
            this.strikeoutCheckBox.Margin = new System.Windows.Forms.Padding(2);
            this.strikeoutCheckBox.Name = "strikeoutCheckBox";
            this.strikeoutCheckBox.Size = new System.Drawing.Size(63, 21);
            this.strikeoutCheckBox.TabIndex = 28;
            this.strikeoutCheckBox.Text = "删除线";
            this.strikeoutCheckBox.UseVisualStyleBackColor = true;
            // 
            // underlinedCheckBox
            // 
            this.underlinedCheckBox.AutoSize = true;
            this.underlinedCheckBox.Location = new System.Drawing.Point(273, 21);
            this.underlinedCheckBox.Margin = new System.Windows.Forms.Padding(2);
            this.underlinedCheckBox.Name = "underlinedCheckBox";
            this.underlinedCheckBox.Size = new System.Drawing.Size(63, 21);
            this.underlinedCheckBox.TabIndex = 27;
            this.underlinedCheckBox.Text = "下划线";
            this.underlinedCheckBox.UseVisualStyleBackColor = true;
            // 
            // boldfaceCheckBox
            // 
            this.boldfaceCheckBox.AutoSize = true;
            this.boldfaceCheckBox.Location = new System.Drawing.Point(221, 21);
            this.boldfaceCheckBox.Margin = new System.Windows.Forms.Padding(2);
            this.boldfaceCheckBox.Name = "boldfaceCheckBox";
            this.boldfaceCheckBox.Size = new System.Drawing.Size(51, 21);
            this.boldfaceCheckBox.TabIndex = 26;
            this.boldfaceCheckBox.Text = "粗体";
            this.boldfaceCheckBox.UseVisualStyleBackColor = true;
            // 
            // italicsCheckBox
            // 
            this.italicsCheckBox.AutoSize = true;
            this.italicsCheckBox.Location = new System.Drawing.Point(169, 21);
            this.italicsCheckBox.Margin = new System.Windows.Forms.Padding(2);
            this.italicsCheckBox.Name = "italicsCheckBox";
            this.italicsCheckBox.Size = new System.Drawing.Size(51, 21);
            this.italicsCheckBox.TabIndex = 25;
            this.italicsCheckBox.Text = "斜体";
            this.italicsCheckBox.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(451, 49);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(12, 17);
            this.label7.TabIndex = 24;
            this.label7.Text = "}";
            // 
            // customTextBox
            // 
            this.customTextBox.Enabled = false;
            this.customTextBox.Location = new System.Drawing.Point(291, 46);
            this.customTextBox.Name = "customTextBox";
            this.customTextBox.Size = new System.Drawing.Size(157, 23);
            this.customTextBox.TabIndex = 23;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(277, 49);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(12, 17);
            this.label6.TabIndex = 22;
            this.label6.Text = "{";
            // 
            // customCheckBox
            // 
            this.customCheckBox.AutoSize = true;
            this.customCheckBox.Location = new System.Drawing.Point(169, 48);
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
            this.alphaTextBox.Location = new System.Drawing.Point(73, 46);
            this.alphaTextBox.Name = "alphaTextBox";
            this.alphaTextBox.Size = new System.Drawing.Size(57, 23);
            this.alphaTextBox.TabIndex = 20;
            this.alphaTextBox.Text = "0~255";
            // 
            // alphaCheckBox
            // 
            this.alphaCheckBox.AutoSize = true;
            this.alphaCheckBox.Location = new System.Drawing.Point(9, 48);
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
            this.fadMsLabe.Location = new System.Drawing.Point(131, 23);
            this.fadMsLabe.Name = "fadMsLabe";
            this.fadMsLabe.Size = new System.Drawing.Size(25, 17);
            this.fadMsLabe.TabIndex = 18;
            this.fadMsLabe.Text = "ms";
            // 
            // fadMsTextBox
            // 
            this.fadMsTextBox.Enabled = false;
            this.fadMsTextBox.Location = new System.Drawing.Point(86, 20);
            this.fadMsTextBox.Name = "fadMsTextBox";
            this.fadMsTextBox.Size = new System.Drawing.Size(44, 23);
            this.fadMsTextBox.TabIndex = 17;
            this.fadMsTextBox.Text = "200";
            // 
            // fadCheckBox
            // 
            this.fadCheckBox.AutoSize = true;
            this.fadCheckBox.Location = new System.Drawing.Point(9, 21);
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
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(697, 471);
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
        private CheckBox italicsCheckBox;
        private CheckBox boldfaceCheckBox;
        private CheckBox underlinedCheckBox;
        private CheckBox strikeoutCheckBox;
        private CheckBox bannerCheckBox;
        private RadioButton bannerDir1RadioButton;
        private RadioButton bannerDir0RadioButton;
        private TextBox bannerSpeedTextBox;
        private Label label8;
    }
}