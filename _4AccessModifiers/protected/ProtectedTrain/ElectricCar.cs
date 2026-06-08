namespace ProtectedTrain
{
    public class ElectricCar
    {
        public string model = "electro";
        public void ShowInfo()
        {
            Console.WriteLine($"Модель: {model}");

            // protected - не достпен (не наследник)
            // Console.WriteLine(myCar.fuelType);
        }
    }
}
