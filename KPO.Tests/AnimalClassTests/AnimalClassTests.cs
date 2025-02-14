using Xunit;

namespace  KPO.Tests
{
    public class AnimalTests
    {
        [Fact]
        public void IsHealthy_ReturnTrue_WhenHealthLevelIsAboveOrEqualToFive()
        {
            var animal = new Animal("Lion", "12345") { HealthLevel = 6 };

            Xunit.Assert.True(animal.IsHealthy);
        }

        [Fact]
        public void IsHealthy_ReturnFalse_WhenHealthLevelIsBelowFive()
        {
            var animal = new Animal("Tiger", "54321") { HealthLevel = 3 };

            Xunit.Assert.False(animal.IsHealthy);
        }
    }

    public class HerboTests
    {
        [Fact]
        public void ToString_KindnessLevelDescription_WhenKindnessLevelIsHigh()
        {
            var herbo = new Herbo("Elephant", "67890") { KindnessLevel = 8 };

            var result = herbo.ToString();

            Xunit.Assert.Contains("Доброта: Добрый", result);
        }

        [Fact]
        public void ToString_KindnessLevelDescription_WhenKindnessLevelIsLow()
        {
            var herbo = new Herbo("Rabbit", "09876") { KindnessLevel = 3 };

            var result = herbo.ToString();

            Xunit.Assert.Contains("Доброта: Злой", result);
        }
    }
}
