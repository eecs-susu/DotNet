using TankConstruction.Models.Base;

namespace TankConstruction.Models.UnitedStates
{
    public class UnitedStatesEngine : Engine
    {
        public UnitedStatesEngine(string serialNumber) : base(serialNumber)
        {
        }

        public override uint Move()
        {
            return 200;
        }
    }
}
