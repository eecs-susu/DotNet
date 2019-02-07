using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Threading;
using Newtonsoft.Json.Linq;
using TankConstruction.Errors;
using TankConstruction.Models;
using TankConstruction.Models.Base;
using TankConstruction.Models.SovietUnion;
using TankConstruction.Models.UnitedStates;
using TankConstruction.Models.Utils;

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

        private static void First4()
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

        private static void LoadArmies(string path)
        {
            var forces = File.ReadAllText(path);
            var data = JObject.Parse(forces);
            var existingArmies = new HashSet<string>();
            var armies = new List<Army<Tank>>();
            foreach (var army in data["Armies"])
            {
                var side = (string) army["Side"];
                if (existingArmies.Contains(side))
                {
                    throw new TooManyForcesException($"Each side can contains at most 1 army, but '{side}' wants to have more");
                }

                existingArmies.Add(side);
                TankFactory factory = null;
                switch (side)
                {
                    case "SovietUnion":
                        factory = new SovietUnionTankFactory();
                        break;
                    case "UnitedStates":
                        factory = new UnitedStatesTankFactory();
                        break;
                    default:
                        throw new ArgumentException($"There is no such side like '{side}'");
                }

                var tanks = new Army<Tank>(factory);
                foreach (var tank in army["Tanks"])
                {
                    var type = (string) tank["Type"];
                    switch (type)
                    {
                        case "Reactive":
                            tanks.AddReactiveTank();
                            break;
                        case "Light":
                            tanks.AddLightTank();
                            break;
                        case "Composite":
                            tanks.AddCompositeTank();
                            break;
                        default:
                            throw new ArgumentException($"There is no such tank type like '{type}'");
                    }
                }

                var extraTanks = (int)(army["RandomTanks"] ?? 0);
                for (var i = 0; i < extraTanks; ++i)
                {
                    tanks.AddRandomTank();
                }
                armies.Add(tanks);
            }

            foreach (var army in armies)
            {
                Console.WriteLine("---");
                Console.WriteLine(string.Join(' ', army));
            }
            
        }


        private static void Logging()
        {
            Console.WriteLine("Choose type log type: 1 - console, 2 - file");
            var army = new Army<Tank>(new SovietUnionTankFactory());
            var key = int.Parse(Console.ReadLine());
            switch (key)
            {
                    case 1:
                        army.ArmyChanged += ArmyOnArmyChangedConsole;
                        break;
                    case 2:
                        army.ArmyChanged += ArmyOnArmyChangedFile;
                        break;
            }

            for (int i = 0; i < 10; ++i)
            {
                army.AddRandomTank();
                Thread.Sleep(1000);
            }
        }

        private static string FormatLog(string source)
        {
            return $"{DateTime.Now.ToLongDateString()} {DateTime.Now.ToLongTimeString()}{Environment.NewLine}{source}";
        }

        private static void ArmyOnArmyChangedFile(object sender, Army<Tank>.ArmyChangedEventArgs e)
        {
              File.AppendAllText("log.txt", FormatLog(e.Info) + Environment.NewLine);
        }

        private static void ArmyOnArmyChangedConsole(object sender, Army<Tank>.ArmyChangedEventArgs e)
        {
            Console.WriteLine(FormatLog(e.Info));
        }

        private static void Exceptions()
        {
            try
            {
                LoadArmies("initial_forces_err2.json");
            }
            catch (ArgumentException e)
            {
                Console.WriteLine("Argument exception: " + e.Message);
            }
            catch (TooManyForcesException e)
            {
                Console.WriteLine("TooManyForcesException: " + e.Message);
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine("FileNotFoundException: " + e.Message);
            }
        }


        private static void Threads()
        {
            var army = new Army<Tank>(new SovietUnionTankFactory());
            for (int i = 0; i < 10; ++i)
            {
                army.AddRandomTank();
            }
            army.SortStarted += (e, a) => Console.WriteLine("Sort started");
            army.SortFinished += (e, a) => Console.WriteLine("Sort finished");         
            army.SortItemPlaced += (e, a) => Console.WriteLine(a.Info);
            var thread = army.StartSort((l, r) => l.Armor.HealthPoints.CompareTo(r.Armor.HealthPoints));
            for (var i = 0; i < 10; i++)
            {
                Console.WriteLine("This message before or between sorting");
                Thread.Sleep(500);
            }

            thread.Join();
            Console.WriteLine("This message after sorting");
        }
        
        private static void Main(string[] args)
        {
//            Logging();
//            Exceptions();
            Threads();
            return;
            var sovietUnionTankFactory = new SovietUnionTankFactory();
            var unitedStatesTankFactory = new UnitedStatesTankFactory();
            var army = new Army<SovietUnionTank>(sovietUnionTankFactory);
            army.AddRandomTank(10);

            var serializer = new XmlSerializer();
            var data = army.Serialize(serializer);
            Console.WriteLine(data);
            var t = Army<Tank>.Deserialize(serializer, data);
        }
    }
}
