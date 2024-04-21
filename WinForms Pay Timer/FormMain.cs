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

    const int ProjectNameColumnWidth = 120;
    const int HourlyRateColumnWidth = 80;
    const int TimeSpentColumnWidth = 90;
    const int MoneyEarnedColumnWidth = 100;
    const int StartTimeColumnWidth = 100;
    const int StopTimeColumnWidth = 100;
    const int MinimumValueForDisplay = 2;
    const string DefaultValueForDisplay = "00";
    const string DefaultValueForMoneyDisplay = "$0.00";
    const string DefaultValueForTimerDisplay = "00:00:00";

    public Timer TimerUpdateTimerText => timerUpdateTimerText;
    public Button ButtonTimerStart => buttonTimerStart;
    public Button ButtonTimerPause => buttonTimerPause;
    public Button ButtonStartNewJob => buttonStartNewJob;
    public Button ButtonTimerComplete => buttonTimerComplete;
    public Button ButtonTimerReset => buttonTimerReset;
    public Button ButtonCancelJob => buttonCancelJob;

    public FormMain() => InitializeComponent();
    void FormMain_Load(object sender, EventArgs e)
    {
        listViewTimeCards.View = View.Details;
        listViewTimeCards.GridLines = true;
        listViewTimeCards.FullRowSelect = true;

        listViewTimeCards.Columns.Add("Project Name", ProjectNameColumnWidth);
        listViewTimeCards.Columns.Add("Hourly Rate", HourlyRateColumnWidth);
        listViewTimeCards.Columns.Add("Time Spent", TimeSpentColumnWidth);
        listViewTimeCards.Columns.Add("Money Earned", MoneyEarnedColumnWidth);
        listViewTimeCards.Columns.Add("Start Time", StartTimeColumnWidth);
        listViewTimeCards.Columns.Add("Stop Time", StopTimeColumnWidth);

        listViewCompletedJobs.View = View.Details;
        listViewCompletedJobs.GridLines = true;
        listViewCompletedJobs.FullRowSelect = true;

        listViewCompletedJobs.Columns.Add("Project Name", ProjectNameColumnWidth);
        listViewCompletedJobs.Columns.Add("Hourly Rate", HourlyRateColumnWidth);
        listViewCompletedJobs.Columns.Add("Time Spent", TimeSpentColumnWidth);
        listViewCompletedJobs.Columns.Add("Money Earned", MoneyEarnedColumnWidth);

        stateManager = new(this);
    }

    void buttonTimerStart_Click(object sender, EventArgs e)
    {
        stateManager.SwapState(StateManager.States.Started);
    }

    void timerUpdateTimerText_Tick(object sender, EventArgs e)
    {
        labelTimerDisplay.Text = FormatTime(elapsedTime);

        var totalEarnedThisJob = (TimeCardsThisJob.Sum((t) => t.MoneyEarned) + CurrentJobTimeCard.HourlyRate * (decimal)elapsedTime.TotalHours);
        var totalEarnedOnCompletedJobs = (TimeCardsCompletedJobs.Sum((t) => t.MoneyEarned));
        var GrandTotal = totalEarnedThisJob + totalEarnedOnCompletedJobs;

        labelMoneyEarned.Text = "$" + totalEarnedThisJob.ToString("F2");
        labelGrandTotal.Text = "$" + GrandTotal.ToString("F2");
    }

    void buttonTimerPause_Click(object sender, EventArgs e)
    {
        stateManager.SwapState(StateManager.States.Paused);
        //buttonTimerStart.Enabled = true;
        //buttonTimerPause.Enabled = false;

        //timerUpdateTimerText.Stop();
        //TimeCard newTimeCard = CreateTimecardForCurJob();

        //timeCardsThisJob.Add(newTimeCard);

        //RefreshListView();
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
            FormatTime(timeCard.TimeSpentWorking),
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
        buttonTimerPause.PerformClick();


        timerUpdateTimerText.Stop();

        buttonStartNewJob.Enabled = true;
        buttonTimerPause.Enabled = false;
        buttonTimerReset.Enabled = false;
        buttonTimerStart.Enabled = false;
        buttonTimerComplete.Enabled = false;
        buttonCancelJob.Enabled = false;

        labelMoneyEarned.Text = DefaultValueForMoneyDisplay;
        labelTimerDisplay.Text = DefaultValueForTimerDisplay;

        var combinedTimeCard = new TimeCard
        {
            ProjectName = TimeCardsThisJob.First().ProjectName,
            HourlyRate = TimeCardsThisJob.First().HourlyRate,
            TimeSpentWorking = TimeSpan.FromTicks(TimeCardsThisJob.Sum(tc => tc.TimeSpentWorking.Ticks)),
            StartTime = TimeCardsThisJob.Min(tc => tc.StartTime),
            StopTime = TimeCardsThisJob.Max(tc => tc.StopTime),
        };

        var listViewItem = new ListViewItem(new[] {
        combinedTimeCard.ProjectName,
        combinedTimeCard.HourlyRate.ToString("F2"),
        FormatTime(combinedTimeCard.TimeSpentWorking),
        combinedTimeCard.MoneyEarned.ToString("F2")});

        listViewCompletedJobs.Items.Add(listViewItem);
        listViewTimeCards.Items.Clear();

        TimeCardsCompletedJobs.Add(combinedTimeCard);
        TimeCardsThisJob.Clear();

        CurrentJobTimeCard = new();
    }

    private string FormatTime(TimeSpan elapsedTime) => $"{((int)elapsedTime.TotalHours).ToString("D2")}:{((int)elapsedTime.TotalMinutes % 60).ToString("D2")}:{(elapsedTime.TotalSeconds % 60).ToString("00")}";
}
