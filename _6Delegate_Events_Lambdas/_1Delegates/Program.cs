using System.ComponentModel.Design;

namespace Delegates
{
    // Делегат: принимает два int, возвращает int
    public delegate int Calculator(int x, int y);
    public delegate int Operation (int x, int y); 
    public class Program
    {
        static void Main(string[] args)
        {
            // Использование
            Calculator calculator = Add;
            int resultAdd = calculator(4, 5); // Вызов метода Add(4, 5)
            Console.WriteLine(resultAdd); // 9

            calculator = Multiply;
            int resultMultiply = calculator(4, 5); // Вызов метода Multiply(4, 5)
            Console.WriteLine(resultMultiply); // 20

            // Доавление и удаление методов
            Console.WriteLine($"\n{new string('_', 20)}\n");
            InvocationList invocationList = new InvocationList();
            invocationList.ShowInfo();

            // Делегат принемает метод
            Console.WriteLine($"\n{new string('_', 20)}\n");
            DoOperation(3, 2, Add);

            // Получение метода
            Console.WriteLine($"\n{new string('_', 20)}\n");
            Operation operation = SelectOperation(OperationType.Add);
            Console.WriteLine(operation(10, 4));
        }

        // Метод возращающий метод
        public static Operation SelectOperation(OperationType opType)
        {
            switch (opType)
            {
                case OperationType.Add: return Add;
                case OperationType.Multiply: return Multiply;
                default: return Subtract;
            }
        }

        // Метод принимающий метод
        public static void DoOperation(int x, int y, Calculator op)
        {
            Console.WriteLine(op(x, y));
        }


        // Методы которые соответствуют делегату
        public static int Add(int x, int y) => x + y;
        public static int  Multiply(int x, int y) => x * y;
        public static int Subtract(int x, int y) => x - y;
    }
}
