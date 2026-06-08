using Microsoft.VisualBasic;
using System.Security.Cryptography.X509Certificates;

namespace PropertiesTrain
{
    public class Program
    {
        static void Main(string[] args)
        {

            // Свойства только для чтения и записи
            {
                Console.WriteLine($"\n{new string('@', 50)}\n");
                
                BankAccount tom = new BankAccount("132-415-22-13", "Tom", 4_500, "1234");

                tom.ShowInfo();
                tom.Deposit(500);
                tom.ShowInfo();
                tom.Withdraw(1000, "1234");
                tom.ShowInfo();

            }

            // Вычисляемые свойства
            {
                Console.WriteLine($"\n{new string('@', 50)}\n");
               
                Person person = new Person("Bob", "Sterling");
                Console.WriteLine(person.Name);
            }

            // Модификаторы доступа
            {
                Console.WriteLine($"\n{new string('@', 50)}\n");
                
                Car myCar = new Car("Billi");

                // Ошибка - set объявлен с модификатором private
                //myCar.Name = "Tom";
            }

            // Автоматические свойства 
            {
                Student student = new Student("Tim", 20);
                student.Age = 30;

                // Ошибка поле Name приватное
                //student.Name = "Salli";




            }
        }
    }
}
