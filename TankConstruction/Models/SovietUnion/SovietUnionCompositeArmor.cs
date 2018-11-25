using TankConstruction.Models.Base;

namespace TankConstruction.Models.SovietUnion
{
    public class SovietUnionCompositeArmor : CompositeArmor
    {
        public SovietUnionCompositeArmor(string serialNumber, uint armor=100) : base(serialNumber, armor, 200)
        {
        }
    }
}