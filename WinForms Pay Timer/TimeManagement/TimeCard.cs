namespace RealTime_Revenue.TimeManagement;

public class TimeCard
{
    public decimal HourlyRate { get; set; }
    public string JobName { get; set; } = "";
    public TimeSpan TimeSpentWorking { get; set; } = new();
    public decimal MoneyEarned => HourlyRate * (decimal)TimeSpentWorking.TotalHours;
    public DateTime StartTime { get; set; }
    public DateTime StopTime { get; set; }
}