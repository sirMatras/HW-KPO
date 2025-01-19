class Program
{
    static void Main()
    {
        var customers = new List<Customer>
        {
            new Customer("Ivan"),
            new Customer("Emre"),
            new Customer("Misha"),
            new Customer("Gridi")
        };

        var factory = new FactoryAF(customers);

        for (int i = 0; i < 5; i++)
            factory.AddCar();

        Console.WriteLine("Before");
        Console.WriteLine(string.Join(Environment.NewLine, factory.cars));
        Console.WriteLine(string.Join(Environment.NewLine, factory.customers));

        factory.SaleCar();

        Console.WriteLine("After");
        Console.WriteLine(string.Join(Environment.NewLine, factory.cars));
        Console.WriteLine(string.Join(Environment.NewLine, factory.customers));
    }
}