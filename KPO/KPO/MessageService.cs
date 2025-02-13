namespace KPO;

public class MessageService 
{
    public void PrintToolReport(Thing tool)
    {
        Console.WriteLine($"Инвентаризационный номер предмета: {tool.InventoryNumber}." +
                      $" Количество предмета на складе: {tool.Number}.");
    }

    public void PrintFoodConsumption(Animal animal)
    {
        Console.WriteLine($"Количество потребляемой еды в день животного {animal.Name} - {animal.Food}kg");
    }
}