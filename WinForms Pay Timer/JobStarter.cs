using WinForms_Pay_Timer.ColorManagement;

namespace WinForms_Pay_Timer;

public partial class JobStarter : Form
{
    public decimal HourlyRate { get; private set; }
    public string ProjectName { get; private set; } = "";

    public JobStarter() => InitializeComponent();

    void buttonFinish_Click(object sender, EventArgs e)
    {
        if(decimal.TryParse(textBoxHourlyRate.Text, out var newHourly))
            HourlyRate = newHourly;

        ProjectName = textBoxProjectName.Text;

        this.DialogResult = DialogResult.OK;
        this.Close();
    }

    private void JobStarter_Load(object sender, EventArgs e)
    {
        ColorTheme.InitColors(this);
    }
}