using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adventofcode2019.Classes
{
    public static class ClassExtentions
    {
        public static T FirstOr<T>(this IEnumerable<T> source, T alternate)
        {
            foreach (T t in source)
                return t;
            return alternate;
        }

        public static T IfDefaultGiveMe<T>(this T value, T alternate)
        {
            if (value.Equals(default(T))) return alternate;
            return value;
        }
    }
}
