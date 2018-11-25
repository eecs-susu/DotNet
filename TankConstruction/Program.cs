using System;
using System.Collections;
using System.Collections.Generic;
using TankConstruction.Models;
using TankConstruction.Models.Base;
using TankConstruction.Models.SovietUnion;
using TankConstruction.Models.UnitedStates;

namespace TankConstruction
{
    internal static class Program
    {
        private static IEnumerable<Tank> GetTanks(TankFactory tankFactory)
        {
            yield return tankFactory.CreateLightTank();
            yield return tankFactory.CreateCompositeTank();
            yield return tankFactory.CreateReactiveTank();
        }

        private static void Main(string[] args)
        {
            var sovietUnionTankFactory = new SovietUnionTankFactory();
            var unitedStatesTankFactory = new UnitedStatesTankFactory();

            // Covariance
            IEnumerable<Tank> unitedStatesTanks = new List<UnitedStatesTank>
            {
                (UnitedStatesTank) unitedStatesTankFactory.CreateLightTank(),
                (UnitedStatesTank) unitedStatesTankFactory.CreateCompositeTank(),
                (UnitedStatesTank) unitedStatesTankFactory.CreateReactiveTank(),
            };


            Func<Tank, uint> attackContravariance = null;
            foreach (var tank in GetTanks(sovietUnionTankFactory))
            {
//                Console.WriteLine(new string('-', 20));
//                Console.WriteLine($"{((SovietUnionTank)tank).Clone()}{Environment.NewLine}");
//                Console.WriteLine($"{tank}{Environment.NewLine}");

//                var copies = Copier<SovietUnionTank>.Copy((SovietUnionTank) tank, 10);
//                foreach (var sovietUnionTank in copies)
//                {
//                    Console.WriteLine(sovietUnionTank);
//                }

                if (attackContravariance != null)
                {
//                    Console.WriteLine("Attack: {0}", attackContravariance(tank));
//                    Console.WriteLine($"{tank}{Environment.NewLine}");
                }

                attackContravariance = tank.Shoot;
            }

            foreach (var tank in unitedStatesTanks)
            {
//                Console.WriteLine($"{tank}{Environment.NewLine}");
            }


            var army = new Army<SovietUnionTank>(sovietUnionTankFactory);
            army.AddRandomTank(10);
            foreach (var unit in army)
            {
                Console.WriteLine(unit);
            }

            Console.WriteLine(new string('-', 20));
            army.Sort((l, r) => l.Armor.HealthPoints.CompareTo(r.Armor.HealthPoints));
            foreach (var unit in army)
            {
                Console.WriteLine(unit);
            }
            Console.WriteLine(new string('-', 20));
            Func<Army<SovietUnionTank>, List<int>> getTankWith100Hp = (collection) =>
            {
                var res = new List<int>();
                for (int i = 0; i < collection.Count; ++i)
                {
                    if (collection[i].Armor.HealthPoints == 100)
                    {
                        res.Add(i);
                        
                    }
                }

                return res;
            };
            
            Console.WriteLine(string.Join(' ', getTankWith100Hp(army)));
            Console.WriteLine(new string('-', 20));
            Army<SovietUnionTank>.DamageAllDelegate damage = () => 10;
            army.GetDamageForAll = damage;
            army.DamageAll();

            foreach (var unit in army)
            {
                Console.WriteLine(unit);
            }
            Console.WriteLine(new string('-', 20));
            Action<Army<SovietUnionTank>> pureArmor = (collection) =>
            {
                foreach (var item in collection)
                {
                    item.Armor.TakeDamage(item.Armor.HealthPoints * 1000);
                }
            };

            pureArmor(army);


            foreach (var unit in army)
            {
                Console.WriteLine(unit);
            }
            Console.WriteLine(new string('-', 20));
        }
    }
}
