﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms.Test.Data
{
    /// <summary>
    ///  Verifies the collection of 2 elements to be equivalent
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class CollectionVerification<T> where T :  IComparable<T>
    {
        public CollectionVerification(ICollection<T> actual, ICollection<T> expected)
        {
            this.Actual = actual;
            this.Expected = expected;
        }

        public ICollection<T> Actual { get; set; }

        /// <summary>
        /// It should be immutable as expected shouldn't be changed
        /// </summary>
        public ICollection<T> Expected { get; }

        public bool IsEqual() => Actual.SequenceEqual(Expected);

    }


}