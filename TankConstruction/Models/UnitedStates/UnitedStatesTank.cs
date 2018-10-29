using TankConstruction.Models.Base;

namespace TankConstruction.Models.UnitedStates
{
    public class UnitedStatesTank : Tank
    {
        public UnitedStatesTank(Armor armor, Engine engine, Gun gun) : base(armor, engine, gun)
        {
        }
        
        public override string ToString()
        {
            return $"United States {base.ToString()}";
        }
    }
}
