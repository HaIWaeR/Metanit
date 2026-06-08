namespace private_protectedTrain
{
    public class CarService
    {
        // Автосервис (не наследник, та же сборка)
        public void ShowCode()
        {
            Car car = new Car();
            // Не наследник — не видит
            // Console.WriteLine(car.vinCode);
        }
    }
}
