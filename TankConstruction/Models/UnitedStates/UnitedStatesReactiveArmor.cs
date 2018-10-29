using TankConstruction.Models.Base;

namespace TankConstruction.Models.UnitedStates
{
    public class UnitedStatesReactiveArmor : ReactiveArmor
    {
        public UnitedStatesReactiveArmor(string serialNumber) : base(serialNumber, 50, 0.5)
        {
        }
    }
}
