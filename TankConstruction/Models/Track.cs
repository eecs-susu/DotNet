namespace TankConstruction.Models
{
    public class Track : TankComponent
    {
        public Track(uint health, uint weight, string serialNumber, uint weightLimit) : base(health, weight,
            serialNumber)
        {
            WeightLimit = weightLimit;
        }

        public uint WeightLimit { get; }
    }
}
