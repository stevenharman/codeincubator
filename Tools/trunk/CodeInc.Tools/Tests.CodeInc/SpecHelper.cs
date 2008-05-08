using System;

namespace Tests.CodeInc
{
    public class SpecHelper
    {
        private static readonly Random _random = new Random();

        public static int RandomInt()
        {
            int result = RandomInt(int.MaxValue);
            return result;
        }

        public static int RandomInt(int maxValue)
        {
            int result = _random.Next(maxValue);
            return result;
        }

        public static int RandomInt(int minValue, int maxValue)
        {
            return _random.Next(minValue, maxValue);
        }
    }
}