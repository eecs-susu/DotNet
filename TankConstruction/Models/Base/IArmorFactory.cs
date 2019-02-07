namespace TankConstruction.Models.Base
{
    public interface IArmorFactory
    {
        Armor CreateArmor();
        CompositeArmor CreateCompositeArmor();
        ReactiveArmor CreateReactiveArmor();
    }
}
