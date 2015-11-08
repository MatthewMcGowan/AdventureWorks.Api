using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureWorks.Extensions
{
    public static class IEnumerableExtensions
    {
        public static void ForEach<T>(this IEnumerable<T> enumeration, Action<T> action)
        {
            foreach (T item in enumeration)
            {
                action(item);
            }
        }

        public static bool IsNullOrEmpty<T> (this IEnumerable<T> enumeration)
        {
            return enumeration == null || !enumeration.Any();
        }
    }
}
