using TankConstruction.Models;
using Xunit;

namespace TankConstruction.Tests
{
    public class TankShould
    {
        private class TankEntity : Tank
        {
            public TankEntity() : base(100)
            {
            }
        }

        [Fact]
        public void BeDestoyedOnFullHealthDamage()
        {
            var tank = new TankEntity();

            tank.TakeDamage(tank.Health);

            Assert.True(tank.IsDestroyed());
        }
    }
}
