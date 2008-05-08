using System;

namespace CodeInc.Commons.Extensions
{
    public static class RangeExtensions
    {
        public static bool Overlaps<T>(this Range<T> left, Range<T> right) where T : IComparable<T>
        {
            // two ranges w/the same start MUST overlap
            if (left.Start.CompareTo(right.Start) == 0)
            {
                return true;
            }

            // if the left starts after the right starts
            if (left.Start.CompareTo(right.Start) > 0)
            {
                // then the left starting before the right ends means overlap
                return left.Start.CompareTo(right.End) <= 0;
            }

            return right.Start.CompareTo(left.End) <= 0;
        }
    }
}