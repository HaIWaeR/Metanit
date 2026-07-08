namespace Сonstructor
{
    public class Program
    {
        static void Main(string[] args)
        {
            Book book1 = new Book();
            book1.Print();
            Console.WriteLine("----------------");

            Book book2 = new Book("Дары смерти");
            book2.Print();
            Console.WriteLine("----------------");

            Book book3 = new Book("Игра пристолов", "Джордж мартин");
            book3.Print();
            Console.WriteLine("----------------");

            Book book4 = new Book("Чудесный доктор", "Куприн", 1897);
            book4.Print();
            Console.WriteLine("----------------");



            Person Tom = new Person("Tom", 25);
            Tom.Print();
            Console.WriteLine("----------------");

            Person Bob = new Person("Bob");
            Bob.Print();
            Console.WriteLine("----------------");

            Person Sam = new Person();
            Sam.Print();
            Console.WriteLine("----------------");



            Students valera = new("Валера", 20, 2);
            (string name, int age, int _) = valera;
            Console.WriteLine($"{name}, {age}");
        }
    }

}
