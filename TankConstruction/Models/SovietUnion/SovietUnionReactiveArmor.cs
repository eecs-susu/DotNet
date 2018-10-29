using TankConstruction.Models.Base;

namespace TankConstruction.Models.SovietUnion
{
    public class SovietUnionReactiveArmor : ReactiveArmor
    {
        public SovietUnionReactiveArmor(string serialNumber) : base(serialNumber, 100, 0.1)
        {
        }
    }
}