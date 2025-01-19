using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Customer
{
    public string Name { get; set; }
    public Car? Car { get; set; }

    public Customer(string name)
    {
        Name = name;
    }

    public override string ToString()
    {
        return $"Имя: {Name}, Номер машины: {Car?.numberCar ?? -1}";
    }
}
