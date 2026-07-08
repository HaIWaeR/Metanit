namespace Structures
{
    public class Program
    {
        static void Main(string[] args)
        {
            Person nekit = new Person() { name = "Никита", age = 18 };
            nekit.Print();

            Person bob = nekit with { name = "боб" };
            bob.Print();

            Person tom = new Person() { name = "том" };
            tom.Print();

            Person sam = new Person();
            sam.Print();
        }
    }
}
