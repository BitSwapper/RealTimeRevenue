using Timer = System.Windows.Forms.Timer;

namespace WinForms_Pay_Timer;

public partial class FormMain : Form
{
    StateManager stateManager;
    public DateTime TimerStartTime { get; set; }
    TimeSpan elapsedTime => DateTime.Now - TimerStartTime;

    public TimeCard CurrentJobTimeCard { get; set; }
    public List<TimeCard> TimeCardsThisJob { get; set; } = new();
    public List<TimeCard> TimeCardsCompletedJobs { get; set; } = new();

    public Timer TimerUpdateTimerText => timerUpdateTimerText;
    public Button ButtonTimerStart => buttonTimerStart;
    public Button ButtonTimerPause => buttonTimerPause;
    public Button ButtonStartNewJob => buttonStartNewJob;
    public Button ButtonTimerComplete => buttonTimerComplete;
    public Button ButtonTimerReset => buttonTimerReset;
    public Button ButtonCancelJob => buttonCancelJob;
    public Label LabelMoneyEarned => labelMoneyEarned;
    public Label LabelTimerDisplay => labelTimerDisplay;
    public ListView ListViewCompletedJobs => listViewCompletedJobs;
    public ListView ListViewTimeCards => listViewTimeCards;


    public FormMain() => InitializeComponent();
    void FormMain_Load(object sender, EventArgs e)
    {
        listViewTimeCards.View = View.Details;
        listViewTimeCards.GridLines = true;
        listViewTimeCards.FullRowSelect = true;


        listViewTimeCards.Columns.Add("Project Name", FormMainConstants.ProjectNameColumnWidth);
        listViewTimeCards.Columns.Add("Hourly Rate", FormMainConstants.HourlyRateColumnWidth);
        listViewTimeCards.Columns.Add("Time Spent", FormMainConstants.TimeSpentColumnWidth);
        listViewTimeCards.Columns.Add("Money Earned", FormMainConstants.MoneyEarnedColumnWidth);
        listViewTimeCards.Columns.Add("Start Time", FormMainConstants.StartTimeColumnWidth);
        listViewTimeCards.Columns.Add("Stop Time", FormMainConstants.StopTimeColumnWidth);

        listViewCompletedJobs.View = View.Details;
        listViewCompletedJobs.GridLines = true;
        listViewCompletedJobs.FullRowSelect = true;

        listViewCompletedJobs.Columns.Add("Project Name", FormMainConstants.ProjectNameColumnWidth);
        listViewCompletedJobs.Columns.Add("Hourly Rate", FormMainConstants.HourlyRateColumnWidth);
        listViewCompletedJobs.Columns.Add("Time Spent", FormMainConstants.TimeSpentColumnWidth);
        listViewCompletedJobs.Columns.Add("Money Earned", FormMainConstants.MoneyEarnedColumnWidth);

        stateManager = new(this);
    }

    void buttonTimerStart_Click(object sender, EventArgs e)
    {
        stateManager.SwapState(StateManager.States.Started);
    }

    void timerUpdateTimerText_Tick(object sender, EventArgs e)
    {
        labelTimerDisplay.Text = TimeUtil.FormatTime(elapsedTime);

        var totalEarnedThisJob = (TimeCardsThisJob.Sum((t) => t.MoneyEarned) + CurrentJobTimeCard.HourlyRate * (decimal)elapsedTime.TotalHours);
        var totalEarnedOnCompletedJobs = (TimeCardsCompletedJobs.Sum((t) => t.MoneyEarned));
        var GrandTotal = totalEarnedThisJob + totalEarnedOnCompletedJobs;

        labelMoneyEarned.Text = "$" + totalEarnedThisJob.ToString("F2");
        labelGrandTotal.Text = "$" + GrandTotal.ToString("F2");
    }

    void buttonTimerPause_Click(object sender, EventArgs e)
    {
        stateManager.SwapState(StateManager.States.Paused);
    }

    public TimeCard CreateTimecardForCurJob() => new TimeCard
    {
        ProjectName = CurrentJobTimeCard.ProjectName,
        HourlyRate = CurrentJobTimeCard.HourlyRate,
        TimeSpentWorking = elapsedTime,
        StartTime = TimerStartTime,
        StopTime = DateTime.Now
    };

    public void RefreshListView()
    {
        listViewTimeCards.Items.Clear();

        foreach(var timeCard in TimeCardsThisJob.OrderByDescending(tc => tc.StopTime))
        {
            var listViewItem = new ListViewItem(new[] {
            timeCard.ProjectName,
            timeCard.HourlyRate.ToString("F2"),
            TimeUtil.FormatTime(timeCard.TimeSpentWorking),
            timeCard.MoneyEarned.ToString("F2"),
            timeCard.StartTime.ToString("MM-dd   HH:mm:ss"),
            timeCard.StopTime.ToString("MM-dd   HH:mm:ss")
        });

            listViewTimeCards.Items.Add(listViewItem);
        }
    }

    void buttonStartNewJob_Click(object sender, EventArgs e)
    {
        using(var jobStartedForm = new JobStarter())
        {
            if(jobStartedForm.ShowDialog() == DialogResult.OK)
            {
                decimal hourlyRate = jobStartedForm.HourlyRate;
                string projectName = jobStartedForm.ProjectName;

                CurrentJobTimeCard = new();
                CurrentJobTimeCard.ProjectName = projectName;
                CurrentJobTimeCard.HourlyRate = hourlyRate;

                buttonTimerStart.Enabled = true;
                buttonTimerComplete.Enabled = false;
                buttonTimerReset.Enabled = false;
            }
        }
    }

    private void buttonTimerComplete_Click(object sender, EventArgs e)
    {
        stateManager.SwapState(StateManager.States.Completed);
    }
}

public static class FormMainConstants
{
    public const int ProjectNameColumnWidth = 120;
    public const int HourlyRateColumnWidth = 80;
    public const int TimeSpentColumnWidth = 90;
    public const int MoneyEarnedColumnWidth = 100;
    public const int StartTimeColumnWidth = 100;
    public const int StopTimeColumnWidth = 100;
    public const int MinimumValueForDisplay = 2;
    public const string DefaultValueForDisplay = "00";
    public const string DefaultValueForMoneyDisplay = "$0.00";
    public const string DefaultValueForTimerDisplay = "00:00:00";
}

public static class TimeUtil
{
    public static string FormatTime(TimeSpan elapsedTime) => $"{((int)elapsedTime.TotalHours).ToString("D2")}:{((int)elapsedTime.TotalMinutes % 60).ToString("D2")}:{(elapsedTime.TotalSeconds % 60).ToString("00")}";
}