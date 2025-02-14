namespace KPO;

interface IAlive
{
    int Food { get; set; }
}

public class Animal : IAlive
{
    public static Random _rnd = new Random();
    public string Name { get; set; }
    public int Food { get; set; }
    public int HealthLevel { get; set; }
    public string AnimalInventoryNumber { get; set; }
    
    public Animal(string name, string invNumber)
    {
        Name = name;
        AnimalInventoryNumber = invNumber;
        Food = _rnd.Next(1, 10);
        HealthLevel = _rnd.Next(1, 10);
    }

    public bool IsHealthy
    {
        get { return HealthLevel >= 5; }
    }

    public override string ToString()
    {
        return $"{Name} (ID: {AnimalInventoryNumber}) - Еда: {Food}kg, Уровень здоровья (1-10): {HealthLevel}," +
               $" Здоровье: {(IsHealthy ? "Здоровый" : "Не здоровый")}";
    }
}

public class Predator : Animal
{
    public Predator(string name, string invNumber) : base(name, invNumber){}
}

public class Herbo : Animal
{
    public int KindnessLevel { get; set; }

    public Herbo(string name, string invNumber) : base(name, invNumber)
    {
        KindnessLevel = _rnd.Next(1, 10);
    }

    public override string ToString()
    {
        return
            $"{Name} (ID: {AnimalInventoryNumber}) - Еда: {Food}kg, Уровень здоровья (1-10): {HealthLevel}," +
            $" Здоровье: {(IsHealthy ? "Здоровый" : "Не здоровый")}," +
            $" Уровень доброты (1-10): {KindnessLevel}. Доброта: {(KindnessLevel >= 5? "Добрый" : "Злой")}";
    }
}

public class Monkey : Herbo
{
    public Monkey(string name, string invNumber) : base(name, invNumber){}
}

public class Rabbit : Herbo
{
    public Rabbit(string name, string invNumber) : base(name, invNumber){}
}

public class Tiger : Predator
{
    public Tiger(string name, string invNumber) : base(name, invNumber){}
}

public class Wolf : Predator
{
    public Wolf(string name, string invNumber) : base(name, invNumber){}
}

