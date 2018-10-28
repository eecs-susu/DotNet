namespace TankConstruction.Models
{
    public interface IDestroyable
    {
        uint Health { get; }
        uint TakeDamage(uint damage);
        bool IsDestroyed();
    }
}
