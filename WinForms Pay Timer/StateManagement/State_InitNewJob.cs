namespace RealTime_Revenue.StateManagement;

public class State_InitNewJob : BaseState<StateManager>
{
    public override void EnterState(StateManager stateManager)
    {
        using(var jobStartedForm = new JobStarter())
        {
            if(jobStartedForm.ShowDialog() == DialogResult.OK)
            {
                SetupCurrentJobTimeCard(stateManager, jobStartedForm.HourlyRate, jobStartedForm.ProjectName);
                ToggleButtonStates(stateManager);
                stateManager.Form.LabelCurJobName.Text = $"This Job ({stateManager.Form.TimeKeeper.CurrentJobTimeCard.JobName})";
            }
        }

        static void ToggleButtonStates(StateManager stateManager)
        {
            stateManager.Form.ButtonTimerStart.Enabled = true;
            stateManager.Form.ButtonTimerComplete.Enabled = false;
            stateManager.Form.ButtonTimerReset.Enabled = false;
        }

        static void SetupCurrentJobTimeCard(StateManager stateManager, decimal hourlyRate, string projectName)
        {
            stateManager.Form.TimeKeeper.CurrentJobTimeCard = new();
            stateManager.Form.TimeKeeper.CurrentJobTimeCard.JobName = projectName;
            stateManager.Form.TimeKeeper.CurrentJobTimeCard.HourlyRate = hourlyRate;
        }
    }

    public override void ExitState(StateManager stateManager) { }
    public override void UpdateState(StateManager stateManager) { }
}
