using System;
using System.Collections;
using System.Collections.Generic;

namespace TankConstruction.Models
{
    public class SovietUnionArmorFactory : SovietUnionBaseFactory, IArmorFactory
    {
        private readonly IEnumerator<Armor> _armorConveyor;
        private readonly IEnumerator<CompositeArmor> _compositeArmorConveyor;
        private readonly IEnumerator<ReactiveArmor> _reactiveArmorConveyor;

        public SovietUnionArmorFactory()
        {
            _armorConveyor = CreateConveyor(serialNumber => new SovietUnionArmor(serialNumber));
            _compositeArmorConveyor = CreateConveyor(serialNumber => new SovietUnionCompositeArmor(serialNumber));
            _reactiveArmorConveyor = CreateConveyor(serialNumber => new SovietUnionReactiveArmor(serialNumber));
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
