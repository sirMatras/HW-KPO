namespace KPO;

public interface IHealthCheck
{
    bool CheckHealth(Animal newAnimal);
}
 
public interface ICheckKindness
{
    bool CheckKindness(Herbo newAnimal);
}
public class VeterinaryClinic : IHealthCheck, ICheckKindness
{
    public bool CheckHealth(Animal newAnimal)
    {
        if (newAnimal == null)
        {
            return false;
        }

        return newAnimal.HealthLevel >= 5;
    }

    public bool CheckKindness(Herbo newAnimal)
    {
        if (newAnimal.KindnessLevel > 5)
        {
            Console.WriteLine($"{newAnimal.Name} добрый. Уровень доброты - {newAnimal.KindnessLevel}.");
            return true;
        }
        else
        {
            Console.WriteLine($"{newAnimal.Name} злой. Уровень доброты - {newAnimal.KindnessLevel}.");
            return false;
        }
    }
}