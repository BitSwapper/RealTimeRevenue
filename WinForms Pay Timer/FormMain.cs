using System.Reflection;

namespace WinForms_Pay_Timer;

public partial class FormMain : Form
{
    DateTime timerStartTime;
    TimeSpan elapsedTime => DateTime.Now - timerStartTime;

    TimeCard currentJobTimeCard;
    List<TimeCard> timeCardsThisJob = new();
    List<TimeCard> timeCardsCompletedJobs = new();
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
        listViewTimeCards.Columns.Add("Start Time", 100);
        listViewTimeCards.Columns.Add("Stop Time", 100);


        listViewCompletedJobs.View = View.Details;
        listViewCompletedJobs.GridLines = true;
        listViewCompletedJobs.FullRowSelect = true;

        listViewCompletedJobs.Columns.Add("Project Name", 120);
        listViewCompletedJobs.Columns.Add("Hourly Rate", 80);
        listViewCompletedJobs.Columns.Add("Time Spent", 100);
        listViewCompletedJobs.Columns.Add("Money Earned", 100);

        Type listViewType = typeof(ListView);
        PropertyInfo doubleBufferedProperty = listViewType.GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic);
        doubleBufferedProperty.SetValue(listViewTimeCards, true, null);
        doubleBufferedProperty.SetValue(listViewCompletedJobs, true, null);
    }

    void buttonTimerStart_Click(object sender, EventArgs e)
    {
        timerStartTime = DateTime.Now;
        timerUpdateTimerText.Start();
        buttonTimerStart.Enabled = false;
        buttonTimerPause.Enabled = true;
        buttonStartNewJob.Enabled = false;
        buttonTimerComplete.Enabled = true;
        buttonTimerReset.Enabled = true;
    }

    void timerUpdateTimerText_Tick(object sender, EventArgs e)
    {
        labelTimerDisplay.Text = FormatTime(elapsedTime);

        var totalEarnedThisJob = (timeCardsThisJob.Sum((t) => t.MoneyEarned) + currentJobTimeCard.HourlyRate * (decimal)elapsedTime.TotalHours);
        var totalEarnedOnCompletedJobs = (timeCardsCompletedJobs.Sum((t) => t.MoneyEarned));
        var GrandTotal = totalEarnedThisJob + totalEarnedOnCompletedJobs;

        labelMoneyEarned.Text = "$" + totalEarnedThisJob.ToString("F2");
        labelGrandTotal.Text = "$" + GrandTotal.ToString("F2");

        RefreshListView();
    }

    void buttonTimerPause_Click(object sender, EventArgs e)
    {
        buttonTimerStart.Enabled = true;
        buttonTimerPause.Enabled = false;

        timerUpdateTimerText.Stop();
        TimeCard newTimeCard = CreateTimecardForCurJob();

        timeCardsThisJob.Add(newTimeCard);

        RefreshListView();
    }

    private TimeCard CreateTimecardForCurJob() => new TimeCard
    {
        ProjectName = currentJobTimeCard.ProjectName,
        HourlyRate = currentJobTimeCard.HourlyRate,
        TimeSpentWorking = elapsedTime,
        StartTime = timerStartTime,
        StopTime = DateTime.Now
    };

    void RefreshListView()
    {
        listViewTimeCards.Items.Clear();

        foreach(var timeCard in timeCardsThisJob.OrderByDescending(tc => tc.StopTime))
        {
            var listViewItem = new ListViewItem(new[] {
            timeCard.ProjectName,
            timeCard.HourlyRate.ToString("F2"),
            FormatTime(timeCard.TimeSpentWorking),
            timeCard.MoneyEarned.ToString("F2"),
            timeCard.StartTime.ToString("MM-dd   HH:mm:ss"),
            timeCard.StopTime.ToString("MM-dd   HH:mm:ss")
        });

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
                buttonTimerComplete.Enabled = false;
                buttonTimerReset.Enabled = false;
            }
        }
    }
    private void buttonTimerComplete_Click(object sender, EventArgs e)
    {
        buttonTimerPause.PerformClick();


        timerUpdateTimerText.Stop();

        buttonStartNewJob.Enabled = true;
        buttonTimerPause.Enabled = false;
        buttonTimerReset.Enabled = false;
        buttonTimerStart.Enabled = false;
        buttonTimerComplete.Enabled = false;

        

        //if(timeCardsThisJob.Count == 0)
        //{
        //    currentJobTimeCard = CreateTimecardForCurJob();
        //    timeCardsThisJob.Add(currentJobTimeCard);
        //}

        var combinedTimeCard = new TimeCard
        {
            ProjectName = timeCardsThisJob.First().ProjectName,
            HourlyRate = timeCardsThisJob.First().HourlyRate,
            TimeSpentWorking = TimeSpan.FromTicks(timeCardsThisJob.Sum(tc => tc.TimeSpentWorking.Ticks)),
            StartTime = timeCardsThisJob.Min(tc => tc.StartTime),
            StopTime = timeCardsThisJob.Max(tc => tc.StopTime),
        };

        var listViewItem = new ListViewItem(new[] {
        combinedTimeCard.ProjectName,
        combinedTimeCard.HourlyRate.ToString("F2"),
        FormatTime(combinedTimeCard.TimeSpentWorking),
        combinedTimeCard.MoneyEarned.ToString("F2")});

        listViewCompletedJobs.Items.Add(listViewItem);
        listViewTimeCards.Items.Clear();

        timeCardsCompletedJobs.Add(combinedTimeCard);
        timeCardsThisJob.Clear();

        currentJobTimeCard = new();
    }

    private string FormatTime(TimeSpan elapsedTime) => $"{((int)elapsedTime.TotalHours).ToString("D2")}:{((int)elapsedTime.TotalMinutes % 60).ToString("D2")}:{(elapsedTime.TotalSeconds % 60).ToString("00")}";
}