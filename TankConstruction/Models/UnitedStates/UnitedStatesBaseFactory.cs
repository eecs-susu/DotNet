namespace TankConstruction.Models.UnitedStates
{
    public class UnitedStatesBaseFactory
    {
        protected static string GenerateId()
        {
            return System.Guid.NewGuid().ToString();
        }
    }
}
