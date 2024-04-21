using WinForms_Pay_Timer.ColorManagement;
using WinForms_Pay_Timer.StateManagement;
using WinForms_Pay_Timer.TimeManagement;
using static WinForms_Pay_Timer.ColorManagement.ColorThemeManager;
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
    bool initd = false;

    public FormMain() => InitializeComponent();

    void FormMain_Load(object sender, EventArgs e)
    {
        ColorThemeManager.InitColors(this);

        stateManager = new(this);
        stateManager.SwapState(StateManager.States.InitialzingProgram);
        comboBox1.DataSource = Enum.GetValues(typeof(ThemeChoice));
        comboBox1.SelectedIndex = Properties.Settings.Default.ColorThemeOption;
        initd = true;
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

    static ListViewItem MakeNew(TimeCard? timeCard) => new ListViewItem(new[]
                {
                timeCard.ProjectName,
                timeCard.MoneyEarned.ToString("F2"),
                timeCard.HourlyRate.ToString("F2"),
                TimeUtil.FormatTime(timeCard.TimeSpentWorking),
                timeCard.StartTime.ToString("HH:mm:ss"),
                timeCard.StopTime.ToString("HH:mm:ss")
            });

    void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if(!initd) return;
        Properties.Settings.Default.ColorThemeOption = comboBox1.SelectedIndex;
        Properties.Settings.Default.Save();
        ColorThemeManager.InitColors(this);
    }

    void linkLabelGithub_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) => OpenLink("https://github.com/BitSwapper");

    static void OpenLink(string link)
    {
        using(var process = new System.Diagnostics.Process())
        {
            process.StartInfo = new System.Diagnostics.ProcessStartInfo
            {
                UseShellExecute = true,
                FileName = link
            };
            process.Start();
        }
    }
}