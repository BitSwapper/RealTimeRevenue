using RealTime_Revenue.TimeManagement;

namespace RealTime_Revenue.Utility;

public static class ListViewRefresher
{
    public static void RefreshListView(ListView listView, bool includeCurTimeCard, TimeKeeper timeKeeper)
    {
        listView.Items.Clear();

        if(includeCurTimeCard)
        {
            ListViewItem curCard = MakeNew(timeKeeper.CurrentJobTimeCard);
            listView.Items.Add(curCard);
        }

        foreach(var timeCard in timeKeeper.TimeCardsThisJob.OrderByDescending(tc => tc.StopTime))
        {
            ListViewItem listViewItem = MakeNew(timeCard);
            listView.Items.Add(listViewItem);
        }
    }

    private static ListViewItem MakeNew(TimeCard? timeCard) => new ListViewItem(new[]
    {
            timeCard.JobName,
            timeCard.MoneyEarned.ToString("F2"),
            timeCard.HourlyRate.ToString("F2"),
            TimeUtil.FormatTime(timeCard.TimeSpentWorking),
            timeCard.StartTime.ToString("HH:mm:ss"),
            timeCard.StopTime.ToString("HH:mm:ss")
        });
}