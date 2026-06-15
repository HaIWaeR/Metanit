using System.ComponentModel;

namespace MethodOverloading
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            Calculator calculator = new Calculator();

            calculator.Add(1, 2); // 3
            calculator.Add(1, 2, 3); // 6
            calculator.Add(1, 2, 3, 4); // 10
            calculator.Add(1.5, 2.5); // 4
        }
    }

    public class Calculator
    {
        public void Add(int a, int b)
        {
            int result = a + b;
            Console.WriteLine(result);
        }
        public void Add(int a, int b, int c)
        {
            int result = a + b + c;
            Console.WriteLine(result);
        }
        public int Add (int a, int b, int c, int d)
        {
            int result = a + b + c + d;
            Console.WriteLine(result);
            return result;
        }
        public void Add (double a, double d)
        {
            double result = a + d;
            Console.WriteLine(result);
        }

        // перегружаемые методы могут отличаться по используемым модификаторам
        public void increment(int a)
        {
            a++;
            Console.WriteLine(a);
        }
        public void increment(ref int a)
        {
            a++;
            Console.WriteLine(a);
        }
    }
}
