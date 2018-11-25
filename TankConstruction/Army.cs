using System;
using System.Collections.Generic;
using TankConstruction.Models.Base;

namespace TankConstruction
{
    public class Army<T> : List<T> where T: Tank
    {
        private readonly TankFactory _tankFactory;
        private readonly Random _random;
        public DamageAllDelegate GetDamageForAll { get; set; }
        
        public Army(TankFactory tankFactory)
        {
            _tankFactory = tankFactory;
            _random = new Random(0);
        }
        
        public delegate uint DamageAllDelegate();

        public void DamageAll()
        {
            var dmg = GetDamageForAll();
            foreach (var item in this)
            {
                item.TakeDamage(dmg);
            }
        }
        
        public void AddRandomTank(uint n = 1)
        {
            for (int i = 0; i < n; ++i)
            {
                Tank tank = null;
                switch (_random.Next(0, 2))
                {
                    case 0:
                        tank = _tankFactory.CreateCompositeTank();
                        break;
                    case 1:
                        tank = _tankFactory.CreateLightTank();
                        break;
                    case 2:
                        tank = _tankFactory.CreateReactiveTank();
                        break;
                }

                Add((T) tank);
            }
        }
        
        
    }
}
