namespace TankConstruction.Models
{
    public class SovietUnionTank : Tank
    {
        public SovietUnionTank(Armor armor, Engine engine, Gun gun) : base(armor, engine, gun)
        {
        }

        public override string ToString()
        {
            return $"Soviet Union {base.ToString()}";
        }
    }
}
