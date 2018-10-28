using System;

namespace TankConstruction.Models
{
    public class Gun : TankComponent
    {
        private double _accuracy;


        public Gun(uint health, uint weight, string serialNumber, uint power, double accuracy = 1) : base(health,
            weight,
            serialNumber)
        {
            Power = power;
            Accuracy = accuracy;
        }


        private double Accuracy
        {
            get => _accuracy;
            set
            {
                if (Accuracy < 0 || Accuracy > 1) throw new ArgumentException("Accuracy should be in range [0, 1]");

                _accuracy = value;
            }
        }

        private uint Power { get; }

        public uint Shoot()
        {
            return new Random().NextDouble() <= _accuracy ? Power : 0;
        }
    }
}
