using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

public interface IWorkShop
{
    public void AddToData(Car car);
    public Car? RemoveFromData();
}

public interface ISalon
{
    public void AddToSalon(Car car);
}
public class CarWarehouse : IWorkShop, ISalon
{
    private List<Car> carSalon { get; set; }
    private Stack<Car> carWorkshop { get; set; }

    public CarWarehouse()
    {
        carWorkshop = new Stack<Car>();
        carSalon = new List<Car>();
    }

    public void AddToData(Car car)
    {
        carWorkshop.Push(car);
        Console.WriteLine("Автомобиль добавлен в цех.");
    }

    public Car RemoveFromData()
    {
        var car = carWorkshop.Pop();
        Console.WriteLine($"Автомобиль {car} был убран из цеха.");
        return car;
    }

    public void AddToSalon(Car car)
    {
        carSalon.Add(car);
        Console.WriteLine($"Автомобиль {car} был добавлен в салон.");
    }

    public void RemoveAllData()
    {
        carWorkshop.Clear();
    }
}
