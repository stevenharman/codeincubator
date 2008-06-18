using System;

namespace CodeInc.Commons
{
    public class DateRange : Range<DateTime>
    {
        public TimeSpan Duration
        {
            get
            {
                if (End == DateTime.MaxValue || Start == DateTime.MinValue)
                    return TimeSpan.MaxValue;

                return End - Start;
            }
        }

        public DateRange(DateTime start, DateTime end)
            : base(start, end)
        {
        }

        public DateRange(DateTime? start, DateTime? end)
            : base(start ?? DateTime.MinValue, end ?? DateTime.MaxValue)
        {
        }

        public DateRange(DateTime start, DateTime? end)
            : base(start, end ?? DateTime.MaxValue)
        {
        }

        public DateRange(DateTime? start, DateTime end)
            : base(start ?? DateTime.MinValue, end)
        {
        }
    }
}