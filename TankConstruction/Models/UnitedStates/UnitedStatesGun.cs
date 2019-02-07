using TankConstruction.Models.Base;

namespace TankConstruction.Models.UnitedStates
{
    public class UnitedStatesGun : Gun
    {
        public UnitedStatesGun(string serialNumber) : base(serialNumber)
        {
        }

        public override uint Shoot()
        {
            return 100;
        }
    }
}
