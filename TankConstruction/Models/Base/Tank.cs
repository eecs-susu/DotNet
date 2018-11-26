using System;
using System.Collections.Generic;

namespace TankConstruction.Models.Base
{
    public abstract class Tank : IMovable, IShootable, IDamageable
    {
        public readonly Armor Armor;
        protected readonly Engine Engine;
        protected readonly Gun Gun;

        public TankType Type; 

        
        protected Tank(Armor armor, Engine engine, Gun gun)
        {
            Armor = armor;
            Engine = engine;
            Gun = gun;
            Type = GetTankType(armor);
        }

        private TankType GetTankType(Armor armor)
        {
            if (Armor is CompositeArmor)
            {
                return TankType.Composite;
            }
            if (Armor is ReactiveArmor)
            {
                return TankType.Reactive;
            }

            return TankType.Light;
        }
        

        public uint Move()
        {
            return Engine.Move();
        }

        public uint Shoot()
        {
            return Gun.Shoot();
        }

        public uint Shoot(IDamageable damageable)
        {
            var damage = Shoot();
            damageable.TakeDamage(damage);
            return damage;
        }

        public uint HealthPoints => Armor.HealthPoints;

        public void TakeDamage(uint power)
        {
            Armor.TakeDamage(power);
        }

        public bool IsDestroyed()
        {
            return Armor.IsDestroyed();
        }
        
        public override string ToString()
        {
            return $"Tank\nHP: {HealthPoints}\nArmor: {Armor}\nEngine: {Engine}\nGun: {Gun}";
        }

    }
}
