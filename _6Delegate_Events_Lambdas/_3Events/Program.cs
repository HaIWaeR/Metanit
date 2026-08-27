using System;
using System.Net.Http;

namespace EventsTrain
{
    class Program
    {
        static void Main(string[] args)
        {
            Account account = new Account(100);
            account.Notify += ShowNotify; // метод ка кобраотчие 
            account.Notify += ShowNotifyRed; // Добавление второго метода обработчика
            account.Notify += message => Console.WriteLine(message); // лямбда как обработчик
            account.Put(20); //+20
            account.PrintBalance(); // 120
            account.Notify -= ShowNotifyRed;
            account.Take(70); // -70
            account.PrintBalance(); // 50
            account.Take(180); // Ошибка
            account.PrintBalance(); // 50

            // ========================================== 
            Console.WriteLine(new string('_', 20));
            
            // Управление обработчиком
            Car car = new Car(120);
            car.carNotify += ShowNotifyRed;

            car.ShowSpead();

            car.AddSpead(30);
            car.ShowSpead();





        }
        public static void ShowNotify(string message) => Console.WriteLine(message);
        public static void ShowNotifyRed(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }

    class Car
    {
        public delegate void CarHandler(string message);
        CarHandler carHandler;

        public event CarHandler carNotify
        {
            add
            {
                carHandler += value;
                Console.WriteLine($"{value.Method.Name} добавлен");
            }
            remove
            {
                carHandler -= value;
                Console.WriteLine($"{value.Method.Name} удалён");
            }
        }
        public int Spead {  get; private set; }
        public Car(int spead) => Spead = spead;
        public void AddSpead(int spead)
        {
            Spead += spead;
            carHandler?.Invoke($"Скорость повышена на {spead}");
        }
        public void ShowSpead() => Console.WriteLine($"Скорость машины: {Spead}");
    }



    class Account
    {
        public delegate void AccountHandler(string message);
        public event AccountHandler Notify; // Определение события

        public int Sum { get; private set; }
        public Account(int sum) => Sum = sum;
        public void Put(int sum)
        {
            Sum += sum;
            Notify?.Invoke($"Пополнение на сумму: {sum}р. Ваш баланс: {Sum}р"); // Вызов события
        }
        public void Take(int sum)
        {
            if (Sum >= sum)
            {
                Sum -= sum;
                Notify?.Invoke($"Снятие на сумму: {sum}р. Ваш баланс: {Sum}р");
            }
            else
            {
                Notify?.Invoke($"Недостаточно средств. Ваш баланс {Sum}р");
            }
        }
        public void PrintBalance() => Console.WriteLine(Sum);
    }
}