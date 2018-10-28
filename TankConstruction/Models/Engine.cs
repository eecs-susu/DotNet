namespace TankConstruction.Models
{
    public class Engine : TankComponent
    {
        public Engine(uint health, uint weight, string serialNumber, uint power) : base(health, weight, serialNumber)
        {
            Power = power;
        }

        public uint Power { get; }
    }
}
