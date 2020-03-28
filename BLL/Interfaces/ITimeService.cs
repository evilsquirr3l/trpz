using System;

namespace BLL
{
    public interface ITimeService
    {
        void ShiftTime(int hours);

        public DateTime CurrentTime { get; set; }
    }
}