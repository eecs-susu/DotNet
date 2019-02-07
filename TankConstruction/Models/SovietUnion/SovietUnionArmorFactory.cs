using System.Collections.Generic;
using TankConstruction.Models.Base;

namespace TankConstruction.Models.SovietUnion
{
    public class SovietUnionArmorFactory : SovietUnionBaseFactory, IArmorFactory
    {
        private readonly IEnumerator<Armor> _armorConveyor;
        private readonly IEnumerator<CompositeArmor> _compositeArmorConveyor;
        private readonly IEnumerator<ReactiveArmor> _reactiveArmorConveyor;

        public SovietUnionArmorFactory()
        {
            _armorConveyor = CreateConveyor(serialNumber => new SovietUnionArmor(serialNumber, 100));
            _compositeArmorConveyor = CreateConveyor(serialNumber => new SovietUnionCompositeArmor(serialNumber, 200));
            _reactiveArmorConveyor = CreateConveyor(serialNumber => new SovietUnionReactiveArmor(serialNumber, 300));
        }

        public Armor CreateArmor()
        {
            _armorConveyor.MoveNext();
            return _armorConveyor.Current;
        }

        public CompositeArmor CreateCompositeArmor()
        {
            _compositeArmorConveyor.MoveNext();
            return _compositeArmorConveyor.Current;
        }

        public ReactiveArmor CreateReactiveArmor()
        {
            _reactiveArmorConveyor.MoveNext();
            return _reactiveArmorConveyor.Current;
        }
    }
}
