using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Customer
{
    public string Name { get; set; }
    public Car? Car { get; set; }
    public int LegStrenght { get; set; }
    public int HandStrenght { get; set; }

    public Customer(string name, int leg, int hand)
    {
        Name = name;
        LegStrenght = leg;
        HandStrenght = hand;
    }
    public Customer() { }
}


