namespace RealTime_Revenue.TimeManagement
{
    public static class TimeCardCreator
    {
        public static TimeCard CreateTimecardForCurJob(TimeKeeper timeKeeper)
        {
            return new TimeCard
            {
                JobName = timeKeeper.CurrentJobTimeCard.JobName,
                HourlyRate = timeKeeper.CurrentJobTimeCard.HourlyRate,
                TimeSpentWorking = timeKeeper.ElapsedTime,
                StartTime = timeKeeper.TimerStartTime,
                StopTime = DateTime.Now
            };
        }
    }
}