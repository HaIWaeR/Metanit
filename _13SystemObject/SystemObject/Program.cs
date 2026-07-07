using System.Security.Authentication.ExtendedProtection;

namespace SystemObject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // ToString
            int i = 5;
            Console.WriteLine(i.ToString()); // Вывод: "5" 

            double d = 3.5;
            Console.WriteLine(d.ToString()); // Вывод: "3.5"

            Person person = new Person { Name = "Tom" };
            Console.WriteLine(person.ToString()); // Вывод: "SystemObject.Program+Person"

            Clock clock = new Clock { Hours = 15, Minutes = 34, Seconds = 53 };
            Console.WriteLine(clock.ToString()); // Вывод: "15:34:53"


            Console.WriteLine($"\n{new string('@', 50)}\n"); // --------------------------------------------


            // GetHashCode 
            Person2 person2 = new Person2 { Name = "Tom" };
            Console.WriteLine(person2.GetHashCode()); // Вывод: хэш-код строки "Tom"


            Console.WriteLine($"\n{new string('@', 50)}\n"); // --------------------------------------------


            // GetType
            Person billi = new Person { Name = "Billi " };
            Console.WriteLine(billi.GetType()); // SystemObject.Person
            Console.WriteLine(typeof(Person)); // SystemObject.Person

            if (person.GetType() == typeof(Person))
                Console.WriteLine("Это реально класс Person");
            // Сокращённая запись
            if (person is Person)
                Console.WriteLine("Это реально класс Person");
            // метод GetType() не переопределяется


            // Equals 
            Person p1 = new Person { Name = "Tom" };
            Person p2 = new Person { Name = "Tom" };
            Console.WriteLine(p1.Equals(p2)); // False (разные объекты в памяти)
        }
    }
}
