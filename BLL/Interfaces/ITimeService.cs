using System;

namespace BLL.Interfaces
{
    public interface ITimeService
    {
        void ShiftTime(int hours);

        public DateTime CurrentTime { get; set; }
    }
}