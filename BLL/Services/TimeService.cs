using System;

namespace BLL
{
    public class TimeService : ITimeService
    {
        public DateTime CurrentTime { get; set; } = DateTime.Now;

        public void ShiftTime(int hours)
        {
            CurrentTime.AddHours(hours);
        }
    }
}