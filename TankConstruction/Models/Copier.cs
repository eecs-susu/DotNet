using System;
using System.Collections;
using System.Collections.Generic;

namespace TankConstruction.Models
{
    public class Copier<T> where T: ICloneable
    {
        public static IEnumerable<T> Copy(T item, uint n = 1)
        {
            var copies = new List<T>();
            for (var i = 0; i < n; i++)
            {
                copies.Add((T)item.Clone());
            }

            return copies;
        }
    }
}
