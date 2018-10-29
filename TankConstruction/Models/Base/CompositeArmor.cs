using System;

namespace TankConstruction.Models.Base
{
    public abstract class CompositeArmor : Armor
    {
        private uint Armor { get; set; }


        public override void TakeDamage(uint power)
        {
            var absorbedDamage = Math.Min(Armor, power);

            Armor -= absorbedDamage;

            HealthPoints -= Math.Min(HealthPoints, power - absorbedDamage);
        }

        protected CompositeArmor(string serialNumber, uint healthPoints, uint armor) : base(serialNumber, healthPoints)
        {
            Armor = armor;
        }

        public override string ToString()
        {
            return $"Type: Composite {base.ToString()}";
        }
    }
}
