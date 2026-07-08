using InternalTrain;

namespace ExternalProject
{
    public class Program
    {
        static void Main(string[] args)
        {
            Car car = new Car();
            car.ShowInfo();
            Console.WriteLine(car.model);

            // internal — не сработает в другом проекте
            // Console.WriteLine(car.secretOilFormula);
            // car.ShowSecretFormula();
        }
    }
}
