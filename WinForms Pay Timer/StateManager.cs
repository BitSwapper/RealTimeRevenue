namespace WinForms_Pay_Timer;

public class StateManager
{
    public enum States { InitialzingProgram, Started, InitNewJob, Paused, Completed, Reset }
    States currentState = States.InitialzingProgram;

    public FormMain Form { get; }

    public StateManager(FormMain form) => this.Form = form;

    Dictionary<States, BaseState<StateManager>> concreteStates = new()
    {
        {States.Started, new State_Started() },
        {States.InitialzingProgram, new State_InitProgram() },
        {States.InitNewJob, new State_InitNewJob() },
        {States.Paused, new State_Paused() },
        {States.Completed, new State_Completed() },
        {States.Reset, new State_Reset()}
    };

    public void SwapState(States state)
    {
        concreteStates[currentState].ExitState(this);
        currentState = state;
        concreteStates[currentState].EnterState(this);
    }

    public void UpdateState() => concreteStates[currentState].UpdateState(this);

    public void Initialize() => concreteStates[currentState].EnterState(this);
}

public class State_Started : BaseState<StateManager>
{
    public override void EnterState(StateManager stateManager)
    {
        stateManager.Form.TimerStartTime = DateTime.Now;
        stateManager.Form.TimerUpdateTimerText.Start();
        stateManager.Form.ButtonTimerStart.Enabled = false;
        stateManager.Form.ButtonTimerPause.Enabled = true;
        stateManager.Form.ButtonStartNewJob.Enabled = false;
        stateManager.Form.ButtonTimerComplete.Enabled = true;
        stateManager.Form.ButtonTimerReset.Enabled = true;
    }
    public override void ExitState(StateManager stateManager) { }
    public override void UpdateState(StateManager stateManager) 
    {
        var totalEarnedThisJob = (stateManager.Form.TimeCardsThisJob.Sum((t) => t.MoneyEarned) + stateManager.Form.CurrentJobTimeCard.HourlyRate * (decimal)stateManager.Form.ElapsedTime.TotalHours);
        var totalEarnedOnCompletedJobs = (stateManager.Form.TimeCardsCompletedJobs.Sum((t) => t.MoneyEarned));
        var GrandTotal = totalEarnedThisJob + totalEarnedOnCompletedJobs;

        stateManager.Form.LabelTimerDisplay.Text = TimeUtil.FormatTime(stateManager.Form.ElapsedTime);
        stateManager.Form.LabelMoneyEarned.Text = "$" + totalEarnedThisJob.ToString("F2");
        stateManager.Form.LabelGrandTotal.Text = "$" + GrandTotal.ToString("F2");
    }
}

public class State_Paused : BaseState<StateManager>
{
    public override void EnterState(StateManager stateManager)
    {
        stateManager.Form.ButtonTimerStart.Enabled = true;
        stateManager.Form.ButtonTimerPause.Enabled = false;

        stateManager.Form.TimerUpdateTimerText.Stop();
        TimeCard newTimeCard = stateManager.Form.CreateTimecardForCurJob();

        stateManager.Form.TimeCardsThisJob.Add(newTimeCard);

        stateManager.Form.RefreshListView();
    }
    public override void ExitState(StateManager stateManager) { }
    public override void UpdateState(StateManager stateManager) { }
}

public class State_Completed : BaseState<StateManager>
{
    public override void EnterState(StateManager stateManager)
    {
        stateManager.Form.ButtonTimerPause.PerformClick();

        stateManager.Form.TimerUpdateTimerText.Stop();
        stateManager.Form.ButtonStartNewJob.Enabled = true;
        stateManager.Form.ButtonTimerPause.Enabled = false;
        stateManager.Form.ButtonTimerReset.Enabled = false;
        stateManager.Form.ButtonTimerStart.Enabled = false;
        stateManager.Form.ButtonTimerComplete.Enabled = false;

        stateManager.Form.LabelMoneyEarned.Text = FormMainConstants.DefaultValueForMoneyDisplay;
        stateManager.Form.LabelTimerDisplay.Text = FormMainConstants.DefaultValueForTimerDisplay;

        var filteredJobs = stateManager.Form.TimeCardsThisJob.Where((t) => t.TimeSpentWorking.TotalMilliseconds > 100).ToList();

        if(filteredJobs.Count == 0) return;

        var combinedTimeCard = new TimeCard
        {
            ProjectName = stateManager.Form.TimeCardsThisJob.First().ProjectName,
            HourlyRate = stateManager.Form.TimeCardsThisJob.First().HourlyRate,
            TimeSpentWorking = TimeSpan.FromTicks(stateManager.Form.TimeCardsThisJob.Sum(tc => tc.TimeSpentWorking.Ticks)),
            StartTime = stateManager.Form.TimeCardsThisJob.Min(tc => tc.StartTime),
            StopTime = stateManager.Form.TimeCardsThisJob.Max(tc => tc.StopTime),
        };

        var listViewItem = new ListViewItem(new[] {
        combinedTimeCard.ProjectName,
        combinedTimeCard.HourlyRate.ToString("F2"),
        TimeUtil.FormatTime(combinedTimeCard.TimeSpentWorking),
        combinedTimeCard.MoneyEarned.ToString("F2")});

        stateManager.Form.ListViewCompletedJobs.Items.Add(listViewItem);
        stateManager.Form.ListViewTimeCards.Items.Clear();

        stateManager.Form.TimeCardsCompletedJobs.Add(combinedTimeCard);
        stateManager.Form.TimeCardsThisJob.Clear();

        stateManager.Form.CurrentJobTimeCard = new();
    }
    public override void ExitState(StateManager stateManager) { }
    public override void UpdateState(StateManager stateManager) { }
}

