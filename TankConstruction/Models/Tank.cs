using TankConstruction.Models;

namespace TankConstruction.Models
{
    public abstract class Tank : IMovable, IDestroyable
    {
        public Tank(uint maxHealth)
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

        public Engine Engine { get; set; }
    }
}
