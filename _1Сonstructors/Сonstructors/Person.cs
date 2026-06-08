namespace Сonstructor
{
    // Первичный конструктор
    public class Person(string name, int age)
    {
        public Person(string name) : this(name, 20) { }
        public Person() : this("KnownAim", 20) { }

        public void Print()
        {
            Console.WriteLine($"Имя: {name}\nВозраст: {age}");
        }
    }

}
