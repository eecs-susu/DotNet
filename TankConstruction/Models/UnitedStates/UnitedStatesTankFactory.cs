using TankConstruction.Models.Base;

namespace TankConstruction.Models.UnitedStates
{
    public class UnitedStatesTankFactory : TankFactory
    {
        public UnitedStatesTankFactory() : base(new UnitedStatesTankComponentFactory())
        {
        }
    }
}
