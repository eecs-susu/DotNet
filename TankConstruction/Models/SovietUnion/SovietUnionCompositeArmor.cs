using TankConstruction.Models.Base;

namespace TankConstruction.Models.SovietUnion
{
    public class SovietUnionCompositeArmor : CompositeArmor
    {
        public SovietUnionCompositeArmor(string serialNumber) : base(serialNumber, 100, 200)
        {
        }
    }
}