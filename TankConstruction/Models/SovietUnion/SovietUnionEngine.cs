using TankConstruction.Models.Base;

namespace TankConstruction.Models.SovietUnion
{
    public class SovietUnionEngine : Engine
    {
        private readonly uint _power;
        private uint _fuelVolume;

        public SovietUnionEngine(string serialNumber, uint power, uint fuelVolume) : base(serialNumber)
        {
            _power = power;
            _fuelVolume = fuelVolume;
        }

        public override uint Move()
        {
            if (_fuelVolume == 0u)
            {
                return 0u;
            }

            --_fuelVolume;
            return _power;
        }
    }
}
