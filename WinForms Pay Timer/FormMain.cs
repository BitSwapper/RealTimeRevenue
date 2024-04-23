using RealTime_Revenue.ColorManagement;
using RealTime_Revenue.Misc;
using RealTime_Revenue.StateManagement;
using RealTime_Revenue.TimeManagement;
using Timer = System.Windows.Forms.Timer;
using RealTime_Revenue.Properties;

namespace RealTime_Revenue;

public partial class FormMain : Form
{
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
    public ComboBox ThemeComboBox => themeComboBox;

    StateManager stateManager;
    LinkOpener linkOpener = new();
    bool initd = false;

    public FormMain() => InitializeComponent();

    void FormMain_Load(object sender, EventArgs e)
    {
        ColorThemeManager.UpdateColorScheme(this);
        stateManager = new(this);
        stateManager.SwapState(StateManager.States.InitialzingProgram);
        initd = true;
    }

    void timerUpdateTimerText_Tick(object sender, EventArgs e) => stateManager.UpdateState();

    void buttonTimerStart_Click(object sender, EventArgs e) => stateManager.SwapState(StateManager.States.Started);

    void buttonTimerPause_Click(object sender, EventArgs e) => stateManager.SwapState(StateManager.States.Paused);

    void buttonStartNewJob_Click(object sender, EventArgs e) => stateManager.SwapState(StateManager.States.InitNewJob);

    void buttonTimerComplete_Click(object sender, EventArgs e) => stateManager.SwapState(StateManager.States.Completed);

    void linkLabelGithub_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) => linkOpener.OpenLink("https://github.com/BitSwapper");

    void linkLabelDonate_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) => linkOpener.OpenLink("https://buymeacoffee.com/bitswapper");

    void buttonTimerReset_Click(object sender, EventArgs e)
    {
        if(MessageBox.Show(FormMainConstants.MsgResetTimerWarning, "Warning", MessageBoxButtons.OKCancel) == DialogResult.OK)
            stateManager.SwapState(StateManager.States.Reset);
    }

    void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if(!initd) return;
        Settings.Default.ColorThemeOption = themeComboBox.SelectedIndex;
        Settings.Default.Save();
        ColorThemeManager.UpdateColorScheme(this);
    }
}