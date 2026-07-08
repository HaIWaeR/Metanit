using System.Runtime.CompilerServices;

namespace OverrideVirtual
{
    public class Program
    {
        static void Main(string[] args)
        {

            Person bob = new Person("Bob");
            bob.Print(); // Bob

            Employee employeeTom = new Employee("Tom", "Microsoft");
            employeeTom.Print(); // Tom 

            Manager sam = new Manager("Admin", "Toyota", "sam");
            sam.Print();

        }
    }

    public class Person
    {

        int age = 1;
        public virtual int Age
        {
            get { return age; }
            set { if (value > 0 || value < 100) age = value; } 
        }
        public string Name { get; set; }

        public Person(string name)
        {
            Name = name;
        }
        public virtual void Print()
        {
            Console.WriteLine($"Name: {Name}, Age: {Age}");
        }
    }


    public class Employee : Person
    {
        public string Company { get; set; }
        public override int Age
        {
            get => base.Age;
            set { if(value > 21 || value < 65) base.Age = value; }
        }

        public Employee(string name, string company) : base(name)
        {
            Company = company;
        }
        public override sealed void Print()
        {
            Console.WriteLine($"{Name}, {Company}");
        }
    }


    public class Manager : Employee
    {
        public string Role { get; set; }

        public Manager(string role, string company, string name) : base(name, company)
        {
            Role = role;
        }

        // Ошибка так как у Employee неллзя переопределить метод из-за sealed
        public override void Print()
        {
            Console.WriteLine(new string('-', 20));
            base.Print();
            Console.WriteLine(Role);
            Console.WriteLine(new string('-', 20));
        }
    }
}
