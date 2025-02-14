using Moq;
using Xunit;

namespace KPO.Tests
{
    public class MoscowZooBalanceTests
    {
        private Mock<IAnimalStorage> _mockAnimalStorage;
        private Mock<IHealthCheck> _mockHealthCheck;
        private MoscowZooBalance _zooBalance;

        public MoscowZooBalanceTests()
        {
            // Инициализация моков и тестируемого класса
            _mockAnimalStorage = new Mock<IAnimalStorage>();
            _mockHealthCheck = new Mock<IHealthCheck>();
            _zooBalance = new MoscowZooBalance(_mockAnimalStorage.Object);
        }

        // Тест 1: Метод CheckHealth возвращает true, метод ContainAnimal возвращает false => метод AddAnimal должен успешно
        // вызваться и добавить животное в баланс зоопарка.
        [Fact]
        public void AddToBalance_ShouldAddAnimal_WhenAnimalIsHealthyAndNotInBalance()
        {
            var newAnimal = new Animal("Stepan", "100191");
            _mockHealthCheck.Setup(hc => hc.CheckHealth(newAnimal)).Returns(true);
            _mockAnimalStorage.Setup(storage => storage.ContainAnimal(newAnimal)).Returns(false);
            
            _zooBalance.AddToBalance(newAnimal, _mockHealthCheck.Object);
            
            _mockAnimalStorage.Verify(storage => storage.AddAnimal(newAnimal), Times.Once);
        }

        // Тест 2: Метод ContainAnimal возвращает true => метод AddAnimal не должен вызваться, т.к. животное уже состоит на балансе.
        [Fact]
        public void AddToBalance_ShouldNotAddAnimal_WhenAnimalAlreadyInBalance()
        {
            var newAnimal = new Animal("Lora", "100891");
            _mockHealthCheck.Setup(hc => hc.CheckHealth(newAnimal)).Returns(true);
            _mockAnimalStorage.Setup(storage => storage.ContainAnimal(newAnimal)).Returns(true);
            
            _zooBalance.AddToBalance(newAnimal, _mockHealthCheck.Object);
            
            _mockAnimalStorage.Verify(storage => storage.AddAnimal(It.IsAny<Animal>()), Times.Never);
        }

        // Тест 3: В случае если значение IsHealthy устанавливается false => метод AddAnimal не должен вызваться.
        [Fact]
        public void AddToBalance_ShouldNotAddAnimal_WhenAnimalIsNotHealthyAndNotInBalance()
        {
            var newAnimal = new Animal("Clara", "132491");
            _mockHealthCheck.Setup(hc => hc.CheckHealth(newAnimal)).Returns(false);
            _mockAnimalStorage.Setup(storage => storage.ContainAnimal(newAnimal)).Returns(false);
            
            _zooBalance.AddToBalance(newAnimal, _mockHealthCheck.Object);
            
            _mockAnimalStorage.Verify(storage => storage.AddAnimal(It.IsAny<Animal>()), Times.Never);
        }
    }
}
