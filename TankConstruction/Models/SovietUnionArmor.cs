namespace TankConstruction.Models
{
    public class SovietUnionArmor : Armor
    {
        public SovietUnionArmor(string serialNumber) : base(serialNumber, 100)
        {
        }
    }

    public class SovietUnionCompositeArmor : CompositeArmor
    {
        public SovietUnionCompositeArmor(string serialNumber) : base(serialNumber, 100, 200)
        {
        }
    }

    public class SovietUnionReactiveArmor : ReactiveArmor
    {
        public SovietUnionReactiveArmor(string serialNumber) : base(serialNumber, 100, 0.1)
        {
        }
    }
}
