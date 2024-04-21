﻿using System.Reflection;

namespace WinForms_Pay_Timer.StateManagement;

public class State_InitProgram : BaseState<StateManager>
{
    public override void EnterState(StateManager stateManager)
    {
        stateManager.Form.TimerUpdateTimerText.Start();

        stateManager.Form.ListViewCurrentJobTimeCards.View = View.Details;
        stateManager.Form.ListViewCurrentJobTimeCards.GridLines = true;
        stateManager.Form.ListViewCurrentJobTimeCards.FullRowSelect = true;
        stateManager.Form.ListViewCurrentJobTimeCards.Columns.Add("Project Name", FormMainConstants.ProjectNameColumnWidth);
        stateManager.Form.ListViewCurrentJobTimeCards.Columns.Add("Money Earned", FormMainConstants.MoneyEarnedColumnWidth);
        stateManager.Form.ListViewCurrentJobTimeCards.Columns.Add("Rate", FormMainConstants.HourlyRateColumnWidth);
        stateManager.Form.ListViewCurrentJobTimeCards.Columns.Add("Time Spent", FormMainConstants.TimeSpentColumnWidth);
        stateManager.Form.ListViewCurrentJobTimeCards.Columns.Add("Start Time", FormMainConstants.TimeSpentColumnWidth);
        stateManager.Form.ListViewCurrentJobTimeCards.Columns.Add("Stop Time", FormMainConstants.TimeSpentColumnWidth);

        stateManager.Form.ListViewCompletedJobs.View = View.Details;
        stateManager.Form.ListViewCompletedJobs.GridLines = true;
        stateManager.Form.ListViewCompletedJobs.FullRowSelect = true;
        stateManager.Form.ListViewCompletedJobs.Columns.Add("Project Name", FormMainConstants.ProjectNameColumnWidth);
        stateManager.Form.ListViewCompletedJobs.Columns.Add("Money Earned", FormMainConstants.MoneyEarnedColumnWidth);
        stateManager.Form.ListViewCompletedJobs.Columns.Add("Rate", FormMainConstants.HourlyRateColumnWidth);
        stateManager.Form.ListViewCompletedJobs.Columns.Add("Time Spent", FormMainConstants.TimeSpentColumnWidth);

        var doubleBufferedProperty = typeof(ListView).GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic);
        doubleBufferedProperty!.SetValue(stateManager.Form.ListViewCurrentJobTimeCards, true, null);
        doubleBufferedProperty!.SetValue(stateManager.Form.ListViewCompletedJobs, true, null);
    }
    public override void ExitState(StateManager stateManager) { }
    public override void UpdateState(StateManager stateManager) { }
}
