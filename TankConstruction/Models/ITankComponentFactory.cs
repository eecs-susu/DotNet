namespace TankConstruction.Models
{
    public interface ITankComponentFactory
    {
        IArmorFactory CreateArmorFactory();
        Engine CreateEngine();
        Gun CreateGun();
    }
}

