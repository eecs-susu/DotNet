using System;

namespace TankConstruction.Models
{
    public abstract class TankComponent : IDestroyable, IWeightable, IProduct
    {
        protected TankComponent(uint health, uint weight, string serialNumber)
        {
            Health = health;
            Weight = weight;
            SerialNumber = serialNumber;
        }

        public uint Health { get; protected set; }

        public uint TakeDamage(uint damage)
        {
            var activeDamage = Math.Min(damage, Health);
            Health -= activeDamage;
            return activeDamage;
        }

        public bool IsDestroyed()
        {
            return Health == 0;
        }

        public string SerialNumber { get; }

        public uint Weight { get; }
    }
}
