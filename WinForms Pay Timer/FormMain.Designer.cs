namespace WinForms_Pay_Timer;

partial class FormMain
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
    private void InitializeComponent()
    {
        components = new System.ComponentModel.Container();
        buttonTimerStart = new Button();
        buttonTimerPause = new Button();
        buttonTimerReset = new Button();
        labelTimerDisplay = new Label();
        listViewTimeCards = new ListView();
        buttonTimerComplete = new Button();
        timerUpdateTimerText = new System.Windows.Forms.Timer(components);
        buttonStartNewJob = new Button();
        SuspendLayout();
        // 
        // buttonTimerStart
        // 
        buttonTimerStart.Enabled = false;
        buttonTimerStart.Location = new Point(10, 51);
        buttonTimerStart.Name = "buttonTimerStart";
        buttonTimerStart.Size = new Size(75, 23);
        buttonTimerStart.TabIndex = 4;
        buttonTimerStart.Text = "Start";
        buttonTimerStart.UseVisualStyleBackColor = true;
        buttonTimerStart.Click += buttonTimerStart_Click;
        // 
        // buttonTimerPause
        // 
        buttonTimerPause.Enabled = false;
        buttonTimerPause.Location = new Point(142, 51);
        buttonTimerPause.Name = "buttonTimerPause";
        buttonTimerPause.Size = new Size(75, 23);
        buttonTimerPause.TabIndex = 5;
        buttonTimerPause.Text = "Pause";
        buttonTimerPause.UseVisualStyleBackColor = true;
        buttonTimerPause.Click += buttonTimerPause_Click;
        // 
        // buttonTimerReset
        // 
        buttonTimerReset.Enabled = false;
        buttonTimerReset.Location = new Point(406, 51);
        buttonTimerReset.Name = "buttonTimerReset";
        buttonTimerReset.Size = new Size(75, 23);
        buttonTimerReset.TabIndex = 6;
        buttonTimerReset.Text = "Reset";
        buttonTimerReset.UseVisualStyleBackColor = true;
        // 
        // labelTimerDisplay
        // 
        labelTimerDisplay.AutoSize = true;
        labelTimerDisplay.Font = new Font("Segoe UI", 18.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
        labelTimerDisplay.Location = new Point(191, 93);
        labelTimerDisplay.Name = "labelTimerDisplay";
        labelTimerDisplay.Size = new Size(113, 35);
        labelTimerDisplay.TabIndex = 7;
        labelTimerDisplay.Text = "00:00:00";
        // 
        // listViewTimeCards
        // 
        listViewTimeCards.Location = new Point(10, 161);
        listViewTimeCards.Name = "listViewTimeCards";
        listViewTimeCards.Size = new Size(473, 123);
        listViewTimeCards.TabIndex = 8;
        listViewTimeCards.UseCompatibleStateImageBehavior = false;
        // 
        // buttonTimerComplete
        // 
        buttonTimerComplete.Enabled = false;
        buttonTimerComplete.Location = new Point(274, 51);
        buttonTimerComplete.Name = "buttonTimerComplete";
        buttonTimerComplete.Size = new Size(75, 23);
        buttonTimerComplete.TabIndex = 9;
        buttonTimerComplete.Text = "Complete";
        buttonTimerComplete.UseVisualStyleBackColor = true;
        // 
        // timerUpdateTimerText
        // 
        timerUpdateTimerText.Interval = 10;
        timerUpdateTimerText.Tick += timerUpdateTimerText_Tick;
        // 
        // buttonStartNewJob
        // 
        buttonStartNewJob.Location = new Point(193, 12);
        buttonStartNewJob.Name = "buttonStartNewJob";
        buttonStartNewJob.Size = new Size(104, 23);
        buttonStartNewJob.TabIndex = 10;
        buttonStartNewJob.Text = "Start New Job";
        buttonStartNewJob.UseVisualStyleBackColor = true;
        buttonStartNewJob.Click += buttonStartNewJob_Click;
        // 
        // FormMain
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(495, 296);
        Controls.Add(buttonStartNewJob);
        Controls.Add(buttonTimerComplete);
        Controls.Add(listViewTimeCards);
        Controls.Add(labelTimerDisplay);
        Controls.Add(buttonTimerReset);
        Controls.Add(buttonTimerPause);
        Controls.Add(buttonTimerStart);
        Name = "FormMain";
        Text = "WinForms Pay Timer";
        Load += FormMain_Load;
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion
    private Button buttonTimerStart;
    private Button buttonTimerPause;
    private Button buttonTimerReset;
    private Label labelTimerDisplay;
    private ListView listViewTimeCards;
    private Button buttonTimerComplete;
    private System.Windows.Forms.Timer timerUpdateTimerText;
    private Button buttonStartNewJob;
}
