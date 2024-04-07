﻿namespace WinForms_Pay_Timer;

partial class JobStarter
{
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
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
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        labelCurrentProj = new Label();
        textBoxProjectName = new TextBox();
        labelHourlyRate = new Label();
        textBoxHourlyRate = new TextBox();
        buttonFinish = new Button();
        SuspendLayout();
        // 
        // labelCurrentProj
        // 
        labelCurrentProj.AutoSize = true;
        labelCurrentProj.Location = new Point(12, 40);
        labelCurrentProj.Name = "labelCurrentProj";
        labelCurrentProj.Size = new Size(79, 15);
        labelCurrentProj.TabIndex = 7;
        labelCurrentProj.Text = "Project Name";
        // 
        // textBoxProjectName
        // 
        textBoxProjectName.Location = new Point(107, 36);
        textBoxProjectName.Name = "textBoxProjectName";
        textBoxProjectName.Size = new Size(173, 23);
        textBoxProjectName.TabIndex = 6;
        // 
        // labelHourlyRate
        // 
        labelHourlyRate.AutoSize = true;
        labelHourlyRate.Location = new Point(12, 9);
        labelHourlyRate.Name = "labelHourlyRate";
        labelHourlyRate.Size = new Size(69, 15);
        labelHourlyRate.TabIndex = 5;
        labelHourlyRate.Text = "Hourly Rate";
        // 
        // textBoxHourlyRate
        // 
        textBoxHourlyRate.Location = new Point(107, 6);
        textBoxHourlyRate.Name = "textBoxHourlyRate";
        textBoxHourlyRate.Size = new Size(40, 23);
        textBoxHourlyRate.TabIndex = 4;
        textBoxHourlyRate.Text = "40";
        // 
        // buttonFinish
        // 
        buttonFinish.Location = new Point(107, 77);
        buttonFinish.Name = "buttonFinish";
        buttonFinish.Size = new Size(75, 23);
        buttonFinish.TabIndex = 8;
        buttonFinish.Text = "OK";
        buttonFinish.UseVisualStyleBackColor = true;
        buttonFinish.Click += buttonFinish_Click;
        // 
        // JobStarter
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(311, 112);
        Controls.Add(buttonFinish);
        Controls.Add(labelCurrentProj);
        Controls.Add(textBoxProjectName);
        Controls.Add(labelHourlyRate);
        Controls.Add(textBoxHourlyRate);
        Name = "JobStarter";
        Text = "JobStarter";
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Label labelCurrentProj;
    private TextBox textBoxProjectName;
    private Label labelHourlyRate;
    private TextBox textBoxHourlyRate;
    private Button buttonFinish;
}