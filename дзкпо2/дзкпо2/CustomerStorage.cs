using System;

public interface IAddCustomer
{
    void AddCustomer(Customer customer);
}

public interface IGetCustomer
{
    Customer GetCustomer();
}

public class CustomerStorage : IAddCustomer, IGetCustomer
{
    private List<Customer> customers { get; set; }

    public CustomerStorage()
    {
        customers = new List<Customer>();   
    }
    public void AddCustomer(Customer customer)
    {
        customers.Add(customer);
        Console.WriteLine($"Покупатель {customer.Name} добавлен в список покупателей.");
    }

    public Customer GetCustomer()
    {
        if (customers.Count == 0)
            throw new InvalidOperationException("Список покупателей пуст.");

        Customer customer = customers[0];
        customers.RemoveAt(0);
        Console.WriteLine($"Покупатель {customer.Name} извлечен из списка покупателей.");
        return customer;
    }

    public List<Customer> GetAllCustomers()
    {
        return customers.ToList();
    }
}