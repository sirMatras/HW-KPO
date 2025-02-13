namespace KPO;

public interface IAnimalStorage
{
    void AddAnimal(Animal animal);
    bool ContainAnimal(Animal animal);
    public List<Animal> GetAllAnimals();
}
public class AnimalStorage : IAnimalStorage
{
    private readonly List<Animal> _animalStorage;

    public AnimalStorage(List<Animal> animalList)
    {
        _animalStorage = animalList;
    }

    public void AddAnimal(Animal animal)
    {
        _animalStorage.Add(animal);
    }

    public bool ContainAnimal(Animal animal)
    {
        return _animalStorage.Contains(animal);
    }

    public List<Animal> GetAllAnimals()
    {
        return _animalStorage;
    }
}