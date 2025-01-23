using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class HandCarFactory : IWorkShop
{
    public Queue<Car> handCarDepartment { get; set; } = new Queue<Car>();
    public int HandSize { get; set; }

    public HandCarFactory(int num)
    {
        HandSize = num;
    }

    public void AddToData(Car car)
    {
        handCarDepartment.Enqueue(car);
        Console.WriteLine("Машина была добавлена.");
    }

    public Car? RemoveFromData()
    {
        if (handCarDepartment.Count > 0)
        {
            var car = handCarDepartment.Dequeue();
            Console.WriteLine($"Автомобиль {car} был убран из фабрики.");
            return car;
        }
        else
        {
            Console.WriteLine("Машины с ручным двигателем закончились на складе.");
            return null;
        }
    }

    public void CreateCar()
    {
        Car newCar = new Car(handCarDepartment.Count + 1, "hand");
        handCarDepartment.Enqueue(newCar);
    }
}
