using RealTime_Revenue.TimeManagement;
using RealTime_Revenue.Misc;

namespace RealTime_Revenue.StateManagement;

public class State_Completed : BaseState<StateManager>
{
    public override void EnterState(StateManager stateManager)
    {
        stateManager.Form.ButtonTimerPause.PerformClick();
        ToggleButtonStates(stateManager);
        ResetCashLabels(stateManager);

        var filteredJobs = stateManager.Form.TimeKeeper.TimeCardsThisJob.Where((t) => t.TimeSpentWorking.TotalMilliseconds > 100).ToList();
        if(filteredJobs.Count == 0) return;
        TimeCard combinedTimeCard = GetTotalJobCombinedTimeCard(stateManager);
        ListViewItem listViewItem = GetLviForTimeCard(combinedTimeCard);
        RemoveCurrentJobDataAndAddCompletedJob(stateManager, combinedTimeCard, listViewItem);


        static void ToggleButtonStates(StateManager stateManager)
        {
            stateManager.Form.ButtonStartNewJob.Enabled = true;
            stateManager.Form.ButtonTimerPause.Enabled = false;
            stateManager.Form.ButtonTimerReset.Enabled = false;
            stateManager.Form.ButtonTimerStart.Enabled = false;
            stateManager.Form.ButtonTimerComplete.Enabled = false;
        }

        static void ResetCashLabels(StateManager stateManager)
        {
            stateManager.Form.LabelMoneyEarned.Text = FormMainConstants.DefaultValueForMoneyDisplay;
            stateManager.Form.LabelTimerDisplay.Text = FormMainConstants.DefaultValueForTimerDisplay;
        }

        static TimeCard GetTotalJobCombinedTimeCard(StateManager stateManager) => new TimeCard
        {
            JobName = stateManager.Form.TimeKeeper.TimeCardsThisJob.First().JobName,
            HourlyRate = stateManager.Form.TimeKeeper.TimeCardsThisJob.First().HourlyRate,
            TimeSpentWorking = TimeSpan.FromTicks(stateManager.Form.TimeKeeper.TimeCardsThisJob.Sum(tc => tc.TimeSpentWorking.Ticks)),
            StartTime = stateManager.Form.TimeKeeper.TimeCardsThisJob.Min(tc => tc.StartTime),
            StopTime = stateManager.Form.TimeKeeper.TimeCardsThisJob.Max(tc => tc.StopTime),
        };

        static ListViewItem GetLviForTimeCard(TimeCard combinedTimeCard) => new ListViewItem(new[] {
        combinedTimeCard.JobName,
        combinedTimeCard.MoneyEarned.ToString("F2"),
        combinedTimeCard.HourlyRate.ToString("F2"),
        TimeUtil.FormatTime(combinedTimeCard.TimeSpentWorking),});

        static void RemoveCurrentJobDataAndAddCompletedJob(StateManager stateManager, TimeCard combinedTimeCard, ListViewItem listViewItem)
        {
            stateManager.Form.ListViewCompletedJobs.Items.Add(listViewItem);
            stateManager.Form.ListViewCurrentJobTimeCards.Items.Clear();
            stateManager.Form.TimeKeeper.TimeCardsCompletedJobs.Add(combinedTimeCard);
            stateManager.Form.TimeKeeper.TimeCardsThisJob.Clear();
            stateManager.Form.TimeKeeper.CurrentJobTimeCard = new();
        }
    }
    public override void ExitState(StateManager stateManager) { }
    public override void UpdateState(StateManager stateManager) { }
}
