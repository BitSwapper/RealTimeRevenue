namespace WinForms_Pay_Timer;

public class State_Started : BaseState<StateManager>
{
    public override void EnterState(StateManager stateManager)
    {
        stateManager.Form.TimeKeeper.TimerStartTime = DateTime.Now;
        stateManager.Form.ButtonTimerStart.Enabled = false;
        stateManager.Form.ButtonTimerPause.Enabled = true;
        stateManager.Form.ButtonStartNewJob.Enabled = false;
        stateManager.Form.ButtonTimerComplete.Enabled = true;
        stateManager.Form.ButtonTimerReset.Enabled = true;
    }
    public override void ExitState(StateManager stateManager) { }
    public override void UpdateState(StateManager stateManager) 
    {
        var totalEarnedThisJob = (stateManager.Form.TimeKeeper.TimeCardsThisJob.Sum((t) => t.MoneyEarned) + stateManager.Form.TimeKeeper.CurrentJobTimeCard.HourlyRate * (decimal)stateManager.Form.TimeKeeper.ElapsedTime.TotalHours);
        var totalEarnedOnCompletedJobs = (stateManager.Form.TimeKeeper.TimeCardsCompletedJobs.Sum((t) => t.MoneyEarned));
        var GrandTotal = totalEarnedThisJob + totalEarnedOnCompletedJobs;

        stateManager.Form.LabelTimerDisplay.Text = TimeUtil.FormatTime(stateManager.Form.TimeKeeper.ElapsedTime);
        stateManager.Form.LabelMoneyEarned.Text = "$" + totalEarnedThisJob.ToString("F2");
        stateManager.Form.LabelGrandTotal.Text = "$" + GrandTotal.ToString("F2");
    }
}
