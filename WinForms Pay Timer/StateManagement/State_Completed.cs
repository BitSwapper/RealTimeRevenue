using WinForms_Pay_Timer.TimeManagement;

namespace WinForms_Pay_Timer.StateManagement;

public class State_Completed : BaseState<StateManager>
{
    public override void EnterState(StateManager stateManager)
    {
        stateManager.Form.ButtonTimerPause.PerformClick();

        stateManager.Form.ButtonStartNewJob.Enabled = true;
        stateManager.Form.ButtonTimerPause.Enabled = false;
        stateManager.Form.ButtonTimerReset.Enabled = false;
        stateManager.Form.ButtonTimerStart.Enabled = false;
        stateManager.Form.ButtonTimerComplete.Enabled = false;

        stateManager.Form.LabelMoneyEarned.Text = FormMainConstants.DefaultValueForMoneyDisplay;
        stateManager.Form.LabelTimerDisplay.Text = FormMainConstants.DefaultValueForTimerDisplay;

        var filteredJobs = stateManager.Form.TimeKeeper.TimeCardsThisJob.Where((t) => t.TimeSpentWorking.TotalMilliseconds > 100).ToList();

        if (filteredJobs.Count == 0) return;

        var combinedTimeCard = new TimeCard
        {
            ProjectName = stateManager.Form.TimeKeeper.TimeCardsThisJob.First().ProjectName,
            HourlyRate = stateManager.Form.TimeKeeper.TimeCardsThisJob.First().HourlyRate,
            TimeSpentWorking = TimeSpan.FromTicks(stateManager.Form.TimeKeeper.TimeCardsThisJob.Sum(tc => tc.TimeSpentWorking.Ticks)),
            StartTime = stateManager.Form.TimeKeeper.TimeCardsThisJob.Min(tc => tc.StartTime),
            StopTime = stateManager.Form.TimeKeeper.TimeCardsThisJob.Max(tc => tc.StopTime),
        };

        var listViewItem = new ListViewItem(new[] {
        combinedTimeCard.ProjectName,
        combinedTimeCard.HourlyRate.ToString("F2"),
        TimeUtil.FormatTime(combinedTimeCard.TimeSpentWorking),
        combinedTimeCard.MoneyEarned.ToString("F2")});

        stateManager.Form.ListViewCompletedJobs.Items.Add(listViewItem);
        stateManager.Form.ListViewTimeCards.Items.Clear();

        stateManager.Form.TimeKeeper.TimeCardsCompletedJobs.Add(combinedTimeCard);
        stateManager.Form.TimeKeeper.TimeCardsThisJob.Clear();

        stateManager.Form.TimeKeeper.CurrentJobTimeCard = new();
    }
    public override void ExitState(StateManager stateManager) { }
    public override void UpdateState(StateManager stateManager) { }
}
