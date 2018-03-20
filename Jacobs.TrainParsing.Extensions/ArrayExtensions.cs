using System;
using System.Collections.Generic;
using System.Linq;

namespace Jacobs.TrainParsing.Extensions
{
    public static class ArrayExtensions
    {
        public static IEnumerable<T> ToEnumerable<T>(this Array target)
        {
            return target.Cast<T>();
        }
    }
}