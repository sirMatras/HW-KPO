using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class EngineFactory
{
    public IEngine CreateEngine(string type, int size)
    {
        switch (type.ToLower())
        {
            case "pedal":
                return new PedalEngine(size);
            case "hand":
                return new HandEngine(size);
            default:
                throw new ArgumentException("Unknown engine type");
        }
    }
}
public class Car
{
    private static int _nextCarNumber = 1; 

    public int NumberCar { get; set; }
    internal IEngine Engine { get; set; }

    public Car(int num, string type)
    {
        NumberCar = _nextCarNumber++;
        Random random = new Random();
        EngineFactory carEngine = new EngineFactory();
        Engine = carEngine.CreateEngine(type, random.Next(1, 10));
    }

    public Car() { }

    public override string ToString()
    {
        return $"Автомобиль №{NumberCar} (тип: {Engine.GetEngineType()})";
    }
}
