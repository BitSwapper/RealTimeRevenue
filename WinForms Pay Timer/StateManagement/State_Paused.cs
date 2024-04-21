using WinForms_Pay_Timer.TimeManagement;

namespace WinForms_Pay_Timer.StateManagement;

public class State_Paused : BaseState<StateManager>
{
    public override void EnterState(StateManager stateManager)
    {
        ToggleButtonStates(stateManager);
        AddNewTimecardForCurJob(stateManager);
        stateManager.Form.RefreshListView(false);

        static void ToggleButtonStates(StateManager stateManager)
        {
            stateManager.Form.ButtonTimerStart.Enabled = true;
            stateManager.Form.ButtonTimerPause.Enabled = false;
        }

        static void AddNewTimecardForCurJob(StateManager stateManager)
        {
            TimeCard newTimeCard = stateManager.Form.CreateTimecardForCurJob();
            stateManager.Form.TimeKeeper.TimeCardsThisJob.Add(newTimeCard);
        }
    }

    public override void ExitState(StateManager stateManager) { }
    public override void UpdateState(StateManager stateManager) { }
}
