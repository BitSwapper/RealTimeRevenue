namespace WinForms_Pay_Timer;

public class State_Reset : BaseState<StateManager>
{
    public override void EnterState(StateManager stateManager)
    {
        stateManager.Form.LabelTimerDisplay.Text = FormMainConstants.DefaultValueForTimerDisplay;
        stateManager.Form.LabelMoneyEarned.Text = FormMainConstants.DefaultValueForMoneyDisplay;

        var totalEarnedOnCompletedJobs = (stateManager.Form.TimeKeeper.TimeCardsCompletedJobs.Sum((t) => t.MoneyEarned));
        stateManager.Form.LabelGrandTotal.Text = totalEarnedOnCompletedJobs.ToString("F2");

        stateManager.Form.TimeKeeper.TimeCardsThisJob.Clear();
        stateManager.Form.ListViewTimeCards.Clear();

        stateManager.Form.TimeKeeper.CurrentJobTimeCard = new();
        stateManager.Form.TimeKeeper.TimerStartTime = DateTime.Now;
        stateManager.SwapState(StateManager.States.Completed);
    }
    public override void ExitState(StateManager stateManager) { }
    public override void UpdateState(StateManager stateManager) { }
}
