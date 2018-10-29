using TankConstruction.Models.Base;

namespace TankConstruction.Models.SovietUnion
{
    public class SovietUnionTankFactory : TankFactory
    {
        public SovietUnionTankFactory() : base(new SovietUnionTankComponentFactory())
        {
        }
    }
}
