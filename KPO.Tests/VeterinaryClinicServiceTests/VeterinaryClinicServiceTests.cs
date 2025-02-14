using Moq;
using Xunit;

namespace KPO.Tests
{
    public class VeterinaryClinicTests
    {
        private VeterinaryClinic _vetClinic;

        public VeterinaryClinicTests()
        {
            _vetClinic = new VeterinaryClinic();
        }

        // Тесты для метода CheckHealth
        [Fact]
        public void CheckHealth_ShouldReturnTrue_WhenHealthIsAboveOrEqualFive()
        {
            var healthyAnimal = new Animal("Lion", "12345") { HealthLevel = 6 };
            
            var result = _vetClinic.CheckHealth(healthyAnimal);
            
            Xunit.Assert.True(result);
        }

        [Fact]
        public void CheckHealth_ShouldReturnFalse_WhenHealthIsBelowFive()
        {
            var unhealthyAnimal = new Animal("Tiger", "54321") { HealthLevel = 3 };
            
            var result = _vetClinic.CheckHealth(unhealthyAnimal);
            
            Xunit.Assert.False(result);
        }
        
        [Fact]
        public void CheckKindness_ShouldReturnTrue_WhenKindnessIsAboveFive()
        {
            var kindHerbo = new Herbo("Elephant", "67890") { KindnessLevel = 7 };
            
            var result = _vetClinic.CheckKindness(kindHerbo);

            Xunit.Assert.True(result);
        }
        
        // Тесты для метода CheckKindness
        [Fact]
        public void CheckKindness_ShouldReturnFalse_WhenKindnessIsBelowOrEqualFive()
        {
            var unkindHerbo = new Herbo("Rabbit", "09876") { KindnessLevel = 4 };
            
            var result = _vetClinic.CheckKindness(unkindHerbo);

            Xunit.Assert.False(result);
        }

        [Fact]
        public void CheckKindness_ShouldReturnTrue_KindnessLevelAboveFive()
        {
            var kindHerbo = new Herbo("MyNigga", "12300") { KindnessLevel = 8 };

            var result = _vetClinic.CheckKindness(kindHerbo);
            
            Xunit.Assert.True(result);
        }
    }
}
