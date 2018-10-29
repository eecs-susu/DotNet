using TankConstruction.Models.SovietUnion;

namespace TankConstruction.Models.Base
{
    public abstract class TankFactory
    {
        private readonly ITankComponentFactory _componentFactory;
        private readonly IArmorFactory _armorFactory;

        protected TankFactory(ITankComponentFactory componentFactory)
        {
            _componentFactory = componentFactory;
            _armorFactory = componentFactory.CreateArmorFactory();
        }

        public Tank CreateLightTank()
        {
            return new Tank(_armorFactory.CreateArmor(),
                _componentFactory.CreateEngine(),
                _componentFactory.CreateGun());
        }

        public Tank CreateCompositeTank()
        {
            return new Tank(_armorFactory.CreateCompositeArmor(),
                _componentFactory.CreateEngine(),
                _componentFactory.CreateGun());
        }

        public Tank CreateReactiveTank()
        {
            return new Tank(_armorFactory.CreateReactiveArmor(),
                _componentFactory.CreateEngine(),
                _componentFactory.CreateGun());
        }
    }
}
