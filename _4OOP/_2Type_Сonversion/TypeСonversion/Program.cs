using System.Net.Http.Headers;
using System.Security.Authentication.ExtendedProtection;

namespace TypeСonversion
{
    public class Program
    {
        static void Main(string[] args)
        {
            Person person = new Person("Tom");
            Employee employee = new Employee("Tom", "Microsoft");

            Person person2 = employee; // Входящее преобразование 

            Person bob = new Client("Bob", "Tbank"); // Тоже восходящее преобразоввание


            Person tom = new Person("tom");
            Employee? emp = person as Employee;

            if (emp == null)
                Console.WriteLine("Это не сотрудник");
            else
                Console.WriteLine($"Сотрудник рабоатет в {emp.Company}");





            List<Animal> AnimalList = new List<Animal>();

            Animal animal = new Animal("Животное");
            Dog dog = new Dog("Собака", "Животное");
            Cat cat = new Cat("Кот", "Животное");

            AnimalList.Add(cat);
            AnimalList.Add(animal);
            AnimalList.Add(dog);

            for (int i = 0; i < AnimalList.Count; i++)
            {
                if (AnimalList[i] is Dog)
                {
                    Console.WriteLine("Гав!");
                }
                else if (AnimalList[i] is Cat)
                {
                    Console.WriteLine("Мяу!");
                }
                else if (AnimalList[i] is Animal)
                {
                    Console.WriteLine("Животное");
                }
            }
        }
    }
}