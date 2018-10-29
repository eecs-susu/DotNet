namespace TankConstruction.Models.UnitedStates
{
    public class UnitedStatesBaseFactory
    {
        protected string GenerateId()
        {
            return System.Guid.NewGuid().ToString();
        }
    }
}
