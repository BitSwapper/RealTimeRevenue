namespace WinForms_Pay_Timer;

public static class TimeUtil
{
    public static string FormatTime(TimeSpan elapsedTime) => $"{((int)elapsedTime.TotalHours).ToString("D2")}:{((int)elapsedTime.TotalMinutes % 60).ToString("D2")}:{(elapsedTime.TotalSeconds % 60).ToString("00")}";
}