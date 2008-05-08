using System;
using System.Collections.Generic;

namespace CodeInc.Commons
{
    public class Range<T> where T : IComparable<T>
    {
        public readonly T Start;
        public readonly T End;

        public Range(T first, T second)
        {
            Comparer<T> comparer = Comparer<T>.Default;

            // Want to ensure that the start really is less than the end.
            if (Equals(first, default(T)) || comparer.Compare(first, second) <= 0)
            {
                this.Start = first;
                this.End = second;
            }
            else
            {
                this.Start = second;
                this.End = first;
            }
        }
    }
}