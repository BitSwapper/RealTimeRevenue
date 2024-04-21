namespace WinForms_Pay_Timer;

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
        buttonTimerStart = new Button();
        buttonTimerPause = new Button();
        buttonTimerReset = new Button();
        labelTimerDisplay = new Label();
        listViewTimeCards = new ListView();
        buttonTimerComplete = new Button();
        timerUpdateTimerText = new System.Windows.Forms.Timer(components);
        buttonStartNewJob = new Button();
        labelMoneyEarned = new Label();
        listViewCompletedJobs = new ListView();
        labelGrandTotal = new Label();
        buttonCancelJob = new Button();
        SuspendLayout();
        // 
        // buttonTimerStart
        // 
        buttonTimerStart.Enabled = false;
        buttonTimerStart.Location = new Point(122, 78);
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
        buttonTimerPause.Location = new Point(203, 78);
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
        buttonTimerReset.Location = new Point(365, 78);
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
        labelTimerDisplay.Location = new Point(12, 41);
        labelTimerDisplay.Name = "labelTimerDisplay";
        labelTimerDisplay.Size = new Size(113, 35);
        labelTimerDisplay.TabIndex = 7;
        labelTimerDisplay.Text = "00:00:00";
        labelTimerDisplay.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // listViewTimeCards
        // 
        listViewTimeCards.Location = new Point(10, 107);
        listViewTimeCards.Name = "listViewTimeCards";
        listViewTimeCards.Size = new Size(608, 123);
        listViewTimeCards.TabIndex = 8;
        listViewTimeCards.UseCompatibleStateImageBehavior = false;
        // 
        // buttonTimerComplete
        // 
        buttonTimerComplete.Enabled = false;
        buttonTimerComplete.Location = new Point(284, 78);
        buttonTimerComplete.Name = "buttonTimerComplete";
        buttonTimerComplete.Size = new Size(75, 23);
        buttonTimerComplete.TabIndex = 9;
        buttonTimerComplete.Text = "Complete";
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
        buttonStartNewJob.Location = new Point(10, 12);
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
        labelMoneyEarned.Font = new Font("Segoe UI", 18.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
        labelMoneyEarned.ForeColor = Color.Green;
        labelMoneyEarned.Location = new Point(12, 69);
        labelMoneyEarned.Name = "labelMoneyEarned";
        labelMoneyEarned.Size = new Size(78, 35);
        labelMoneyEarned.TabIndex = 11;
        labelMoneyEarned.Text = "$0.00";
        labelMoneyEarned.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // listViewCompletedJobs
        // 
        listViewCompletedJobs.Location = new Point(10, 234);
        listViewCompletedJobs.Name = "listViewCompletedJobs";
        listViewCompletedJobs.Size = new Size(608, 123);
        listViewCompletedJobs.TabIndex = 12;
        listViewCompletedJobs.UseCompatibleStateImageBehavior = false;
        // 
        // labelGrandTotal
        // 
        labelGrandTotal.AutoSize = true;
        labelGrandTotal.Font = new Font("Segoe UI", 18.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
        labelGrandTotal.ForeColor = Color.Green;
        labelGrandTotal.Location = new Point(540, 69);
        labelGrandTotal.Name = "labelGrandTotal";
        labelGrandTotal.Size = new Size(78, 35);
        labelGrandTotal.TabIndex = 13;
        labelGrandTotal.Text = "$0.00";
        labelGrandTotal.TextAlign = ContentAlignment.MiddleRight;
        // 
        // buttonCancelJob
        // 
        buttonCancelJob.Enabled = false;
        buttonCancelJob.Location = new Point(446, 78);
        buttonCancelJob.Name = "buttonCancelJob";
        buttonCancelJob.Size = new Size(75, 23);
        buttonCancelJob.TabIndex = 14;
        buttonCancelJob.Text = "Cancel Job";
        buttonCancelJob.UseVisualStyleBackColor = true;
        // 
        // FormMain
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(637, 367);
        Controls.Add(buttonCancelJob);
        Controls.Add(labelGrandTotal);
        Controls.Add(listViewCompletedJobs);
        Controls.Add(labelMoneyEarned);
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
    Button buttonTimerStart;
    Button buttonTimerPause;
    Button buttonTimerReset;
    Label labelTimerDisplay;
    ListView listViewTimeCards;
    Button buttonTimerComplete;
    System.Windows.Forms.Timer timerUpdateTimerText;
    Button buttonStartNewJob;
    Label labelMoneyEarned;
    ListView listViewCompletedJobs;
    Label labelGrandTotal;
    Button buttonCancelJob;
}
