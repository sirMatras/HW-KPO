using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

public class Car
{
    public int numberCar { get; set; }
    public Engine engine { get; set; }

    public Car(int num)
    {
        numberCar = num;
        Random random = new Random();
        engine = new Engine(random.Next(1, 10)); 
    }

    public override string ToString()
    {
        return $"Номер: {numberCar}, Размер педалей: {engine.Size}";
    }
}
