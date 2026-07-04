namespace AbstractClass
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Абстрактные классы
            Transport ship = new Ship("катер");
            Transport car = new Car("машина");
            Transport airCraft = new Aircraft("самолёт");

            car.Move();
            ship.Move();
            airCraft.Move();

            Console.WriteLine($"\n{new string('@', 50)}\n");

            // Абстрактные свойства + Абстрактные методы
            Animal people = new Person();
            people.Age = 25;
            people.PrintAge();

            Animal cat = new Cat();
            cat.Age = 3;
            cat.PrintAge();
        }
    }
}
