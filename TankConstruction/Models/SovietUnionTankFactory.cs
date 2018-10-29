namespace TankConstruction.Models
{
    public class SovietUnionTankFactory : TankFactory
    {
        public SovietUnionTankFactory() : base(new SovietUnionTankComponentFactory())
        {
        }
    }
}
