namespace TankConstruction.Models.Base
{
    public abstract class TankComponent
    {
        public readonly string SerialNumber;

        protected TankComponent(string serialNumber)
        {
            SerialNumber = serialNumber;
        }

        public override string ToString()
        {
            return $"Serial number: {SerialNumber}";
        }
    }
}
