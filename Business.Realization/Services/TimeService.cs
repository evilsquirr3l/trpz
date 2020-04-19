using System;
using BLL.Interfaces;

namespace Business.Realization.Services
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