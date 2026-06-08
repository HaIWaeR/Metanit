namespace FileTrain
{
    file class Car
    {
        public string model = "Toyota";

        public void ShowInfo() => Console.WriteLine($"Модель: {model}");
    }

    public class NewsOnTV
    {
        public void ShowInfoCar()
        {
            Car myCar = new Car();
            Console.WriteLine($"Вышла новая модель: {myCar.model}");
        } 
    }
}
