namespace TankConstruction.Models
{
    public interface IShootable
    {
        void Shoot(IDestroyable target);
    }
}
