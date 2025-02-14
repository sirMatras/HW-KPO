using Moq;
using Xunit;

namespace KPO.Tests
{
    public class MoscowZooContactTests
    {
        private Mock<IAnimalStorage> _mockContactZooList;
        private MoscowZooContact _zooContact;

        public MoscowZooContactTests()
        {
            _mockContactZooList = new Mock<IAnimalStorage>();
            _zooContact = new MoscowZooContact(_mockContactZooList.Object);
        }

        [Fact]
        public void AddToContact_ShouldAddHerbo_WhenHealthyAndKind()
        {
            var newAnimal = new Herbo("Elephant", "123456")
            {
                HealthLevel = 8,  // Устанавливаем конкретное значение для здоровья, т.к. в классе значения рандомные.
                KindnessLevel = 6 // Устанавливаем конкретное значение для доброты, т.к. в классе значения рандомные.
            };

            _mockContactZooList.Setup(storage => storage.ContainAnimal(newAnimal)).Returns(false);
            
            _zooContact.AddToContact(newAnimal);
            
            _mockContactZooList.Verify(storage => storage.AddAnimal(newAnimal), Times.Once);
        }

        [Fact]
        public void AddToContact_ShouldNotAdd_WhenAnimalAlreadyInZoo()
        {
            var newAnimal = new Herbo("Elephant", "123456");
            _mockContactZooList.Setup(storage => storage.ContainAnimal(newAnimal)).Returns(true); 
            
            _zooContact.AddToContact(newAnimal);
            
            _mockContactZooList.Verify(storage => storage.AddAnimal(It.IsAny<Animal>()), Times.Never); 
        }

        [Fact]
        public void AddToContact_ShouldNotAdd_WhenUnhealthy()
        {
            var newAnimal = new Herbo("Elephant", "123456")
            {
                HealthLevel = 3 // Устанавливаем низкий уровень здоровья
            };

            _mockContactZooList.Setup(storage => storage.ContainAnimal(newAnimal)).Returns(false); 
            
            _zooContact.AddToContact(newAnimal);
            
            _mockContactZooList.Verify(storage => storage.AddAnimal(It.IsAny<Animal>()), Times.Never); 
        }

        [Fact]
        public void AddToContact_ShouldNotAdd_WhenKindnessLow()
        {
            var newAnimal = new Herbo("Elephant", "123456")
            {
                KindnessLevel = 3 
            };

            _mockContactZooList.Setup(storage => storage.ContainAnimal(newAnimal)).Returns(false);
            
            _zooContact.AddToContact(newAnimal);
            
            _mockContactZooList.Verify(storage => storage.AddAnimal(It.IsAny<Animal>()), Times.Never); 
        }

        [Fact]
        public void AddToContact_ShouldNotAdd_WhenNotHerbo()
        {
            var newAnimal = new Predator("Lion", "654321"); 
            _mockContactZooList.Setup(storage => storage.ContainAnimal(newAnimal)).Returns(false);
            
            _zooContact.AddToContact(newAnimal);
            
            _mockContactZooList.Verify(storage => storage.AddAnimal(It.IsAny<Animal>()), Times.Never); 
        }

        [Fact]
        public void AddToContact_ShouldAdd_WhenIsHealthyAndIsKind()
        {
            var newAnimal = new Herbo("Леонтий", "129041")
            {
                HealthLevel = 9,
                KindnessLevel = 10
            };
            
            _mockContactZooList.Setup(storage => storage.ContainAnimal(newAnimal)).Returns(false);
            
            _zooContact.AddToContact(newAnimal);
            
            _mockContactZooList.Verify(storage => storage.AddAnimal(It.IsAny<Animal>()), Times.Once);
        }
    }
}
