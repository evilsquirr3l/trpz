using System;
using BLL.Interfaces;

namespace BLL.Services
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