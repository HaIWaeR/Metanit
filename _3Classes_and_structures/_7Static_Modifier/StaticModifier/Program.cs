using System.Net.Http.Headers;

namespace StaticModifier
{
    public class Program
    {
        static void Main(string[] args)
        {

            Car car1 = new Car("mercedes");
            Car car2 = new Car("toyota");
            Car car3 = new Car("bmv");
            Console.WriteLine(Car.TotalCars);


            Person tom = new Person(47);
            tom.ChekAge();
            Console.WriteLine($"Пенсионный возраст: {Person.RetirementAge} лет");


            Person_2 bob = new(68);
            Person_2.CheckRetirementStatus(bob);
        }

        // Статические поля
        public class Car
        {
            string model;
            public static int TotalCars;

            public Car(string model)
            {
                this.model = model;
                TotalCars++;
            }
        }

        // Статические свойства 
        class Person
        {
            int age;
            static int retirementAge = 65;
            public Person(int age)
            {
                this.age = age;
            }

            public static int RetirementAge
            {
                get { return retirementAge; }
                set { if (value > 1 && value < 100) retirementAge = value; }

            }
            public void ChekAge()
            {
                if (age >= retirementAge)
                    Console.WriteLine("Уже на пенсии");
                else
                    Console.WriteLine($"До пенсии: {retirementAge - age} лет");
            }
        }

        // статический метод 
        class Person_2
        {
            public int Age { get; set; }
            static int retirementAge = 65;
            public Person_2(int age) => Age = age;
            public static void CheckRetirementStatus(Person_2 person)
            {
                if (person.Age >= retirementAge)
                    Console.WriteLine("Уже на пенсии");
                else
                    Console.WriteLine($"Сколько лет осталось до пенсии: {retirementAge - person.Age}");
            }
        }

        // статический конструктор 


    }
}
