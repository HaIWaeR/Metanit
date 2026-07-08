using System.Security.Cryptography.X509Certificates;
using System.Xml;

namespace Generalizations
{
    public class Program
    {
        static void Main(string[] args)
        {

            // Обобщения

            Persone<int> tom = new Persone<int>(24, "Tom"); // упаковка не нжна
            Persone<string> bob = new Persone<string>("312as", "Bob");

            int idTom = tom.Id; // распаковка не нжна 
            string idBob = tom.Name; // преобразование типов не нжно

            Console.WriteLine($"Id: {idTom}, Bob: {idBob}");


            Console.WriteLine(new string('@', 50));

            // Статические поля обобщенных классов

            Car<int> car = new Car<int>(2202, "toyota");
            car.Print(); // Name: toyota, Code: 2202

            Console.WriteLine(new string('@', 50));
            car.ShowFullInfo(); // Name: toyota, Code: 2202, Serial number 0

            Console.WriteLine(new string('@', 50));
            Car<int>.SerialNumber = 123456;
            car.ShowFullInfo();// Name: toyota, Code: 2202, Serial number 123456


            // Использование нескольких универсальных параметров
            Console.WriteLine(new string('@', 50));
            Admin<int, string> moder = new Admin<int, string>(415, "qwerty", "Bili");
            Console.WriteLine(moder.Id);
            Console.WriteLine(moder.Password);

            // Обобщенные методы
            Swap swap = new Swap();
            
            Console.WriteLine(new string('@', 50));
            int x = 5;
            int y = 20;
            swap.SwapValues<int>(ref x, ref y);

            Console.WriteLine(new string('@', 50));
            string a = "Hello";
            string b = "World";
            swap.SwapValues<string>(ref a, ref b);

        }
    }
}
