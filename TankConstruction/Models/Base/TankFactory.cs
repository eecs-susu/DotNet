using TankConstruction.Models.SovietUnion;

namespace TankConstruction.Models.Base
{
    public abstract class TankFactory
    {
        protected readonly ITankComponentFactory _componentFactory;
        protected readonly IArmorFactory _armorFactory;

        protected TankFactory(ITankComponentFactory componentFactory)
        {
            _componentFactory = componentFactory;
            _armorFactory = componentFactory.CreateArmorFactory();
        }

        public abstract Tank CreateLightTank();

        public abstract Tank CreateCompositeTank();

        public abstract Tank CreateReactiveTank();
    }
}
