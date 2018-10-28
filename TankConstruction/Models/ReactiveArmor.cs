using System;

namespace TankConstruction.Models
{
    public class ReactiveArmor : Armor
    {
        private float _reactiveFactor;

        public ReactiveArmor(uint health, uint weight, string serialNumber, float reactiveFactor) : base(health, weight,
            serialNumber)
        {
            ReactiveFactor = reactiveFactor;
        }

        private float ReactiveFactor
        {
            get => _reactiveFactor;
            set
            {
                if (_reactiveFactor < 0 || _reactiveFactor > 1)
                    throw new ArgumentException("Reactive factor must be in range [0, 1]");

                _reactiveFactor = value;
            }
        }

        public new uint TakeDamage(uint damage)
        {
            var reactiveDamage = (uint) _reactiveFactor * damage;
            if (reactiveDamage <= Health)
            {
                Health -= reactiveDamage;
                return damage;
            }

            Health -= Health;
            return Health;
        }
    }
}
