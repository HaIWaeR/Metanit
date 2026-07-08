using System.Globalization;
using System.Runtime.InteropServices.Marshalling;
using System.Security.Principal;
using System.Threading.Channels;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Inheritance
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Factory factory = new Factory("Toyota");   
            factory.Print();

            Car car = new Car("Toyota", "Camry");
            car.ShowInfo();
        }
    }
    // ------------------------------------------------------------------------------------


    // Не может иметь наследника из-за модификатора sealed
    sealed class User
    {
        public string rang = "Admin";
    }

    
    // ------------------------------------------------------------------------------------


    public class Prsone
    {
        private string _name = "";
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public void Print()
        {
            Console.WriteLine(_name);
        }
    }

    // имеет доступ к полям базовго класса полями
    // private protected, public, internal. protected, protected internal
    class Employee : Prsone
    {
        public void ShowName()
        {
            Console.WriteLine(Name);

        }
    }


    // ------------------------------------------------------------------------------------


    // Ключевое слово base 
    public class Factory
    {
        public string Name;
        public Factory(string name)
        {
            Name = name;
        }
        public void Print()
        {
            Console.WriteLine($"Завод: {Name}");
        }
    }

    public class Car : Factory
    {
        public string Model;
        public Car(string name, string model) : base(name)
        {
            Model = model;
        }
        public void ShowInfo()
        {
            Console.WriteLine(new string('=', 20));
            base.Print();
            Console.WriteLine($"модель: {Model}");
        }
    }








}
