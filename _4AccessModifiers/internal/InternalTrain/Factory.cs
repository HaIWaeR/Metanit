namespace InternalTrain
{
    public class ToyotaFactory
    {
        public void TestCar()
        {
            Car car = new Car();

            Console.WriteLine(car.secretOilFormula);
            car.ShowSecretFormula();

            car.ShowInfo();
        }
    }
}
