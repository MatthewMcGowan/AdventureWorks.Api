using AdventureWorks.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureWorks.Extensions
{
    public static class EnumerationExtensions
    {
        public static T ToEnum<T>(this string value)
        {
            return (T)Enum.Parse(typeof(T), value, true);
        }
    }
}
