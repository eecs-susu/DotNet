namespace TankConstruction.Models
{
    internal abstract class Engine : IDestroyable
    {
        protected Engine(uint power, uint maxHealth)
        {
            Power = power;
            MaxHealth = maxHealth;
            Health = maxHealth;
        }

        public uint Power { get; }
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
