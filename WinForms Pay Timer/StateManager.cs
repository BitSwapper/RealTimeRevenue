namespace WinForms_Pay_Timer;

public class StateManager
{
    public enum States { Started, Paused, Completed, Reset }
    States currentState = States.Completed;

    public FormMain form;

    public StateManager(FormMain form) => this.form = form;

    Dictionary<States, BaseState<StateManager>> concreteStates = new()
    {
        {States.Started, new State_Started() },
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
        stateManager.form.ButtonCancelJob.Enabled = true;
    }
    public override void ExitState(StateManager stateManager) { }
    public override void FixedUpdateState(StateManager stateManager) { }
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
    public override void FixedUpdateState(StateManager stateManager) { }
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
        stateManager.form.ButtonCancelJob.Enabled = false;

        stateManager.form.LabelMoneyEarned.Text = FormMainConstants.DefaultValueForMoneyDisplay;
        stateManager.form.LabelTimerDisplay.Text = FormMainConstants.DefaultValueForTimerDisplay;

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
    public override void FixedUpdateState(StateManager stateManager) { }
    public override void UpdateState(StateManager stateManager) { }
}

public class State_Reset : BaseState<StateManager>
{
    public override void EnterState(StateManager stateManager) { }
    public override void ExitState(StateManager stateManager) { }
    public override void FixedUpdateState(StateManager stateManager) { }
    public override void UpdateState(StateManager stateManager) { }
}