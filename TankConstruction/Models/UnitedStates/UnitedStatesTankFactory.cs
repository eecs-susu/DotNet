using TankConstruction.Models.Base;

namespace TankConstruction.Models.UnitedStates
{
    public class UnitedStatesTankFactory : TankFactory
    {
        public UnitedStatesTankFactory() : base(new UnitedStatesTankComponentFactory())
        {
        }

        public override Tank CreateLightTank()
        {
            return new UnitedStatesTank(_armorFactory.CreateArmor(),
                _componentFactory.CreateEngine(),
                _componentFactory.CreateGun());
        }

        public override Tank CreateCompositeTank()
        {
            return new UnitedStatesTank(_armorFactory.CreateCompositeArmor(),
                _componentFactory.CreateEngine(),
                _componentFactory.CreateGun());
        }

        public override Tank CreateReactiveTank()
        {
            return new UnitedStatesTank(_armorFactory.CreateReactiveArmor(),
                _componentFactory.CreateEngine(),
                _componentFactory.CreateGun());
        }
    }
}
