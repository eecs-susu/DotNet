namespace TankConstruction.Models
{
    public class SovietUnionGun : Gun
    {
        private readonly uint _power;
        private uint _ammunition;

        public SovietUnionGun(string serialNumber, uint power, uint ammunition) : base(serialNumber)
        {
            _power = power;
            _ammunition = ammunition;
        }


        public override uint Shoot()
        {
            if (_ammunition == 0u)
            {
                return 0u;
            }

            --_ammunition;
            return _power;
        }
    }
}
