namespace ProtectedTrain
{
    public class Program
    {
        // protected доступ внутри класса и в классах-наследниках
        static void Main(string[] args)
        {
            Car car = new Car();
            car.ShowInfo();

            Console.WriteLine(new String('-', 20));

            Truck truck = new Truck();
            truck.ShowInfo();

            Console.WriteLine(new String('-', 20));

            ElectricCar electric = new ElectricCar();
            electric.ShowInfo();
        }
    }
}
