using RealTime_Revenue.ColorManagement;

namespace RealTime_Revenue;

public partial class JobStarter : Form
{
    public decimal HourlyRate { get; private set; }
    public string ProjectName { get; private set; } = "";

    public JobStarter() => InitializeComponent();

    void buttonFinish_Click(object sender, EventArgs e)
    {
        Finish();
    }

    void Finish()
    {
        if(decimal.TryParse(textBoxHourlyRate.Text, out var newHourly))
            HourlyRate = newHourly;

        ProjectName = textBoxProjectName.Text;

        this.DialogResult = DialogResult.OK;
        this.Close();
    }

    void JobStarter_Load(object sender, EventArgs e) => ColorThemeManager.UpdateColorScheme(this);

    void textBoxHourlyRate_KeyDown(object sender, KeyEventArgs e)
    {
        ListenForKeys(e);

    }

    void textBoxProjectName_KeyDown(object sender, KeyEventArgs e)
    {
        ListenForKeys(e);
    }

    void ListenForKeys(KeyEventArgs e)
    {
        if(e.KeyCode == Keys.Enter)
        {
            e.Handled = true;
            Finish();
        }
        else if(e.KeyCode == Keys.Escape)
        {
            e.Handled = true;
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}