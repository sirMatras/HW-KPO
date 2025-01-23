using System;

class Program
{
    static void Main()
    {
        Random random = new Random();

        HseCarShop carShop = new HseCarShop();

        Customer customer1 = new Customer("Эмрэшка", random.Next(1, 10), random.Next(1, 10));
        Customer customer2 = new Customer("Пидиди", random.Next(1, 10), random.Next(1, 10));
        Customer customer3 = new Customer("Мой сладкий", random.Next(1, 10), random.Next(1, 10));
        Customer customer4 = new Customer("Палитра", random.Next(1, 10), random.Next(1, 10));
        Customer customer5 = new Customer("Гитара", random.Next(1, 10), random.Next(1, 10));
        Customer customer6 = new Customer("Кто носит фирму адидас", random.Next(1, 10), random.Next(1, 10));

        Console.WriteLine();

        carShop.AddCustomer(customer1);
        carShop.AddCustomer(customer2);
        carShop.AddCustomer(customer3);
        carShop.AddCustomer(customer4);
        carShop.AddCustomer(customer5);
        carShop.AddCustomer(customer6);

        Console.WriteLine();

        PedalCarFactory pedalFactory = new PedalCarFactory(6);
        HandCarFactory handFactory = new HandCarFactory(7);

        for (int i = 0; i < 3; i++)
        {
            pedalFactory.CreateCar();
        }

        Console.WriteLine();

        for (int i = 0; i < 3; i++)
        {
            handFactory.CreateCar();
        }

        while (true)
        {
            var pedalCar = pedalFactory.RemoveFromData();
            if (pedalCar == null) break;
            carShop.AddToData(pedalCar);
        }

        Console.WriteLine();

        while (true)
        {
            var handCar = handFactory.RemoveFromData();
            if (handCar == null) break;
            carShop.AddToData(handCar);
        }

        carShop.SaleCar();

        Console.WriteLine("\nРезультаты продаж:");
        Console.WriteLine($"{customer1.Name} получил автомобиль: {(customer1.Car != null ? customer1.Car.ToString() : "нет")}");
        Console.WriteLine($"{customer2.Name} получил автомобиль: {(customer2.Car != null ? customer2.Car.ToString() : "нет")}");
        Console.WriteLine($"{customer3.Name} получил автомобиль: {(customer3.Car != null ? customer3.Car.ToString() : "нет")}");
        Console.WriteLine($"{customer4.Name} получил автомобиль: {(customer4.Car != null ? customer4.Car.ToString() : "нет")}");
        Console.WriteLine($"{customer5.Name} получил автомобиль: {(customer5.Car != null ? customer5.Car.ToString() : "нет")}");
        Console.WriteLine($"{customer6.Name} получил автомобиль: {(customer6.Car != null ? customer6.Car.ToString() : "нет")}");
    }
}
