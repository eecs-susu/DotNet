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

            foreach (var tank in GetTanks(sovietUnionTankFactory))
            {
                Console.WriteLine($"{tank}{Environment.NewLine}");
            }

            foreach (var tank in GetTanks(unitedStatesTankFactory))
            {
                Console.WriteLine($"{tank}{Environment.NewLine}");
            }
        }
    }
}
