namespace TankConstruction.Models
{
    internal interface IDestroyable
    {
        uint MaxHealth { get; }
        uint Health { get; }
        void TakeDamage(uint damage);
        bool IsDestroyed();
    }
}
