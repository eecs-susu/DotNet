using System;

namespace TankConstruction.Models
{
    internal abstract class Track : IDestroyable
    {
        protected Track(uint maxHealth)
        {
            MaxHealth = maxHealth;
            Health = maxHealth;
        }

        public uint MaxHealth { get; }
        public uint Health { get; private set; }

        public void TakeDamage(uint damage)
        {
            Health = damage > Health ? 0 : Health - damage;
        }

        public bool IsDestroyed()
        {
            return Health == 0;
        }
    }
}
