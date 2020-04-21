using System;
using Business.Abstract;

namespace Business.Implementation.Services
{
    public class TimeService : ITimeService
    {
        public DateTime CurrentTime { get; set; } = DateTime.Now;

        public void ShiftTime(int hours)
        {
            CurrentTime = CurrentTime.AddHours(hours);
        }
    }
}