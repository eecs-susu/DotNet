using System;

namespace TankConstruction.Models
{
    internal abstract class Gun : IDestroyable
    {
        private double _accuracy;

        protected Gun(uint maxHealth)
        {
            MaxHealth = maxHealth;
            Health = maxHealth;
        }

        public double Accuracy
        {
            get => _accuracy;
            private set
            {
                if (Accuracy < 0 || Accuracy > 1) throw new ArgumentException("Accuracy should be in range [0, 1]");

                _accuracy = value;
            }
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
