using Timer = System.Windows.Forms.Timer;

namespace WinForms_Pay_Timer;

public partial class FormMain : Form
{
    StateManager stateManager;
    public DateTime TimerStartTime { get; set; }
    public TimeSpan ElapsedTime => DateTime.Now - TimerStartTime;

    public TimeCard CurrentJobTimeCard { get; set; }
    public List<TimeCard> TimeCardsThisJob { get; set; } = new();
    public List<TimeCard> TimeCardsCompletedJobs { get; set; } = new();

    public Timer TimerUpdateTimerText => timerUpdateTimerText;
    public Button ButtonTimerStart => buttonTimerStart;
    public Button ButtonTimerPause => buttonTimerPause;
    public Button ButtonStartNewJob => buttonStartNewJob;
    public Button ButtonTimerComplete => buttonTimerComplete;
    public Button ButtonTimerReset => buttonTimerReset;
    public Label LabelMoneyEarned => labelMoneyEarned;
    public Label LabelTimerDisplay => labelTimerDisplay;
    public Label LabelGrandTotal => labelGrandTotal;
    public ListView ListViewCompletedJobs => listViewCompletedJobs;
    public ListView ListViewTimeCards => listViewTimeCards;


    public FormMain() => InitializeComponent();
    void FormMain_Load(object sender, EventArgs e)
    {
        stateManager = new(this);
        stateManager.SwapState(StateManager.States.InitialzingProgram);
    }

    void buttonTimerStart_Click(object sender, EventArgs e) => stateManager.SwapState(StateManager.States.Started);

    void buttonTimerPause_Click(object sender, EventArgs e) => stateManager.SwapState(StateManager.States.Paused);

    void buttonStartNewJob_Click(object sender, EventArgs e) => stateManager.SwapState(StateManager.States.InitNewJob);

    void buttonTimerComplete_Click(object sender, EventArgs e) => stateManager.SwapState(StateManager.States.Completed);

    private void buttonTimerReset_Click(object sender, EventArgs e)
    {
        if(MessageBox.Show("You are about to reset the timer for the current job! Current time will be lost.", "Warning", MessageBoxButtons.OKCancel) == DialogResult.OK)
            stateManager.SwapState(StateManager.States.Reset);
    }

    void timerUpdateTimerText_Tick(object sender, EventArgs e)
    {
        stateManager.UpdateState();
    }

    public TimeCard CreateTimecardForCurJob() => new TimeCard
    {
        ProjectName = CurrentJobTimeCard.ProjectName,
        HourlyRate = CurrentJobTimeCard.HourlyRate,
        TimeSpentWorking = ElapsedTime,
        StartTime = TimerStartTime,
        StopTime = DateTime.Now
    };

    public void RefreshListView()
    {
        listViewTimeCards.Items.Clear();
        foreach(var timeCard in TimeCardsThisJob.OrderByDescending(tc => tc.StopTime))
        {
            var listViewItem = new ListViewItem(new[]
            {
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
}
