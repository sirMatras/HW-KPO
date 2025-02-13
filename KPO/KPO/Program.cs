using System;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;

namespace KPO
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("=====================================");
            Console.WriteLine("     Добро пожаловать в зоопарк     ");
            Console.WriteLine("=====================================");

            var serviceProvider = new ServiceCollection()
                .AddSingleton<IHealthCheck, VeterinaryClinic>()
                .AddTransient<IAnimalStorage>(provider => new AnimalStorage(new List<Animal>()))
                .AddSingleton<IAddToBalance, MoscowZooBalance>()
                .AddSingleton<IAddToContactZoo, MoscowZooContact>()
                .AddSingleton<MessageService>() 
                .AddTransient<Table>(provider => new Table(10, "TBL001"))
                .AddTransient<Table>(provider => new Table(5, "TBL002"))
                .AddTransient<Computer>(provider => new Computer(15, "CMP001"))
                .AddTransient<Computer>(provider => new Computer(8, "CMP002"))
                .BuildServiceProvider();

            var healthCheck = serviceProvider.GetRequiredService<IHealthCheck>();
            var addToBalance = serviceProvider.GetRequiredService<IAddToBalance>();
            var addContact = serviceProvider.GetRequiredService<IAddToContactZoo>();
            var messageService = serviceProvider.GetRequiredService<MessageService>();  
            
            Herbo animal1 = new Herbo("Трамп", "00110");
            Tiger animal2 = new Tiger("Бандера", "12345");
            Rabbit animal3 = new Rabbit("Зеленский", "012001");
            
            addToBalance.AddToBalance(animal1, healthCheck);
            addToBalance.AddToBalance(animal2, healthCheck);
            addToBalance.AddToBalance(animal3, healthCheck);
            
            Console.WriteLine();
            
            addContact.AddToContact(animal2);
            addContact.AddToContact(animal1);
            addContact.AddToContact(animal3);

            Console.WriteLine("\n===============================");
            Console.WriteLine("Животные в балансе зоопарка:");
            Console.WriteLine("===============================");
            
            var balanceAnimals = addToBalance.GetAnimalsFromBalance();
            
            if (balanceAnimals.Count == 0)
            {
                Console.WriteLine("В списке нет животных.");
            }
            else
            {
                foreach (var animal in balanceAnimals)
                {
                    Console.WriteLine($"🐾 {animal.Name} (ID: {animal.AnimalInventoryNumber})");
                    messageService.PrintFoodConsumption(animal);
                }
            }

            Console.WriteLine("\n===============================");
            Console.WriteLine("Животные в контактном зоопарке:");
            Console.WriteLine("===============================");
            
            var contactAnimals = addContact.GetAnimalsFromContact();
            
            if (contactAnimals.Count == 0)
            {
                Console.WriteLine("В списке нет животных.");
            }
            else
            {
                foreach (var animal in contactAnimals)
                {
                    Console.WriteLine($"🐾 {animal.Name} (ID: {animal.AnimalInventoryNumber})");
                }
            }

            Console.WriteLine("===============================");
            Console.WriteLine("\nИнструменты на складе:");
            Console.WriteLine("===============================");
            
            var table1 = serviceProvider.GetRequiredService<Table>();
            var table2 = serviceProvider.GetRequiredService<Table>();
            var computer1 = serviceProvider.GetRequiredService<Computer>();
            var computer2 = serviceProvider.GetRequiredService<Computer>();
            
            messageService.PrintToolReport(table1);
            messageService.PrintToolReport(table2);
            messageService.PrintToolReport(computer1);
            messageService.PrintToolReport(computer2);
            Console.WriteLine("=====================================");

            Console.WriteLine("\n=====================================");
            Console.WriteLine("        Конец отчета! Спасибо!       ");
            Console.WriteLine("=====================================");
        }
    }
}
