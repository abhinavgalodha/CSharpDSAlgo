using System;
using System.Collections.Generic;

namespace Core
{
    public static partial class Extensions
    {
        public static bool IsLessThanEqualTo<T>(this T leftObject, T rightObject, Comparer<T> comparer)
        {
            return comparer.Compare(leftObject, rightObject) <= 0;
        }

        public static bool IsLessThanEqualTo<T>(this T leftObject, T rightObject)
        {
            return leftObject.IsLessThanEqualTo(rightObject, Comparer<T>.Default);
        }

        public static bool IsLessThan<T>(this T leftObject, T rightObject, Comparer<T> comparer)
        {
            return comparer.Compare(leftObject, rightObject) < 0;
        }

        public static bool IsLessThan<T>(this T leftObject, T rightObject)
        {
            return leftObject.IsLessThan(rightObject, Comparer<T>.Default);
        }

        public static bool IsGreaterThanEqualTo<T>(this T leftObject, T rightObject, Comparer<T> comparer)
        {
            return comparer.Compare(leftObject, rightObject) >= 0;
        }

        public static bool IsGreaterThanEqualTo<T>(this T leftObject, T rightObject)
        {
            return leftObject.IsGreaterThanEqualTo(rightObject, Comparer<T>.Default);
        }

        public static bool IsGreaterThan<T>(this T leftObject, T rightObject, Comparer<T> comparer)
        {
            return !IsLessThanEqualTo(leftObject,rightObject, comparer);
        }

        public static bool IsGreaterThan<T>(this T leftObject, T rightObject)
        {
            return leftObject.IsGreaterThan(rightObject, Comparer<T>.Default);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="valueInBetween"></param>
        /// <param name="lowerBound"></param>
        /// <param name="upperBound"></param>
        /// <param name="includeEqualBounds">Specifies if the <paramref name="valueInBetween"/> can be less than or equal to
        ///     <paramref name="lowerBound"/> or <paramref name="upperBound"/> A false value compares for a strict comparison excluding equality
        /// from upper/lower bound</param>
        /// <returns></returns>
        public static bool IsInBetween<T>(this T valueInBetween, T lowerBound, T upperBound, bool includeEqualBounds = true)
        {
            if (includeEqualBounds)
            {
                return lowerBound.IsLessThanEqualTo(valueInBetween) &&
                       upperBound.IsGreaterThanEqualTo(valueInBetween);    
            }
            else
            {
                return lowerBound.IsLessThan(valueInBetween) &&
                       upperBound.IsGreaterThan(valueInBetween);    
            }
        }
    }
}
