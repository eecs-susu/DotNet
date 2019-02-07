using TankConstruction.Models.Base;

namespace TankConstruction.Models.SovietUnion
{
    public class SovietUnionTankFactory : TankFactory
    {
        public SovietUnionTankFactory() : base(new SovietUnionTankComponentFactory())
        {
            
        }

        public override Tank CreateLightTank()
        {
            return new SovietUnionTank(_armorFactory.CreateArmor(),
                _componentFactory.CreateEngine(),
                _componentFactory.CreateGun());
        }

        public override Tank CreateCompositeTank()
        {
            return new SovietUnionTank(_armorFactory.CreateCompositeArmor(),
                _componentFactory.CreateEngine(),
                _componentFactory.CreateGun());
        }

        public override Tank CreateReactiveTank()
        {
            return new SovietUnionTank(_armorFactory.CreateReactiveArmor(),
                _componentFactory.CreateEngine(),
                _componentFactory.CreateGun());
        }
    }
}
