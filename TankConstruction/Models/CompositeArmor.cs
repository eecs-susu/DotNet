namespace TankConstruction.Models
{
    public class CompositeArmor : Armor
    {
        public CompositeArmor(uint health, uint weight, string serialNumber, uint compositeFactor) : base(health,
            weight, serialNumber)
        {
            CompositeFactor = compositeFactor;
        }

        private uint CompositeFactor { get; }

        public new uint TakeDamage(uint damage)
        {
            var compositeDamage = damage;
            if (CompositeFactor > damage)
            {
                compositeDamage = 0;
                return damage;
            }

            compositeDamage -= CompositeFactor;

            if (compositeDamage <= Health)
            {
                Health -= compositeDamage;
                return damage;
            }

            Health -= Health;
            return Health;
        }
    }
}