public class State_Reset : BaseState<StateManager>
{
    public override void EnterState(StateManager stateManager)
    {
        stateManager.Form.TimerUpdateTimerText.Stop();
        stateManager.Form.LabelTimerDisplay.Text = FormMainConstants.DefaultValueForTimerDisplay;
        stateManager.Form.LabelMoneyEarned.Text = FormMainConstants.DefaultValueForMoneyDisplay;
        stateManager.Form.LabelGrandTotal.Text = FormMainConstants.DefaultValueForMoneyDisplay;

        stateManager.Form.TimeCardsThisJob.Clear();
        stateManager.Form.ListViewTimeCards.Clear();

        stateManager.Form.CurrentJobTimeCard = new();
        stateManager.Form.TimerStartTime = DateTime.Now;
        stateManager.SwapState(StateManager.States.Completed);
    }
    public override void ExitState(StateManager stateManager) { }
    public override void UpdateState(StateManager stateManager) { }
}

public class State_InitNewJob : BaseState<StateManager>
{
    public override void EnterState(StateManager stateManager)
    {
        using(var jobStartedForm = new JobStarter())
        {
            if(jobStartedForm.ShowDialog() == DialogResult.OK)
            {
                decimal hourlyRate = jobStartedForm.HourlyRate;
                string projectName = jobStartedForm.ProjectName;

                stateManager.Form.CurrentJobTimeCard = new();
                stateManager.Form.CurrentJobTimeCard.ProjectName = projectName;
                stateManager.Form.CurrentJobTimeCard.HourlyRate = hourlyRate;
                stateManager.Form.ButtonTimerStart.Enabled = true;
                stateManager.Form.ButtonTimerComplete.Enabled = false;
                stateManager.Form.ButtonTimerReset.Enabled = false;
            }
        }
    }
    public override void ExitState(StateManager stateManager) { }
    public override void UpdateState(StateManager stateManager) { }
}

public class State_InitProgram : BaseState<StateManager>
{
    public override void EnterState(StateManager stateManager)
    {
        stateManager.Form.ListViewTimeCards.View = View.Details;
        stateManager.Form.ListViewTimeCards.GridLines = true;
        stateManager.Form.ListViewTimeCards.FullRowSelect = true;
        stateManager.Form.ListViewTimeCards.Columns.Add("Project Name", FormMainConstants.ProjectNameColumnWidth);
        stateManager.Form.ListViewTimeCards.Columns.Add("Hourly Rate", FormMainConstants.HourlyRateColumnWidth);
        stateManager.Form.ListViewTimeCards.Columns.Add("Time Spent", FormMainConstants.TimeSpentColumnWidth);
        stateManager.Form.ListViewTimeCards.Columns.Add("Money Earned", FormMainConstants.MoneyEarnedColumnWidth);
        stateManager.Form.ListViewTimeCards.Columns.Add("Start Time", FormMainConstants.StartTimeColumnWidth);
        stateManager.Form.ListViewTimeCards.Columns.Add("Stop Time", FormMainConstants.StopTimeColumnWidth);

        stateManager.Form.ListViewCompletedJobs.View = View.Details;
        stateManager.Form.ListViewCompletedJobs.GridLines = true;
        stateManager.Form.ListViewCompletedJobs.FullRowSelect = true;
        stateManager.Form.ListViewCompletedJobs.Columns.Add("Project Name", FormMainConstants.ProjectNameColumnWidth);
        stateManager.Form.ListViewCompletedJobs.Columns.Add("Hourly Rate", FormMainConstants.HourlyRateColumnWidth);
        stateManager.Form.ListViewCompletedJobs.Columns.Add("Time Spent", FormMainConstants.TimeSpentColumnWidth);
        stateManager.Form.ListViewCompletedJobs.Columns.Add("Money Earned", FormMainConstants.MoneyEarnedColumnWidth);
    }
    public override void ExitState(StateManager stateManager) { }
    public override void UpdateState(StateManager stateManager) { }
}
