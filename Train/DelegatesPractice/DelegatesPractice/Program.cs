using DelegatesPractice.Processing;
using DelegatesPractice.Models;
using System.Numerics;
using System.Net.Http.Headers;

namespace DelegatesPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach (var client in SeedData.Clients)
            {
                Console.WriteLine(client);
            }

            Console.WriteLine($"\n{new string('_', 50)}\n");

            foreach (var order in SeedData.Orders)
            {
                Console.WriteLine(order);
            }

            // -------------------------------------------------------------------------------
            Console.WriteLine($"\n{new string('_', 50)}\n");

            Order order1 = SeedData.Orders[0];
            Order order2 = SeedData.Orders[9];

            DiscountRule rule = DiscountRules.RegularClientDiscount;
            Console.WriteLine($"Заказ #{order1.Id}: было {order1.Amount}, стало {rule(order1)}");

            rule = DiscountRules.LargeAmountDiscount;
            Console.WriteLine($"Заказ #{order1.Id}: было {order1.Amount}, стало {rule(order1)}");

            rule = DiscountRules.NoDiscount;
            Console.WriteLine($"Заказ #{order1.Id}: было {order1.Amount}, стало {rule(order1)}");

            rule = DiscountRules.RegularClientDiscount;
            Console.WriteLine($"Заказ #{order2.Id}: было {order2.Amount}, стало {rule(order2)}");

            rule = DiscountRules.LargeAmountDiscount;
            Console.WriteLine($"Заказ #{order2.Id}: было {order2.Amount}, стало {rule(order2)}");

            rule = DiscountRules.NoDiscount;
            Console.WriteLine($"Заказ #{order2.Id}: было {order2.Amount}, стало {rule(order2)}");


            // -------------------------------------------------------------------------------
            Console.WriteLine($"\n{new string('_', 50)}\n");

            Loggers logers = new Loggers();
            
            LogsAction logs = logers.PrintMessage;
            logs += logers.AddMessageToList;
            logs += logers.IncrementCount;
            logs("Аджара гуджу");
            Console.WriteLine($"Колличетсво методов в делегате: {logs.GetInvocationList().Length}");
            Console.WriteLine($"Колличество сообщений: {logers.Count}");
            logers.ShowInfo();
            
            Console.WriteLine();

            logs -= logers.PrintMessage;
            logs("Шнейне пепеа");
            Console.WriteLine($"Колличетсво методов в делегате: {logs.GetInvocationList().Length}");
            Console.WriteLine($"Колличество сообщений: {logers.Count}");
            logers.ShowInfo();

            // -------------------------------------------------------------------------------
            Console.WriteLine($"\n{new string('_', 50)}\n");
            
            Order order3 = SeedData.Orders[9];

            DiscountRule tenPercent = DiscountRules.CreateDiscountRule(10);
            DiscountRule twentyPercent = DiscountRules.CreateDiscountRule(20);

            Console.WriteLine();
            Console.WriteLine($"Было {order3.Amount}");
            Console.WriteLine($"Скидка 10%: {tenPercent(order3)}");
            Console.WriteLine($"Скидка 20%: {twentyPercent(order3)}");





        }
    }
}