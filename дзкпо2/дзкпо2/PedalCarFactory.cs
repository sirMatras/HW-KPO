using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class PedalCarFactory : IWorkShop
{
    public Queue<Car> pedalCarDepartment { get; set; } = new Queue<Car>();
    public int PedalSize { get; set; }

    public PedalCarFactory(int num)
    {
        PedalSize = num;
    }

    public void AddToData (Car car)
    {
        pedalCarDepartment.Enqueue(car);
        Console.WriteLine("Автомобиль была добавлена.");
    }

    public Car? RemoveFromData()
    {
        if (pedalCarDepartment.Count > 0)
        {
            var car = pedalCarDepartment.Dequeue();
            Console.WriteLine($"Автомобиль {car} был убран из фабрики.");
            return car;
        }
        else
        {
            Console.WriteLine("Машины с педальным двигателем закончились на складе.");
            return null;
        }
    }

    public void CreateCar()
    {
        Car newCar = new Car(pedalCarDepartment.Count + 1, "pedal");
        pedalCarDepartment.Enqueue(newCar);
    }
}
