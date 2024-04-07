namespace WinForms_Pay_Timer;

public partial class FormMain : Form
{
    DateTime timerStartTime;
    TimeSpan elapsedTime => DateTime.Now - timerStartTime;

    TimeCard currentJobTimeCard;
    List<TimeCard> timeCards = new();
    public FormMain()
    {
        InitializeComponent();
    }

    private void FormMain_Load(object sender, EventArgs e)
    {
        listViewTimeCards.View = View.Details; // Enable the grid lines and column headers
        listViewTimeCards.GridLines = true; // Show grid lines
        listViewTimeCards.FullRowSelect = true;

        listViewTimeCards.Columns.Add("Project Name", 120);
        listViewTimeCards.Columns.Add("Hourly Rate", 80);
        listViewTimeCards.Columns.Add("Time Spent", 100);
        listViewTimeCards.Columns.Add("Money Earned", 100);
    }

    private void buttonTimerStart_Click(object sender, EventArgs e)
    {
        timerStartTime = DateTime.Now;
        timerUpdateTimerText.Start();
        buttonTimerStart.Enabled = false;
        buttonTimerPause.Enabled = true;
    }

    private void timerUpdateTimerText_Tick(object sender, EventArgs e)
    {
        labelTimerDisplay.Text = $"{(int)elapsedTime.TotalHours}:{(int)elapsedTime.TotalMinutes}{elapsedTime.TotalSeconds.ToString("F2")}";
    }

    private void buttonTimerPause_Click(object sender, EventArgs e)
    {
        buttonTimerStart.Enabled = true;
        buttonTimerPause.Enabled = false;

        timerUpdateTimerText.Stop();
        currentJobTimeCard.TimeSpentWorking += elapsedTime;

        // Check if the TimeCard already exists
        var existingTimeCard = timeCards.FirstOrDefault(tc => tc.ProjectName == currentJobTimeCard.ProjectName);
        if(existingTimeCard != null)
        {
            // Update existing TimeCard
            existingTimeCard.TimeSpentWorking = currentJobTimeCard.TimeSpentWorking;
        }
        else
        {
            // Add new TimeCard to the list
            timeCards.Add(currentJobTimeCard);
        }

        RefreshListView();
    }

    private void RefreshListView()
    {
        listViewTimeCards.Items.Clear(); // Clear existing items

        foreach(var timeCard in timeCards)
        {
            var listViewItem = new ListViewItem(new[] {
            timeCard.ProjectName,
            timeCard.HourlyRate.ToString("F2"),
            timeCard.TimeSpentWorking.ToString(),
            timeCard.MoneyEarned.ToString("F2")
        });

            listViewTimeCards.Items.Add(listViewItem); // Add new ListViewItem to the ListView
        }
    }


    private void buttonStartNewJob_Click(object sender, EventArgs e)
    {
        using(var jobStartedForm = new JobStarter())
        {
            if(jobStartedForm.ShowDialog() == DialogResult.OK)
            {
                decimal hourlyRate = jobStartedForm.HourlyRate;
                string projectName = jobStartedForm.ProjectName;

                currentJobTimeCard = new();
                currentJobTimeCard.ProjectName = projectName;
                currentJobTimeCard.HourlyRate = hourlyRate;

                buttonTimerStart.Enabled = true;
                buttonTimerComplete.Enabled = true;
                buttonTimerReset.Enabled = true;
            }
        }
    }
}

public class TimeCard
{
    public decimal HourlyRate { get; set; }
    public string ProjectName { get; set; }
    public TimeSpan TimeSpentWorking { get; set; } = new();
    public decimal MoneyEarned => HourlyRate * (decimal)TimeSpentWorking.TotalHours;
}


