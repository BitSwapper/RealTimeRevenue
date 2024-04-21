namespace RealTime_Revenue.TimeManagement;

public class TimeKeeper
{
    public DateTime TimerStartTime { get; set; }
    public TimeSpan ElapsedTime => DateTime.Now - TimerStartTime;
    public TimeCard CurrentJobTimeCard { get; set; }
    public List<TimeCard> TimeCardsThisJob { get; set; } = new();
    public List<TimeCard> TimeCardsCompletedJobs { get; set; } = new();
}
