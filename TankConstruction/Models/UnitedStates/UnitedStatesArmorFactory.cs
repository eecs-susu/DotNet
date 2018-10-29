using TankConstruction.Models.Base;

namespace TankConstruction.Models.UnitedStates
{
    public class UnitedStatesArmorFactory : UnitedStatesBaseFactory, IArmorFactory
    {
        public Armor CreateArmor()
        {
            return new UnitedStatesArmor($"USA|A|{GenerateId()}");
        }

        public CompositeArmor CreateCompositeArmor()
        {
            return new UnitedStatesCompositeArmor($"USA|CA|{GenerateId()}");
        }

        public ReactiveArmor CreateReactiveArmor()
        {
            return new UnitedStatesReactiveArmor($"USA|RA|{GenerateId()}");
        }
    }
}
