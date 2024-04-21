namespace WinForms_Pay_Timer;

public class StateManager
{
    public enum States { InitialzingProgram, Started, InitNewJob, Paused, Completed, Reset }
    States currentState = States.InitialzingProgram;

    public FormMain form;

    public StateManager(FormMain form) => this.form = form;

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
        stateManager.form.TimerStartTime = DateTime.Now;
        stateManager.form.TimerUpdateTimerText.Start();
        stateManager.form.ButtonTimerStart.Enabled = false;
        stateManager.form.ButtonTimerPause.Enabled = true;
        stateManager.form.ButtonStartNewJob.Enabled = false;
        stateManager.form.ButtonTimerComplete.Enabled = true;
        stateManager.form.ButtonTimerReset.Enabled = true;
    }
    public override void ExitState(StateManager stateManager) { }
    public override void UpdateState(StateManager stateManager) { }
}

public class State_Paused : BaseState<StateManager>
{
    public override void EnterState(StateManager stateManager)
    {
        stateManager.form.ButtonTimerStart.Enabled = true;
        stateManager.form.ButtonTimerPause.Enabled = false;

        stateManager.form.TimerUpdateTimerText.Stop();
        TimeCard newTimeCard = stateManager.form.CreateTimecardForCurJob();

        stateManager.form.TimeCardsThisJob.Add(newTimeCard);

        stateManager.form.RefreshListView();
    }
    public override void ExitState(StateManager stateManager) { }
    public override void UpdateState(StateManager stateManager) { }
}

public class State_Completed : BaseState<StateManager>
{
    public override void EnterState(StateManager stateManager)
    {
        stateManager.form.ButtonTimerPause.PerformClick();

        stateManager.form.TimerUpdateTimerText.Stop();
        stateManager.form.ButtonStartNewJob.Enabled = true;
        stateManager.form.ButtonTimerPause.Enabled = false;
        stateManager.form.ButtonTimerReset.Enabled = false;
        stateManager.form.ButtonTimerStart.Enabled = false;
        stateManager.form.ButtonTimerComplete.Enabled = false;

        stateManager.form.LabelMoneyEarned.Text = FormMainConstants.DefaultValueForMoneyDisplay;
        stateManager.form.LabelTimerDisplay.Text = FormMainConstants.DefaultValueForTimerDisplay;

        var filteredJobs = stateManager.form.TimeCardsThisJob.Where((t) => t.TimeSpentWorking.TotalMilliseconds > 100).ToList();

        if(filteredJobs.Count == 0) return;

        var combinedTimeCard = new TimeCard
        {
            ProjectName = stateManager.form.TimeCardsThisJob.First().ProjectName,
            HourlyRate = stateManager.form.TimeCardsThisJob.First().HourlyRate,
            TimeSpentWorking = TimeSpan.FromTicks(stateManager.form.TimeCardsThisJob.Sum(tc => tc.TimeSpentWorking.Ticks)),
            StartTime = stateManager.form.TimeCardsThisJob.Min(tc => tc.StartTime),
            StopTime = stateManager.form.TimeCardsThisJob.Max(tc => tc.StopTime),
        };

        var listViewItem = new ListViewItem(new[] {
        combinedTimeCard.ProjectName,
        combinedTimeCard.HourlyRate.ToString("F2"),
        TimeUtil.FormatTime(combinedTimeCard.TimeSpentWorking),
        combinedTimeCard.MoneyEarned.ToString("F2")});

        stateManager.form.ListViewCompletedJobs.Items.Add(listViewItem);
        stateManager.form.ListViewTimeCards.Items.Clear();

        stateManager.form.TimeCardsCompletedJobs.Add(combinedTimeCard);
        stateManager.form.TimeCardsThisJob.Clear();

        stateManager.form.CurrentJobTimeCard = new();
    }
    public override void ExitState(StateManager stateManager) { }
    public override void UpdateState(StateManager stateManager) { }
}

public class State_Reset : BaseState<StateManager>
{
    public override void EnterState(StateManager stateManager)
    {

        stateManager.form.TimerUpdateTimerText.Stop();
        stateManager.form.LabelTimerDisplay.Text = FormMainConstants.DefaultValueForTimerDisplay;
        stateManager.form.LabelMoneyEarned.Text = FormMainConstants.DefaultValueForMoneyDisplay;
        stateManager.form.LabelGrandTotal.Text = FormMainConstants.DefaultValueForMoneyDisplay;

        stateManager.form.TimeCardsThisJob.Clear();
        stateManager.form.ListViewTimeCards.Clear();

        stateManager.form.CurrentJobTimeCard = new();
        stateManager.form.TimerStartTime = DateTime.Now;
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

                stateManager.form.CurrentJobTimeCard = new();
                stateManager.form.CurrentJobTimeCard.ProjectName = projectName;
                stateManager.form.CurrentJobTimeCard.HourlyRate = hourlyRate;
                stateManager.form.ButtonTimerStart.Enabled = true;
                stateManager.form.ButtonTimerComplete.Enabled = false;
                stateManager.form.ButtonTimerReset.Enabled = false;
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
        stateManager.form.ListViewTimeCards.View = View.Details;
        stateManager.form.ListViewTimeCards.GridLines = true;
        stateManager.form.ListViewTimeCards.FullRowSelect = true;
        stateManager.form.ListViewTimeCards.Columns.Add("Project Name", FormMainConstants.ProjectNameColumnWidth);
        stateManager.form.ListViewTimeCards.Columns.Add("Hourly Rate", FormMainConstants.HourlyRateColumnWidth);
        stateManager.form.ListViewTimeCards.Columns.Add("Time Spent", FormMainConstants.TimeSpentColumnWidth);
        stateManager.form.ListViewTimeCards.Columns.Add("Money Earned", FormMainConstants.MoneyEarnedColumnWidth);
        stateManager.form.ListViewTimeCards.Columns.Add("Start Time", FormMainConstants.StartTimeColumnWidth);
        stateManager.form.ListViewTimeCards.Columns.Add("Stop Time", FormMainConstants.StopTimeColumnWidth);

        stateManager.form.ListViewCompletedJobs.View = View.Details;
        stateManager.form.ListViewCompletedJobs.GridLines = true;
        stateManager.form.ListViewCompletedJobs.FullRowSelect = true;
        stateManager.form.ListViewCompletedJobs.Columns.Add("Project Name", FormMainConstants.ProjectNameColumnWidth);
        stateManager.form.ListViewCompletedJobs.Columns.Add("Hourly Rate", FormMainConstants.HourlyRateColumnWidth);
        stateManager.form.ListViewCompletedJobs.Columns.Add("Time Spent", FormMainConstants.TimeSpentColumnWidth);
        stateManager.form.ListViewCompletedJobs.Columns.Add("Money Earned", FormMainConstants.MoneyEarnedColumnWidth);
    }
    public override void ExitState(StateManager stateManager) { }
    public override void UpdateState(StateManager stateManager) { }
}
