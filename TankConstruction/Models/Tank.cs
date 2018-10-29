using System;

namespace TankConstruction.Models
{
    public class Tank : IMovable, IShootable, IDamageable
    {
        private readonly Armor _armor;
        private readonly Engine _engine;
        private readonly Gun _gun;

        public Tank(Armor armor, Engine engine, Gun gun)
        {
            _armor = armor;
            _engine = engine;
            _gun = gun;
        }


        public uint Move()
        {
            return _engine.Move();
        }

        public uint Shoot()
        {
            return _gun.Shoot();
        }

        public uint HealthPoints => _armor.HealthPoints;

        public void TakeDamage(uint power)
        {
            _armor.TakeDamage(power);
        }

        public bool IsDestroyed()
        {
            return _armor.IsDestroyed();
        }

        public override string ToString()
        {
            return $"Tank\nHP: {HealthPoints}\nArmor: {_armor}\nEngine: {_engine}\nGun: {_gun}";
        }
    }
}
