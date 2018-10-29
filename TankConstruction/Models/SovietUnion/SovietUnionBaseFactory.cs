using System;
using System.Collections.Generic;

namespace TankConstruction.Models.SovietUnion
{
    public class SovietUnionBaseFactory
    {
        protected static IEnumerator<T> CreateConveyor<T>(Func<string, T> create)
        {
            for (var i = 0;; ++i)
            {
                yield return create($"СССР-{i}");
            }
            // ReSharper disable once IteratorNeverReturns
        }
    }
}
