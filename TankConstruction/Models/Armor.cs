namespace TankConstruction.Models
{
    public class Armor : TankComponent
    {
        protected Armor(uint health, uint weight, string serialNumber) : base(health, weight, serialNumber)
        {
        }
    }
}
