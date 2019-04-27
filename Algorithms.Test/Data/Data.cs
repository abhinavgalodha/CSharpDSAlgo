using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms.Test.Data
{
    public class CollectionVerification<T> where T :  IComparable<T>
    {
        public ICollection<T> Actual { get; set; }

        public ICollection<T> Expected { get; set; }

        bool IsEqual() => Actual.SequenceEqual(Expected);

    }
}
