using WinForms_Pay_Timer.ColorManagement;
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
    public Label LabelGrandTotal => labelMoneyGrandTotal;
    public ListView ListViewCompletedJobs => listViewCompletedJobs;
    public ListView ListViewCurrentJobTimeCards => listViewTimeCards;

    public FormMain() => InitializeComponent();

    void FormMain_Load(object sender, EventArgs e)
    {
        ColorTheme.InitColors(this);

        stateManager = new(this);
        stateManager.SwapState(StateManager.States.InitialzingProgram);
    }



    void timerUpdateTimerText_Tick(object sender, EventArgs e)
    {
        stateManager.UpdateState();
        this.Text = "WinForms Pay Timer | " + stateManager.CurrentState.ToString();
    }
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

    public void RefreshListView(bool includeCurTimeCard)
    {
        listViewTimeCards.Items.Clear();

        if(includeCurTimeCard)
        {
            ListViewItem curCard = MakeNew(TimeKeeper.CurrentJobTimeCard);
            listViewTimeCards.Items.Add(curCard);
        }

        foreach(var timeCard in TimeKeeper.TimeCardsThisJob.OrderByDescending(tc => tc.StopTime))
        {
            ListViewItem listViewItem = MakeNew(timeCard);
            listViewTimeCards.Items.Add(listViewItem);
        }
    }

    private static ListViewItem MakeNew(TimeCard? timeCard) => new ListViewItem(new[]
                {
                timeCard.ProjectName,
                timeCard.MoneyEarned.ToString("F2"),
                timeCard.HourlyRate.ToString("F2"),
                TimeUtil.FormatTime(timeCard.TimeSpentWorking),
                timeCard.StartTime.ToString("HH:mm:ss"),
                timeCard.StopTime.ToString("HH:mm:ss")
            });

    private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if(comboBox1.SelectedIndex == 0)
            Properties.Settings.Default.UseDarkMode = false;
        else
            Properties.Settings.Default.UseDarkMode = true;

        ColorTheme.InitColors(this);
    }
}
