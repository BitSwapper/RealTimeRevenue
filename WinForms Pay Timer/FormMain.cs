using WinForms_Pay_Timer.StateManagement;
using WinForms_Pay_Timer.TimeManagement;
using Timer = System.Windows.Forms.Timer;

namespace WinForms_Pay_Timer;

public partial class FormMain : Form
{
    StateManager stateManager;
    public TimeKeeper TimeKeeper { get; } = new();

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

    void timerUpdateTimerText_Tick(object sender, EventArgs e) => stateManager.UpdateState();

    void buttonTimerStart_Click(object sender, EventArgs e) => stateManager.SwapState(StateManager.States.Started);

    void buttonTimerPause_Click(object sender, EventArgs e) => stateManager.SwapState(StateManager.States.Paused);

    void buttonStartNewJob_Click(object sender, EventArgs e) => stateManager.SwapState(StateManager.States.InitNewJob);

    void buttonTimerComplete_Click(object sender, EventArgs e) => stateManager.SwapState(StateManager.States.Completed);

    void buttonTimerReset_Click(object sender, EventArgs e)
    {
        if(MessageBox.Show(FormMainConstants.MsgResetTimerWarning, "Warning", MessageBoxButtons.OKCancel) == DialogResult.OK)
            stateManager.SwapState(StateManager.States.Reset);
    }

    public TimeCard CreateTimecardForCurJob() => new TimeCard
    {
        ProjectName = TimeKeeper.CurrentJobTimeCard.ProjectName,
        HourlyRate = TimeKeeper.CurrentJobTimeCard.HourlyRate,
        TimeSpentWorking = TimeKeeper.ElapsedTime,
        StartTime = TimeKeeper.TimerStartTime,
        StopTime = DateTime.Now
    };

    public void RefreshListView()
    {
        listViewTimeCards.Items.Clear();
        foreach(var timeCard in TimeKeeper.TimeCardsThisJob.OrderByDescending(tc => tc.StopTime))
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
