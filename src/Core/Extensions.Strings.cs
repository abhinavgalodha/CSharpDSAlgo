using System;
using System.Collections.Generic;

namespace Core
{
    public static partial class Extensions
    {
        public static bool IsInteger(this string inputString)
        {
            // C# 8.0 Discards
            return int.TryParse(inputString, out _);
        }
    }
}
