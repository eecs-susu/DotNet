namespace TankConstruction.Models.Base
{
    public interface ITankComponentFactory
    {
        IArmorFactory CreateArmorFactory();
        Engine CreateEngine();
        Gun CreateGun();
    }
}

