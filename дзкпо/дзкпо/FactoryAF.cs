using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class FactoryAF
{
    public List<Customer> customers {  get; set; }
    public Queue<Car> cars { get; set; }

    public FactoryAF(List<Customer> list)
    {
        customers = list;
        cars = new Queue<Car>();
    }

    public void SaleCar()
    {
        foreach (var customer in customers)
        {
            customer.Car = cars.Dequeue();
            if (customer.Car == null)
                break;
        }

        customers = customers.Where(customer => customer.Car != null).ToList();

        cars.Clear();
    }

    public void AddCar()
    {
        cars.Enqueue(new Car(cars.Count + 1));
    }
}