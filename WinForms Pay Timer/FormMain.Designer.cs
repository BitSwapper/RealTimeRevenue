namespace RealTime_Revenue;

partial class FormMain
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if(disposing && (components != null))
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
    void InitializeComponent()
    {
        components = new System.ComponentModel.Container();
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
        buttonTimerStart = new Button();
        buttonTimerPause = new Button();
        buttonTimerReset = new Button();
        labelTimerDisplayCurJob = new Label();
        listViewTimeCards = new ListView();
        buttonTimerComplete = new Button();
        timerUpdateTimerText = new System.Windows.Forms.Timer(components);
        buttonStartNewJob = new Button();
        labelMoneyEarned = new Label();
        listViewCompletedJobs = new ListView();
        labelMoneyGrandTotal = new Label();
        label1 = new Label();
        themeComboBox = new ComboBox();
        linkLabel1 = new LinkLabel();
        linkLabelDonate = new LinkLabel();
        labelCurJobName = new Label();
        labelTimerDisplayGrandTotal = new Label();
        SuspendLayout();
        // 
        // buttonTimerStart
        // 
        buttonTimerStart.Enabled = false;
        buttonTimerStart.FlatAppearance.BorderColor = Color.Gray;
        buttonTimerStart.FlatAppearance.CheckedBackColor = Color.Silver;
        buttonTimerStart.FlatStyle = FlatStyle.Flat;
        buttonTimerStart.Location = new Point(119, 55);
        buttonTimerStart.Name = "buttonTimerStart";
        buttonTimerStart.Size = new Size(55, 24);
        buttonTimerStart.TabIndex = 4;
        buttonTimerStart.Text = "Start";
        buttonTimerStart.UseVisualStyleBackColor = true;
        buttonTimerStart.Click += buttonTimerStart_Click;
        // 
        // buttonTimerPause
        // 
        buttonTimerPause.Enabled = false;
        buttonTimerPause.FlatAppearance.BorderColor = Color.Gray;
        buttonTimerPause.FlatAppearance.CheckedBackColor = Color.Silver;
        buttonTimerPause.FlatStyle = FlatStyle.Flat;
        buttonTimerPause.Location = new Point(187, 55);
        buttonTimerPause.Name = "buttonTimerPause";
        buttonTimerPause.Size = new Size(55, 24);
        buttonTimerPause.TabIndex = 5;
        buttonTimerPause.Text = "Pause";
        buttonTimerPause.UseVisualStyleBackColor = true;
        buttonTimerPause.Click += buttonTimerPause_Click;
        // 
        // buttonTimerReset
        // 
        buttonTimerReset.Enabled = false;
        buttonTimerReset.FlatAppearance.BorderColor = Color.Gray;
        buttonTimerReset.FlatAppearance.CheckedBackColor = Color.Silver;
        buttonTimerReset.FlatStyle = FlatStyle.Flat;
        buttonTimerReset.Location = new Point(323, 55);
        buttonTimerReset.Name = "buttonTimerReset";
        buttonTimerReset.Size = new Size(55, 24);
        buttonTimerReset.TabIndex = 6;
        buttonTimerReset.Text = "Reset";
        buttonTimerReset.UseVisualStyleBackColor = true;
        buttonTimerReset.Click += buttonTimerReset_Click;
        // 
        // labelTimerDisplayCurJob
        // 
        labelTimerDisplayCurJob.AutoSize = true;
        labelTimerDisplayCurJob.Font = new Font("Segoe UI", 17.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
        labelTimerDisplayCurJob.Location = new Point(11, 21);
        labelTimerDisplayCurJob.Name = "labelTimerDisplayCurJob";
        labelTimerDisplayCurJob.Size = new Size(104, 31);
        labelTimerDisplayCurJob.TabIndex = 7;
        labelTimerDisplayCurJob.Text = "00:00:00";
        labelTimerDisplayCurJob.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // listViewTimeCards
        // 
        listViewTimeCards.Location = new Point(12, 86);
        listViewTimeCards.Name = "listViewTimeCards";
        listViewTimeCards.Size = new Size(475, 120);
        listViewTimeCards.TabIndex = 8;
        listViewTimeCards.UseCompatibleStateImageBehavior = false;
        // 
        // buttonTimerComplete
        // 
        buttonTimerComplete.Enabled = false;
        buttonTimerComplete.FlatAppearance.BorderColor = Color.Gray;
        buttonTimerComplete.FlatAppearance.CheckedBackColor = Color.Silver;
        buttonTimerComplete.FlatStyle = FlatStyle.Flat;
        buttonTimerComplete.Location = new Point(255, 55);
        buttonTimerComplete.Name = "buttonTimerComplete";
        buttonTimerComplete.Size = new Size(55, 24);
        buttonTimerComplete.TabIndex = 9;
        buttonTimerComplete.Text = "Finish";
        buttonTimerComplete.UseVisualStyleBackColor = true;
        buttonTimerComplete.Click += buttonTimerComplete_Click;
        // 
        // timerUpdateTimerText
        // 
        timerUpdateTimerText.Interval = 10;
        timerUpdateTimerText.Tick += timerUpdateTimerText_Tick;
        // 
        // buttonStartNewJob
        // 
        buttonStartNewJob.FlatAppearance.BorderColor = Color.Gray;
        buttonStartNewJob.FlatAppearance.CheckedBackColor = Color.Silver;
        buttonStartNewJob.FlatStyle = FlatStyle.Flat;
        buttonStartNewJob.Location = new Point(197, 7);
        buttonStartNewJob.Name = "buttonStartNewJob";
        buttonStartNewJob.Size = new Size(104, 23);
        buttonStartNewJob.TabIndex = 10;
        buttonStartNewJob.Text = "Start New Job";
        buttonStartNewJob.UseVisualStyleBackColor = true;
        buttonStartNewJob.Click += buttonStartNewJob_Click;
        // 
        // labelMoneyEarned
        // 
        labelMoneyEarned.AutoSize = true;
        labelMoneyEarned.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold);
        labelMoneyEarned.ForeColor = Color.Green;
        labelMoneyEarned.Location = new Point(13, 50);
        labelMoneyEarned.Name = "labelMoneyEarned";
        labelMoneyEarned.Size = new Size(67, 30);
        labelMoneyEarned.TabIndex = 11;
        labelMoneyEarned.Text = "$0.00";
        labelMoneyEarned.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // listViewCompletedJobs
        // 
        listViewCompletedJobs.Location = new Point(12, 213);
        listViewCompletedJobs.Name = "listViewCompletedJobs";
        listViewCompletedJobs.Size = new Size(475, 120);
        listViewCompletedJobs.TabIndex = 12;
        listViewCompletedJobs.UseCompatibleStateImageBehavior = false;
        // 
        // labelMoneyGrandTotal
        // 
        labelMoneyGrandTotal.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        labelMoneyGrandTotal.AutoSize = true;
        labelMoneyGrandTotal.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold);
        labelMoneyGrandTotal.ForeColor = Color.Green;
        labelMoneyGrandTotal.Location = new Point(13, 386);
        labelMoneyGrandTotal.Name = "labelMoneyGrandTotal";
        labelMoneyGrandTotal.RightToLeft = RightToLeft.No;
        labelMoneyGrandTotal.Size = new Size(67, 30);
        labelMoneyGrandTotal.TabIndex = 13;
        labelMoneyGrandTotal.Text = "$0.00";
        labelMoneyGrandTotal.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // label1
        // 
        label1.AutoSize = true;
        label1.Location = new Point(13, 339);
        label1.Name = "label1";
        label1.Size = new Size(67, 15);
        label1.TabIndex = 14;
        label1.Text = "Grand Total";
        label1.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // themeComboBox
        // 
        themeComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
        themeComboBox.FormattingEnabled = true;
        themeComboBox.ItemHeight = 15;
        themeComboBox.Items.AddRange(new object[] { "Light", "Dark" });
        themeComboBox.Location = new Point(376, 7);
        themeComboBox.Name = "themeComboBox";
        themeComboBox.Size = new Size(103, 23);
        themeComboBox.TabIndex = 15;
        themeComboBox.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
        // 
        // linkLabel1
        // 
        linkLabel1.AutoSize = true;
        linkLabel1.LinkColor = Color.FromArgb(128, 128, 255);
        linkLabel1.Location = new Point(12, 419);
        linkLabel1.Name = "linkLabel1";
        linkLabel1.Size = new Size(43, 15);
        linkLabel1.TabIndex = 17;
        linkLabel1.TabStop = true;
        linkLabel1.Text = "Github";
        linkLabel1.LinkClicked += linkLabelGithub_LinkClicked;
        // 
        // linkLabelDonate
        // 
        linkLabelDonate.AutoSize = true;
        linkLabelDonate.LinkColor = Color.FromArgb(128, 128, 255);
        linkLabelDonate.Location = new Point(444, 419);
        linkLabelDonate.Name = "linkLabelDonate";
        linkLabelDonate.Size = new Size(45, 15);
        linkLabelDonate.TabIndex = 18;
        linkLabelDonate.TabStop = true;
        linkLabelDonate.Text = "Donate";
        linkLabelDonate.LinkClicked += linkLabelDonate_LinkClicked;
        // 
        // labelCurJobName
        // 
        labelCurJobName.AutoSize = true;
        labelCurJobName.Location = new Point(13, 6);
        labelCurJobName.Name = "labelCurJobName";
        labelCurJobName.Size = new Size(87, 15);
        labelCurJobName.TabIndex = 19;
        labelCurJobName.Text = "This Job (none)";
        // 
        // labelTimerDisplayGrandTotal
        // 
        labelTimerDisplayGrandTotal.AutoSize = true;
        labelTimerDisplayGrandTotal.Font = new Font("Segoe UI", 17.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
        labelTimerDisplayGrandTotal.Location = new Point(11, 355);
        labelTimerDisplayGrandTotal.Name = "labelTimerDisplayGrandTotal";
        labelTimerDisplayGrandTotal.Size = new Size(104, 31);
        labelTimerDisplayGrandTotal.TabIndex = 20;
        labelTimerDisplayGrandTotal.Text = "00:00:00";
        labelTimerDisplayGrandTotal.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // FormMain
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(496, 437);
        Controls.Add(labelTimerDisplayGrandTotal);
        Controls.Add(labelCurJobName);
        Controls.Add(linkLabelDonate);
        Controls.Add(linkLabel1);
        Controls.Add(themeComboBox);
        Controls.Add(label1);
        Controls.Add(labelMoneyGrandTotal);
        Controls.Add(listViewCompletedJobs);
        Controls.Add(labelMoneyEarned);
        Controls.Add(buttonStartNewJob);
        Controls.Add(buttonTimerComplete);
        Controls.Add(listViewTimeCards);
        Controls.Add(labelTimerDisplayCurJob);
        Controls.Add(buttonTimerReset);
        Controls.Add(buttonTimerPause);
        Controls.Add(buttonTimerStart);
        FormBorderStyle = FormBorderStyle.FixedSingle;
        Icon = (Icon)resources.GetObject("$this.Icon");
        MaximizeBox = false;
        Name = "FormMain";
        Text = "RealTime Revenue 1.1.0";
        Load += FormMain_Load;
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion
    Button buttonTimerStart;
    Button buttonTimerPause;
    Button buttonTimerReset;
    Label labelTimerDisplayCurJob;
    ListView listViewTimeCards;
    Button buttonTimerComplete;
    System.Windows.Forms.Timer timerUpdateTimerText;
    Button buttonStartNewJob;
    Label labelMoneyEarned;
    ListView listViewCompletedJobs;
    Label labelMoneyGrandTotal;
    Label label1;
    ComboBox themeComboBox;
    LinkLabel linkLabel1;
    LinkLabel linkLabelDonate;
    Label labelCurJobName;
    Label labelTimerDisplayGrandTotal;
}
