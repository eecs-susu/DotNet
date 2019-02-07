using System;

namespace TankConstruction.Models.Base
{
    public abstract class ReactiveArmor : Armor
    {
        private readonly double _absorbedRatio;

        protected ReactiveArmor(string serialNumber, uint healthPoints, double absorbedRatio) : base(serialNumber,
            healthPoints)
        {
            if (absorbedRatio < 0)
            {
                throw new ArgumentException($"{absorbedRatio} can't be less than 0");
            }

            if (absorbedRatio > 1)
            {
                throw new ArgumentException($"{absorbedRatio} can't be greater than 1");
            }

            _absorbedRatio = absorbedRatio;
        }

        public override void TakeDamage(uint power)
        {
            power -= (uint) (power * _absorbedRatio);
            HealthPoints -= Math.Min(HealthPoints, power);
        }

        public override string ToString()
        {
            return $"Type: Reactive {base.ToString()}";
        }
    }
}
