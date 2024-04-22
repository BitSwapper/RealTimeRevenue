using RealTime_Revenue.ColorManagement;

namespace RealTime_Revenue;

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

    void JobStarter_Load(object sender, EventArgs e) => ColorThemeManager.UpdateColorScheme(this);
}