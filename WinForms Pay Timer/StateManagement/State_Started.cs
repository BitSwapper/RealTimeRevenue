using RealTime_Revenue.Misc;
using RealTime_Revenue.TimeManagement;

namespace RealTime_Revenue.StateManagement;

public class State_Started : BaseState<StateManager>
{
    public override void EnterState(StateManager stateManager)
    {
        var timeKeeper = stateManager.Form.TimeKeeper;
        timeKeeper.TimerStartTime = DateTime.Now;
        ToggleButtonStates(stateManager);
        SetupCurrentTimecardIfFirstEntry(stateManager);
        stateManager.Form.ListViewCurrentJobTimeCards.Scrollable = false;


        static void ToggleButtonStates(StateManager stateManager)
        {
            stateManager.Form.ButtonTimerStart.Enabled = false;
            stateManager.Form.ButtonTimerPause.Enabled = true;
            stateManager.Form.ButtonStartNewJob.Enabled = false;
            stateManager.Form.ButtonTimerComplete.Enabled = true;
            stateManager.Form.ButtonTimerReset.Enabled = true;
        }

        void SetupCurrentTimecardIfFirstEntry(StateManager stateManager)
        {
            if(stateManager.Form.ListViewCurrentJobTimeCards.Items.Count == 0)
            {
                timeKeeper.CurrentJobTimeCard.StartTime = DateTime.Now;
                timeKeeper.CurrentJobTimeCard.TimeSpentWorking = timeKeeper.ElapsedTime;
                ListViewRefresher.RefreshListView(stateManager.Form.ListViewCurrentJobTimeCards, true, timeKeeper);
            }
        }
    }

    public override void ExitState(StateManager stateManager) => stateManager.Form.ListViewCurrentJobTimeCards.Scrollable = true;

    public override void UpdateState(StateManager stateManager)
    {
        var timeKeeper = stateManager.Form.TimeKeeper;

        var totalEarnedThisJob = timeKeeper.TimeCardsThisJob.Sum((t) => t.MoneyEarned) + timeKeeper.CurrentJobTimeCard.HourlyRate * (decimal)timeKeeper.ElapsedTime.TotalHours;
        var totalEarnedOnCompletedJobs = timeKeeper.TimeCardsCompletedJobs.Sum((t) => t.MoneyEarned);
        var GrandTotal = totalEarnedThisJob + totalEarnedOnCompletedJobs;

        TimeSpan timeSpentOnCompletedJobs = timeKeeper.TimeCardsCompletedJobs.Aggregate(new TimeSpan(), (total, job) => total + job.TimeSpentWorking);
        
        UpdateTextLabels(stateManager, totalEarnedThisJob, GrandTotal, timeSpentOnCompletedJobs);
        ListViewRefresher.RefreshListView(stateManager.Form.ListViewCurrentJobTimeCards, true, timeKeeper);

        static void UpdateTextLabels(StateManager stateManager, decimal totalEarnedThisJob, decimal GrandTotal, TimeSpan timeSpentOnCompletedJobs)
        {
            stateManager.Form.LabelTimerDisplay.Text = TimeUtil.FormatTime(stateManager.Form.TimeKeeper.ElapsedTime);
            stateManager.Form.LabelTimerDisplayGrandTotal.Text = TimeUtil.FormatTime(stateManager.Form.TimeKeeper.ElapsedTime + timeSpentOnCompletedJobs);
            stateManager.Form.LabelMoneyEarned.Text = "$" + totalEarnedThisJob.ToString("F2");
            stateManager.Form.LabelGrandTotal.Text = "$" + GrandTotal.ToString("F2");
            stateManager.Form.TimeKeeper.CurrentJobTimeCard.TimeSpentWorking = stateManager.Form.TimeKeeper.ElapsedTime;
        }
    }
}
