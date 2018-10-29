using TankConstruction.Models;
using Xunit;

namespace TankConstruction.Tests
{
    public class TankShould
    {
        [Fact]
        public void BeDestroyedOnFullHealthDamage()
        {
            var tank = new Tank();

            tank.TakeDamage(tank.Health);

            Assert.True(tank.IsDestroyed());
        }
    }
}
