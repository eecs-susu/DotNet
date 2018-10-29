using System;

namespace TankConstruction.Models
{
    public abstract class Armor : TankComponent, IDamageable
    {
        public uint HealthPoints { get; protected set; }

        public virtual void TakeDamage(uint power)
        {
            HealthPoints -= Math.Min(power, HealthPoints);
        }

        public bool IsDestroyed()
        {
            return HealthPoints == 0;
        }

        protected Armor(string serialNumber, uint healthPoints) : base(serialNumber)
        {
            HealthPoints = healthPoints;
        }
        
    }
}
