namespace TankConstruction.Models
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
            return new SovietUnionTank(_armorFactory.CreateArmor(),
                _componentFactory.CreateEngine(),
                _componentFactory.CreateGun());
        }

        public Tank CreateCompositeTank()
        {
            return new SovietUnionTank(_armorFactory.CreateCompositeArmor(),
                _componentFactory.CreateEngine(),
                _componentFactory.CreateGun());
        }

        public Tank CreateReactiveTank()
        {
            return new SovietUnionTank(_armorFactory.CreateReactiveArmor(),
                _componentFactory.CreateEngine(),
                _componentFactory.CreateGun());
        }
    }
}
