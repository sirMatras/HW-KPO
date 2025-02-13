namespace KPO;
public interface IAddToBalance
{
    void AddToBalance(Animal newAnimal, IHealthCheck clinic);
    List<Animal> GetAnimalsFromBalance();
}

public interface IAddToContactZoo
{
    void AddToContact(Animal newAnimal);
    List<Animal> GetAnimalsFromContact();
}

public class MoscowZooBalance : IAddToBalance
{
    private readonly IAnimalStorage _animalZooBalance;

    public MoscowZooBalance(IAnimalStorage animalZooBalance)
    {
        _animalZooBalance = animalZooBalance;
    }

    public void AddToBalance(Animal newAnimal, IHealthCheck clinic)
    {
        ConsoleColor color;
        bool isHealthy = clinic.CheckHealth(newAnimal);
        
        if (!_animalZooBalance.ContainAnimal(newAnimal) && isHealthy)
        {
            color = ConsoleColor.Green;
            Console.ForegroundColor = color;
            _animalZooBalance.AddAnimal(newAnimal);
            Console.WriteLine($"Данное животное успешно добавлено в баланс:\n {newAnimal}");
            Console.ResetColor();
        }
        else if (!_animalZooBalance.ContainAnimal(newAnimal) && !isHealthy)
        {
            color = ConsoleColor.Red;
            Console.ForegroundColor = color;
            Console.WriteLine($"Данное животное {newAnimal.Name} не является здоровым. Нельзя добавить в баланс зоопарка.");
            Console.ResetColor();
        }
        else
        {
            Console.WriteLine($"Данное животное уже состоит в балансе зоопарка.");
        }
    }

    public List<Animal> GetAnimalsFromBalance()
    {
        return _animalZooBalance.GetAllAnimals();
    }
}

public class MoscowZooContact : IAddToContactZoo
{
    private readonly IAnimalStorage _contactZooList;

    public MoscowZooContact(IAnimalStorage contactZooList)
    {
        _contactZooList = contactZooList;
    }
    
    public void AddToContact(Animal newAnimal)
    {
        ConsoleColor color;
        
        if (newAnimal is Herbo herbo)
        {
            if (!_contactZooList.ContainAnimal(newAnimal) && newAnimal.IsHealthy && herbo.KindnessLevel >= 5)
            {
                color = ConsoleColor.Green;
                Console.ForegroundColor = color;
                _contactZooList.AddAnimal(newAnimal);
                Console.WriteLine($"Данное животное успешно добавлено в контактный зоопарк:\n{newAnimal}");
                Console.ResetColor();
            }
            else if (_contactZooList.ContainAnimal(newAnimal))
            {
                Console.WriteLine($"Данное животное {newAnimal.Name} уже состоит в контактном зоопарке.");
            }
            else
            {
                color = ConsoleColor.Red;
                Console.ForegroundColor = color;
                
                if (!newAnimal.IsHealthy)
                    Console.WriteLine($"Данное животное {newAnimal.Name} не может быть добавлено в контактный" +
                                      $" зоопарк из-за плохого здоровья (Здоровье - {newAnimal.HealthLevel}).");
                else if (herbo.KindnessLevel < 5)
                    Console.WriteLine($"Данное животное {newAnimal.Name} не может быть добавлено в контактный" +
                                      $" зоопарк из-за низкого уровня доброты (Доброта - {herbo.KindnessLevel}).");
                
                Console.ResetColor();
            }
        }
        else
        {
            color = ConsoleColor.Red;
            Console.ForegroundColor = color;
            Console.WriteLine($"Животное {newAnimal.Name} не может быть добавлено в контактный зоопарк," +
                              $" так как это не травоядное животное.");
            Console.ResetColor();
        }
    }
    
    public List<Animal> GetAnimalsFromContact()
    {
        return _contactZooList.GetAllAnimals();
    }
}