using System;
using System.Collections;
using System.Collections.Generic;
using TankConstruction.Models;

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
            var tankFactory = new SovietUnionTankFactory();

            foreach (var tank in GetTanks(tankFactory))
            {
                Console.WriteLine($"{tank}{Environment.NewLine}");
            }
        }
    }
}
