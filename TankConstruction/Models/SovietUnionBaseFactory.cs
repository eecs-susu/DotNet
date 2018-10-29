using System;
using System.Collections;
using System.Collections.Generic;

namespace TankConstruction.Models
{
    public class SovietUnionBaseFactory
    {
        protected static IEnumerator<T> CreateConveyor<T>(Func<string, T> create)
        {
            for (var i = 0;; ++i)
            {
                yield return create($"СССР-{i}");
            }
        }
    }
}
