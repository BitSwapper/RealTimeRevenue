using System.Reflection;
using RealTime_Revenue.ColorManagement;

namespace RealTime_Revenue.StateManagement;

public class State_InitProgram : BaseState<StateManager>
{
    public override void EnterState(StateManager stateManager)
    {
        stateManager.Form.TimerUpdateTimerText.Start();
        InitLviCurrentJobs(stateManager);
        InitLviCompletedJobs(stateManager);
        EnableDoubleBufferingOnLvis(stateManager);
        SetupCustomListViewAppearance(stateManager);


        static void EnableDoubleBufferingOnLvis(StateManager stateManager)
        {
            var doubleBufferedProperty = typeof(ListView).GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic);
            doubleBufferedProperty!.SetValue(stateManager.Form.ListViewCurrentJobTimeCards, true, null);
            doubleBufferedProperty!.SetValue(stateManager.Form.ListViewCompletedJobs, true, null);
        }

        static void InitLviCompletedJobs(StateManager stateManager)
        {
            stateManager.Form.ListViewCompletedJobs.View = View.Details;
            stateManager.Form.ListViewCompletedJobs.GridLines = true;
            stateManager.Form.ListViewCompletedJobs.FullRowSelect = true;
            stateManager.Form.ListViewCompletedJobs.Columns.Add("Job Name", FormMainConstants.ProjectNameColumnWidth);
            stateManager.Form.ListViewCompletedJobs.Columns.Add("Money Earned", FormMainConstants.MoneyEarnedColumnWidth);
            stateManager.Form.ListViewCompletedJobs.Columns.Add("Rate", FormMainConstants.HourlyRateColumnWidth);
            stateManager.Form.ListViewCompletedJobs.Columns.Add("Time Spent", FormMainConstants.TimeSpentColumnWidth);
            stateManager.Form.ListViewCompletedJobs.Columns.Add("", FormMainConstants.EmpytySpaceBottom);
        }

        static void InitLviCurrentJobs(StateManager stateManager)
        {
            stateManager.Form.ListViewCurrentJobTimeCards.View = View.Details;
            stateManager.Form.ListViewCurrentJobTimeCards.GridLines = true;
            stateManager.Form.ListViewCurrentJobTimeCards.FullRowSelect = true;
            stateManager.Form.ListViewCurrentJobTimeCards.Columns.Add("Job Name", FormMainConstants.ProjectNameColumnWidth);
            stateManager.Form.ListViewCurrentJobTimeCards.Columns.Add("Money Earned", FormMainConstants.MoneyEarnedColumnWidth);
            stateManager.Form.ListViewCurrentJobTimeCards.Columns.Add("Rate", FormMainConstants.HourlyRateColumnWidth);
            stateManager.Form.ListViewCurrentJobTimeCards.Columns.Add("Time Spent", FormMainConstants.TimeSpentColumnWidth);
            stateManager.Form.ListViewCurrentJobTimeCards.Columns.Add("Start Time", FormMainConstants.TimeSpentStartStopColumnWidth);
            stateManager.Form.ListViewCurrentJobTimeCards.Columns.Add("Stop Time", FormMainConstants.TimeSpentStartStopColumnWidth);
            stateManager.Form.ListViewCurrentJobTimeCards.Columns.Add("", FormMainConstants.EmpytySpaceTop);
        }

        void SetupCustomListViewAppearance(StateManager stateManager)
        {
            stateManager.Form.ListViewCurrentJobTimeCards.OwnerDraw = true;
            stateManager.Form.ListViewCurrentJobTimeCards.DrawColumnHeader += listView_DrawColumnHeader;
            stateManager.Form.ListViewCurrentJobTimeCards.DrawSubItem += listView_DrawSubItem;

            stateManager.Form.ListViewCompletedJobs.OwnerDraw = true;
            stateManager.Form.ListViewCompletedJobs.DrawColumnHeader += listView_DrawColumnHeader;
            stateManager.Form.ListViewCompletedJobs.DrawSubItem += listView_DrawSubItem;

            void listView_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
            {
                e.DrawBackground();
                e.Graphics.FillRectangle(new SolidBrush(ColorThemeManager.CurTheme.ButtonColor), e.Bounds);

                Rectangle textBounds = e.Bounds;
                textBounds.X += 4;
                e.Graphics.DrawString(e.Header.Text, e.Font, new SolidBrush(ColorThemeManager.CurTheme.FontColorListViewCaption), textBounds);
            }

            void listView_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
            {
                e.DrawBackground();
                e.Graphics.DrawString(e.SubItem.Text, e.SubItem.Font, new SolidBrush(ColorThemeManager.CurTheme.FontColor), e.Bounds);
            }
        }
    }
    public override void ExitState(StateManager stateManager) { }
    public override void UpdateState(StateManager stateManager) { }
}
