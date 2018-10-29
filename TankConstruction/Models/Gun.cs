namespace TankConstruction.Models
{
    public abstract class Gun : TankComponent, IShootable
    {
        protected Gun(string serialNumber) : base(serialNumber)
        {
        }

        public abstract uint Shoot();
    }
}
