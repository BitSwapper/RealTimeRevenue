namespace WinForms_Pay_Timer.StateManagement;

public class State_InitNewJob : BaseState<StateManager>
{
    public override void EnterState(StateManager stateManager)
    {
        using (var jobStartedForm = new JobStarter())
        {
            if (jobStartedForm.ShowDialog() == DialogResult.OK)
            {
                decimal hourlyRate = jobStartedForm.HourlyRate;
                string projectName = jobStartedForm.ProjectName;

                stateManager.Form.TimeKeeper.CurrentJobTimeCard = new();
                stateManager.Form.TimeKeeper.CurrentJobTimeCard.ProjectName = projectName;
                stateManager.Form.TimeKeeper.CurrentJobTimeCard.HourlyRate = hourlyRate;
                stateManager.Form.ButtonTimerStart.Enabled = true;
                stateManager.Form.ButtonTimerComplete.Enabled = false;
                stateManager.Form.ButtonTimerReset.Enabled = false;
            }
        }
    }

    public override void ExitState(StateManager stateManager) { }
    public override void UpdateState(StateManager stateManager) { }
}
