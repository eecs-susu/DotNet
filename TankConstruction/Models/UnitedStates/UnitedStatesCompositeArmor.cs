using TankConstruction.Models.Base;

namespace TankConstruction.Models.UnitedStates
{
    public class UnitedStatesCompositeArmor : CompositeArmor
    {
        public UnitedStatesCompositeArmor(string serialNumber) : base(serialNumber, 300, 100)
        {
        }
    }
}
