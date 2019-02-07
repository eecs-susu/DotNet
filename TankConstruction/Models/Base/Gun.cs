namespace TankConstruction.Models.Base
{
    public abstract class Gun : TankComponent, IShootable
    {
        protected Gun(string serialNumber) : base(serialNumber)
        {
        }

        public abstract uint Shoot();
    }
}
