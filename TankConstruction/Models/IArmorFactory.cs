namespace TankConstruction.Models
{
    public interface IArmorFactory
    {
        Armor CreateArmor();
        CompositeArmor CreateCompositeArmor();
        ReactiveArmor CreateReactiveArmor();
    }
}
