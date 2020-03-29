using System;

namespace BLL.Interfaces
{
    public interface ITimeService
    {
        public DateTime CurrentTime { get; set; }
        void ShiftTime(int hours);
    }
}