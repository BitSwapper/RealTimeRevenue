using RealTime_Revenue.TimeManagement;
using RealTime_Revenue.Utility;

namespace RealTime_Revenue.StateManagement;

public class State_Paused : BaseState<StateManager>
{
    public override void EnterState(StateManager stateManager)
    {
        ToggleButtonStates(stateManager);
        AddNewTimecardForCurJob(stateManager);
        ListViewRefresher.RefreshListView(stateManager.Form.ListViewCurrentJobTimeCards, false, stateManager.Form.TimeKeeper);

        static void ToggleButtonStates(StateManager stateManager)
        {
            stateManager.Form.ButtonTimerStart.Enabled = true;
            stateManager.Form.ButtonTimerPause.Enabled = false;
        }

        static void AddNewTimecardForCurJob(StateManager stateManager)
        {
            TimeCard newTimeCard = TimeCardCreator.CreateTimecardForCurJob(stateManager.Form.TimeKeeper);
            stateManager.Form.TimeKeeper.TimeCardsThisJob.Add(newTimeCard);
        }
    }

    public override void ExitState(StateManager stateManager) { }
    public override void UpdateState(StateManager stateManager) { }
}
