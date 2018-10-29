namespace TankConstruction.Models
{
    public interface IDamageable
    {
        uint HealthPoints { get; }
        void TakeDamage(uint power);
        bool IsDestroyed();
    }
}