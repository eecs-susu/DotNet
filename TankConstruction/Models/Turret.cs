namespace TankConstruction.Models
{
    internal class Turret : IDestroyable
    {
        public Turret(uint maxHealth)
        {
            MaxHealth = maxHealth;
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
