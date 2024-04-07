using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinForms_Pay_Timer;
public partial class JobStarter : Form
{
    public decimal HourlyRate { get; private set; }
    public string ProjectName { get; private set; }

    public JobStarter()
    {
        InitializeComponent();
    }

    private void buttonFinish_Click(object sender, EventArgs e)
    {
        // Assuming you have a TextBox named 'projectNameTextBox' and a NumericUpDown named 'hourlyRateNumericUpDown'
        if(decimal.TryParse(textBoxHourlyRate.Text, out var newHourly))
            HourlyRate = newHourly;

        ProjectName = textBoxProjectName.Text;

        this.DialogResult = DialogResult.OK; // Set the dialog result to OK
        this.Close(); // Close the form
    }
}

