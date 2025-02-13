namespace KPO;

interface IInventory
{
    int Number { get; set; }
    string InventoryNumber { get; set; }
}

public class Thing : IInventory
{
    public string InventoryNumber { get; set; }
    public int Number { get; set; }

    public Thing(int number, string invNumber)
    {
        Number = number;
        InventoryNumber = invNumber;
    }
}

class Table : Thing
{
    public Table(int number, string invNumber) : base(number, invNumber) {}
}

class Computer : Thing
{
    public Computer(int number, string invNumber) : base(number, invNumber) {}
}