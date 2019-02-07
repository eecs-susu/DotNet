using TankConstruction.Models.Base;

namespace TankConstruction.Models.UnitedStates
{
    public class UnitedStatesTankComponentFactory : UnitedStatesBaseFactory , ITankComponentFactory
    {
        public IArmorFactory CreateArmorFactory()
        {
            return new UnitedStatesArmorFactory();
        }

        public Engine CreateEngine()
        {
           return new UnitedStatesEngine($"USA|E|{GenerateId()}");
        }

        public Gun CreateGun()
        {
            return new UnitedStatesGun($"USA|G|{GenerateId()}");
        }
    }
}
