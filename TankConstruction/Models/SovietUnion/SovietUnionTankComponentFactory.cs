using System.Collections.Generic;
using TankConstruction.Models.Base;

namespace TankConstruction.Models.SovietUnion
{
    public class SovietUnionTankComponentFactory : SovietUnionBaseFactory, ITankComponentFactory
    {
        private readonly IEnumerator<Engine> _engineConveyor;
        private readonly IEnumerator<Gun> _gunConveyor;

        public SovietUnionTankComponentFactory()
        {
            _engineConveyor = CreateConveyor(serialNumber => new SovietUnionEngine(serialNumber, 300, 1000));
            _gunConveyor = CreateConveyor(serialNumber => new SovietUnionGun(serialNumber, 100, 200));
        }


        public IArmorFactory CreateArmorFactory()
        {
            return new SovietUnionArmorFactory();
        }

        public Engine CreateEngine()
        {
            _engineConveyor.MoveNext();
            return _engineConveyor.Current;
        }

        public Gun CreateGun()
        {
            _gunConveyor.MoveNext();
            return _gunConveyor.Current;
        }
    }
}
