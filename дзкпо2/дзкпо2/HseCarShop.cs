public class HseCarShop : IWorkShop, ISalon, IGetCustomer, IAddCustomer
{
    private CustomerStorage customerStorage = new CustomerStorage();
    private CarWarehouse carWarehouse = new CarWarehouse();

    public void AddCustomer(Customer customer)
    {
        customerStorage.AddCustomer(customer);
    }

    public void AddToData(Car car)
    {
        carWarehouse.AddToData(car);
    }

    public void AddToSalon(Car car)
    {
        carWarehouse.AddToSalon(car);
    }

    public Customer GetCustomer()
    {
        return customerStorage.GetCustomer();
    }

    public Car RemoveFromData()
    {
        return carWarehouse.RemoveFromData();
    }

    public void SaleCar()
    {
        var allCustomers = customerStorage.GetAllCustomers();
        var carsInWarehouse = new List<Car>();

        while (true)
        {
            try
            {
                var car = carWarehouse.RemoveFromData();
                carsInWarehouse.Add(car);
            }
            catch (InvalidOperationException)
            {
                break;
            }
        }

        Console.WriteLine();

        foreach (var customer in allCustomers)
        {
            foreach (var car in carsInWarehouse.ToList())
            {
                if (car.Engine.IsSuitable(customer.LegStrenght) || car.Engine.IsSuitable(customer.HandStrenght))
                {
                    customer.Car = car;
                    carsInWarehouse.Remove(car);
                    Console.WriteLine($"Автомобиль {car} продан покупателю {customer.Name}.");
                    break;
                }
            }
        }

        Console.WriteLine();

        foreach (var car in carsInWarehouse)
        {
            carWarehouse.AddToData(car);
        }
    }

    public void AddCar()
    {
        carWarehouse.AddToData(new Car());
    }
}
