using System;

namespace Business.Abstract
{
    public interface ITimeService
    {
        public DateTime CurrentTime { get; set; }
        void ShiftTime(int hours);
    }
}