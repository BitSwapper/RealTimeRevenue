namespace WinForms_Pay_Timer;

public class State_InitProgram : BaseState<StateManager>
{
    public override void EnterState(StateManager stateManager)
    {
        stateManager.Form.TimerUpdateTimerText.Start();

        stateManager.Form.ListViewTimeCards.View = View.Details;
        stateManager.Form.ListViewTimeCards.GridLines = true;
        stateManager.Form.ListViewTimeCards.FullRowSelect = true;
        stateManager.Form.ListViewTimeCards.Columns.Add("Project Name", FormMainConstants.ProjectNameColumnWidth);
        stateManager.Form.ListViewTimeCards.Columns.Add("Hourly Rate", FormMainConstants.HourlyRateColumnWidth);
        stateManager.Form.ListViewTimeCards.Columns.Add("Time Spent", FormMainConstants.TimeSpentColumnWidth);
        stateManager.Form.ListViewTimeCards.Columns.Add("Money Earned", FormMainConstants.MoneyEarnedColumnWidth);
        stateManager.Form.ListViewTimeCards.Columns.Add("Start Time", FormMainConstants.StartTimeColumnWidth);
        stateManager.Form.ListViewTimeCards.Columns.Add("Stop Time", FormMainConstants.StopTimeColumnWidth);

        stateManager.Form.ListViewCompletedJobs.View = View.Details;
        stateManager.Form.ListViewCompletedJobs.GridLines = true;
        stateManager.Form.ListViewCompletedJobs.FullRowSelect = true;
        stateManager.Form.ListViewCompletedJobs.Columns.Add("Project Name", FormMainConstants.ProjectNameColumnWidth);
        stateManager.Form.ListViewCompletedJobs.Columns.Add("Hourly Rate", FormMainConstants.HourlyRateColumnWidth);
        stateManager.Form.ListViewCompletedJobs.Columns.Add("Time Spent", FormMainConstants.TimeSpentColumnWidth);
        stateManager.Form.ListViewCompletedJobs.Columns.Add("Money Earned", FormMainConstants.MoneyEarnedColumnWidth);
    }
    public override void ExitState(StateManager stateManager) { }
    public override void UpdateState(StateManager stateManager) { }
}
