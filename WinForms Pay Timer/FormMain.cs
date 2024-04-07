namespace WinForms_Pay_Timer;

public partial class FormMain : Form
{
    DateTime timerStartTime;
    TimeSpan elapsedTime => DateTime.Now - timerStartTime;

    TimeCard currentJobTimeCard;
    List<TimeCard> timeCards = new();
    public FormMain() => InitializeComponent();

    void FormMain_Load(object sender, EventArgs e)
    {
        listViewTimeCards.View = View.Details;
        listViewTimeCards.GridLines = true;
        listViewTimeCards.FullRowSelect = true;

        listViewTimeCards.Columns.Add("Project Name", 120);
        listViewTimeCards.Columns.Add("Hourly Rate", 80);
        listViewTimeCards.Columns.Add("Time Spent", 100);
        listViewTimeCards.Columns.Add("Money Earned", 100);
    }

    void buttonTimerStart_Click(object sender, EventArgs e)
    {
        timerStartTime = DateTime.Now;
        timerUpdateTimerText.Start();
        buttonTimerStart.Enabled = false;
        buttonTimerPause.Enabled = true;
    }

    void timerUpdateTimerText_Tick(object sender, EventArgs e)
    {
        labelTimerDisplay.Text = $"{((int)elapsedTime.TotalHours).ToString("D2")}:{((int)elapsedTime.TotalMinutes % 60).ToString("D2")}:{(elapsedTime.TotalSeconds % 60).ToString("00")}";
        labelMoneyEarned.Text = "$" + (timeCards.Sum((t) => t.MoneyEarned) + currentJobTimeCard.HourlyRate * (decimal)elapsedTime.TotalHours).ToString("F2");
    }

    void buttonTimerPause_Click(object sender, EventArgs e)
    {
        buttonTimerStart.Enabled = true;
        buttonTimerPause.Enabled = false;

        timerUpdateTimerText.Stop();
        currentJobTimeCard.TimeSpentWorking += elapsedTime;

        var existingTimeCard = timeCards.FirstOrDefault(tc => tc.ProjectName == currentJobTimeCard.ProjectName);
        if(existingTimeCard != null)
            existingTimeCard.TimeSpentWorking = currentJobTimeCard.TimeSpentWorking;
        else
            timeCards.Add(currentJobTimeCard);

        RefreshListView();
    }

    void RefreshListView()
    {
        listViewTimeCards.Items.Clear();

        foreach(var timeCard in timeCards)
        {
            var listViewItem = new ListViewItem(new[] {
            timeCard.ProjectName,
            timeCard.HourlyRate.ToString("F2"),
            timeCard.TimeSpentWorking.ToString(),
            timeCard.MoneyEarned.ToString("F2")});

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
