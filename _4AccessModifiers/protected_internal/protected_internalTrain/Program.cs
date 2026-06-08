namespace ToyotaAssembly
{
    // protected internal = доступно если ты либо наследник (protected), либо в той же сборке (internal).
    public class Program
    {
        static void Main(string[] args)
        {
            Car car = new Car();
            car.ShowManual();

            Console.WriteLine(new string('-', 20));

            Truck truck = new Truck();
            truck.ShowManual();

            Console.WriteLine(new string('-', 20));

            ElectricCar electricCar = new ElectricCar();
            electricCar.ShowManual();
        }
    }
}
