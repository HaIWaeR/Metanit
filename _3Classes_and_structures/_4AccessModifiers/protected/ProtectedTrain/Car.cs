namespace ProtectedTrain
{
    public class Car
    {
        public string model = "Passenger";
        protected string fuelType = "gasoline";

        public void ShowInfo() => Console.WriteLine($"Модель: {model}\nТип топлива: {fuelType}");
    }
}
