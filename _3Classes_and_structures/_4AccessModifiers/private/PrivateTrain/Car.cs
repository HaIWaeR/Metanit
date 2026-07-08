namespace PrivateTrain
{
    public class Car
    {
        public string model = "Toyota";
        public int price = 2_500_000;
        private int mileage = 120_000;
        private void mileageInfo() => Console.WriteLine(mileage);
        public void carInfo() => Console.WriteLine($"Модель: {model}\nЦена: {price}");

        public void FullInfo()
        {
            mileageInfo();
            carInfo();
        }
    }
}
