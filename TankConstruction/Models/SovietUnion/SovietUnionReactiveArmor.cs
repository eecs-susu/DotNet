using TankConstruction.Models.Base;

namespace TankConstruction.Models.SovietUnion
{
    public class SovietUnionReactiveArmor : ReactiveArmor
    {
        public SovietUnionReactiveArmor(string serialNumber, uint armor=100) : base(serialNumber, armor, 0.1)
        {
        }
    }
}