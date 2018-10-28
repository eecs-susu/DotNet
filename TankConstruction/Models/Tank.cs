using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace TankConstruction.Models
{
    public class Tank : IShootable, IMovable, IDestroyable, IWeightable
    {
        private Engine Engine { get; set; }
        private Gun Gun { get; set; }
        private Armor Armor { get; set; }
        private Track Track { get; set; }
        public uint Health => IterateOverComponents().Aggregate(0u, (r, e) => r + e.Health);

        public uint TakeDamage(uint damage)
        {
            uint activeDamage = 0;
            activeDamage += Armor?.TakeDamage(damage - activeDamage) ?? 0;
            activeDamage += Track?.TakeDamage(damage - activeDamage) ?? 0;
            activeDamage += Engine?.TakeDamage(damage - activeDamage) ?? 0;
            activeDamage += Gun?.TakeDamage(damage - activeDamage) ?? 0;
            return activeDamage;
        }


        public bool IsDestroyed()
        {
            return Health == 0;
        }

        public uint Move()
        {
            throw new NotImplementedException();
        }


        public void Shoot(IDestroyable target)
        {
            target.TakeDamage(Gun?.Shoot() ?? 0);
        }

        public uint Weight
        {
            get { return IterateOverComponents().Aggregate(0u, (r, e) => e?.Weight ?? 0); }
        }

        private IEnumerable<TankComponent> IterateOverComponents()
        {
            return from prop in GetType().GetProperties(BindingFlags.NonPublic | BindingFlags.Instance)
                where prop.GetValue(this) is TankComponent
                select prop.GetValue(this) as TankComponent;
        }

        private void CheckInstallationPossibility(IWeightable weightable)
        {
            if (!(weightable is Track) && Track == null) throw new Exception("You have to install track at first");

            if (weightable.Weight + Weight > Track.WeightLimit)
                throw new Exception("You can't install this component, because tank's track will be over weighted");
        }

        public void InstallComponent(TankComponent component)
        {
            CheckInstallationPossibility(component);
            switch (component)
            {
                case Track track:
                    Engine = null;
                    Gun = null;
                    Armor = null;
                    Track = track;
                    break;
                case Gun gun:
                    Gun = gun;
                    break;
                case Engine engine:
                    Engine = engine;
                    break;
                case Armor armor:
                    Armor = armor;
                    break;
                default:
                    throw new Exception("Unable to install this component");
            }
        }
    }
}
