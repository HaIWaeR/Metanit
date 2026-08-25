namespace Lambdas
{
    public class Program
    {
        static void Main(string[] args)
        {
            Lambdas lambdas = new Lambdas();
            lambdas.Lobby();
        }
    }

    public class Lambdas
    {
        // Создание лямбд делегатом 
        delegate void Message(int value);
        delegate int Calc(int a, int b);

        Message Print = (int value) =>
        {
            Console.WriteLine($"Тебе {value} лет");
            if (value == 18) Console.WriteLine("Теперь можно и выпить \")");
        };

        Calc Add = (int a, int b) => a + b;

        // ----------------------------------------

        // Можно не указывать тип данных у параметров 
        delegate void Operation (int x, int y);
        Operation Multiply = (x, y) => Console.WriteLine($"{x} * {y} = {x * y}");
        // При одном параметре можнон не укзаывать скобки
        delegate void ShowInfo(string info);
        ShowInfo Show = info => Console.WriteLine(info);


        // ----------------------------------------

        // Лямбда выражения как аргумент 

        public delegate bool isEqual(int x);
        int[] integers = [1, 2, 3, 4, 5, 6, 7, 8, 9];

        public int Sum(int[] numbers, isEqual func)
        {
            int result = 0;
            foreach (int item in numbers)
            {
                if (func(item))
                {
                    result += item;
                }
            }
            return result;
        }

        // ----------------------------------------

        public void Lobby()
        {
            Print(Add(10, 8));
            Console.WriteLine($"\n{new string('_', 20)}\n");
            Multiply(10, 8);
            Show("Салам");
            Console.WriteLine($"\n{new string('_', 20)}\n");

            Console.WriteLine(Sum(integers, x => x < 5));
        }
    }
}
