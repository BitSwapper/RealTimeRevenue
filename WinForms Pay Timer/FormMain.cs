namespace WinForms_Pay_Timer;

public partial class FormMain : Form
{
    DateTime timerStartTime;
    TimeSpan elapsedTime => DateTime.Now - timerStartTime;

    TimeCard currentJobTimeCard;

    public FormMain()
    {
        InitializeComponent();
    }

    private void FormMain_Load(object sender, EventArgs e)
    {

    }

    private void buttonTimerStart_Click(object sender, EventArgs e)
    {
        timerStartTime = DateTime.Now;
        timerUpdateTimerText.Start();
    }

    private void timerUpdateTimerText_Tick(object sender, EventArgs e)
    {
        labelTimerDisplay.Text = $"{(int)elapsedTime.TotalHours}:{(int)elapsedTime.TotalMinutes}{elapsedTime.TotalSeconds.ToString("F2")}";
    }

    private void buttonTimerPause_Click(object sender, EventArgs e)
    {
        timerUpdateTimerText.Stop();
        currentJobTimeCard.TimeSpentWorking += elapsedTime;
    }

    private void buttonStartNewJob_Click(object sender, EventArgs e)
    {
        using(var jobStartedForm = new JobStarter())
        {
            if(jobStartedForm.ShowDialog() == DialogResult.OK)
            {
                decimal hourlyRate = jobStartedForm.HourlyRate;
                string projectName = jobStartedForm.ProjectName;

                currentJobTimeCard = new();
                currentJobTimeCard.ProjectName = projectName;
                currentJobTimeCard.HourlyRate = hourlyRate;
            }
        }
    }
}

public class TimeCard
{
    public decimal HourlyRate { get; set; }
    public string ProjectName { get; set; }
    public TimeSpan TimeSpentWorking { get; set; } = new();
}


