using TankConstruction.Models;
using TankConstruction.Models.Base;
using TankConstruction.Models.SovietUnion;
using Xunit;

namespace TankConstruction.Tests
{
    public class TankShould
    {

        private readonly TankFactory _factory;
        public TankShould()
        {
            _factory = new SovietUnionTankFactory();
        }
        
        
        [Fact]
        public void BeDestroyedOnFullHealthDamage()
        {
            var tank = _factory.CreateLightTank();
            tank.TakeDamage(tank.HealthPoints);
            Assert.Equal(0u, tank.HealthPoints);
        }
        
        [Fact]
        public void BeInitializedWithNoZeroHealthPoints()
        {
            var tank = _factory.CreateLightTank();
            Assert.NotEqual(0u, tank.HealthPoints);
        }
        
        [Fact]
        public void DealDamageToOtherTank()
        {
            var damageProvider = _factory.CreateLightTank();
            var damageReceiver = _factory.CreateLightTank();
            var sourceHealthPoints = damageReceiver.HealthPoints;
            damageProvider.Shoot(damageReceiver);
            Assert.True(sourceHealthPoints > damageReceiver.HealthPoints);
        }
        
        [Fact]
        public void ProvideNoZeroDamage()
        {
            var tank = _factory.CreateLightTank();
            var damage = tank.Shoot();
            Assert.NotEqual(0u, damage);
        }
    }
}
