using System;
using System.Collections.Generic;

namespace CodeInc.Commons.Extensions
{
    public static class IEnumerableExtensions
    {
        /// <summary>
        /// Executes the <paramref name="action"/> for each item in the IEnumerable collection.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="items"></param>
        /// <param name="action">The action (expression) to execute</param>
        /// <example>
        /// This behaves much like code blocks in Ruby, allowing us to do things like
        ///
        /// int[] list = {1,2,3,4,5,6,7,8,9,10};
        /// var sum = 0;
        /// list.Each(i => sum += i);
        /// </example>
        public static void Each<T>(this IEnumerable<T> items, Action<T> action)
        {
            if (items == null)
                throw new ArgumentNullException("items");

            foreach (var item in items)
            {
                action(item);
            }
        }
    }
}