namespace WinForms_Pay_Timer.StateManagement;

public class State_Reset : BaseState<StateManager>
{
    public override void EnterState(StateManager stateManager)
    {
        UpdateLabels(stateManager);
        CalcGrandTotal(stateManager);
        CleanupTimeCards(stateManager);
        stateManager.SwapState(StateManager.States.Completed);


        static void CalcGrandTotal(StateManager stateManager)
        {
            var totalEarnedOnCompletedJobs = stateManager.Form.TimeKeeper.TimeCardsCompletedJobs.Sum((t) => t.MoneyEarned);
            stateManager.Form.LabelGrandTotal.Text = totalEarnedOnCompletedJobs.ToString("F2");
        }

        static void CleanupTimeCards(StateManager stateManager)
        {
            stateManager.Form.TimeKeeper.TimeCardsThisJob.Clear();
            stateManager.Form.ListViewCurrentJobTimeCards.Clear();

            stateManager.Form.TimeKeeper.CurrentJobTimeCard = new();
            stateManager.Form.TimeKeeper.TimerStartTime = DateTime.Now;
        }

        static void UpdateLabels(StateManager stateManager)
        {
            stateManager.Form.LabelTimerDisplay.Text = FormMainConstants.DefaultValueForTimerDisplay;
            stateManager.Form.LabelMoneyEarned.Text = FormMainConstants.DefaultValueForMoneyDisplay;
        }
    }
    public override void ExitState(StateManager stateManager) { }
    public override void UpdateState(StateManager stateManager) { }
}
