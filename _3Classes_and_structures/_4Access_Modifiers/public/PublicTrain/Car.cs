namespace PublicTrain
{
    public class Car
    {
        public string model = "Toyota";
        public int price = 2_500_000;

        public void ShowInfo() => Console.WriteLine($"Модель: {model}\nЦена: {price}");
    }
}
