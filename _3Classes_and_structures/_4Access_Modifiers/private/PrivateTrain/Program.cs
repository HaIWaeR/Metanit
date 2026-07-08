namespace PrivateTrain
{
    // private - доступен только в рамках своего класса 
    public class Program
    {
        static void Main(string[] args)
        {
            Car Toyota = new Car();

            Toyota.carInfo();

            Console.WriteLine(new String('-', 20));

            Toyota.FullInfo();
        }
    }
}
