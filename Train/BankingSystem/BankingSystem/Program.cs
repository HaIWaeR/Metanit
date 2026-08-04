namespace BankingSystem
{

    public class Program
    {
        static void Main(string[] args)
        {
            BankManager bankManager = new BankManager();
            int id;
            decimal amount;
            string? input;

            while (true)
            {
                Console.WriteLine("\n1. Создать счёт");
                Console.WriteLine("2. Просмотреть все счета");
                Console.WriteLine("3. Найти счёт по id");
                Console.WriteLine("4. Положить деньги на счёт");
                Console.WriteLine("5. Снять деньги с счёта");
                Console.WriteLine("6. Перевести деньги с чёта на счёт");
                Console.WriteLine("7. История операций");
                Console.WriteLine("8. Выход");

                input = Console.ReadLine();
                if (!int.TryParse(input, out int value) || value <= 0 || value >= 9)
                {
                    Console.WriteLine("Вы ввели не корректное значение");
                    continue;
                }
                
                switch (value)
                {

                    case 1:
                        Console.Write("Ведите имя счёта: ");
                        string? ownerName = Console.ReadLine();

                        if (string.IsNullOrWhiteSpace(ownerName))
                        {
                            Console.WriteLine("Ошибка: имя не может быть пустым");
                            break;
                        }

                        if (ownerName.Length < 2)
                        {
                            Console.WriteLine("Длина имени должны быть больше 2");
                            break;
                        }

                        bankManager.CreateAccount(ownerName);
                        break;

                    case 2:
                        bankManager.ShowAllAccounts();
                        break;

                    case 3:
                        Console.Write("Введите Id: ");
                        input = Console.ReadLine();

                        if (!int.TryParse(input, out id))
                        {
                            Console.WriteLine("Ошибка: нужно ввести число!");
                            break;
                        }
                        Console.WriteLine($"\n{bankManager.GetAccountById(id)}");
                        break;

                    case 4:
                        Console.Write("\nВведите id счёта: ");
                        input = Console.ReadLine();
                        if (!int.TryParse(input, out id))
                        {
                            Console.WriteLine("Ошибка: нужно ввести число!");
                            break;
                        }

                        Console.Write("Введите сумму пополнения: ");
                        input = Console.ReadLine();
                        if (!decimal.TryParse(input, out amount))
                        {
                            Console.WriteLine("Ошибка: нужно ввести число!");
                            break;
                        }
                        
                        bankManager.DepositToAccount(id, amount);
                        break;
                    case 5:
                        Console.Write("\nВведите id счёта: ");
                        input = Console.ReadLine();
                        if (!int.TryParse(input, out id))
                        {
                            Console.WriteLine("Ошибка: нужно ввести число!");
                            break;
                        }

                        Console.Write("Ведите сумму снятия: ");
                        input = Console.ReadLine();
                        if (!decimal.TryParse(input, out amount))
                        {
                            Console.WriteLine("Ошибка: нужно ввести число!");
                            break;
                        }

                        bankManager.WithdrawFromAccount(id, amount);
                        break;
                    case 6:
                        Console.Write("Введите id отправителя : ");
                        input = Console.ReadLine();
                        if(!int.TryParse(input, out int fromId))
                        {   
                            Console.WriteLine("Ошибка: нужно ввести число!");
                            break;
                        }

                        Console.Write("Введите id получателя : ");
                        input = Console.ReadLine();
                        if (!int.TryParse(input, out int toId))
                        {
                            Console.WriteLine("Ошибка: нужно ввести число!");
                            break;
                        }

                        Console.Write("Введите сумму перевода: ");
                        input = Console.ReadLine();
                        if (!decimal.TryParse(input, out amount))
                        {
                            Console.WriteLine("Ошибка: нужно ввести число!");
                            break;
                        }

                        bankManager.Transfer(fromId, toId, amount);

                        break;

                    case 7:
                        Console.Write("Введите id ");
                        input = Console.ReadLine();
                        if (!int.TryParse(input, out id))
                        {
                            Console.WriteLine("Ошибка: нужно ввести число!");
                        }

                        bankManager.ShowTransactionHistory(id);

                        break;

                    case 8:
                        return;
                }
            }
        }
    }
}
