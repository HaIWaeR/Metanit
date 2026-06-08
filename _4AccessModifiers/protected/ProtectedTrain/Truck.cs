namespace ProtectedTrain
{
    public class Truck : Car
    {
        // ключевое слово new что бы можно было применть один нейминг с наследуемым класом
        public new string model = "Cruzac";
        public new void ShowInfo() => Console.WriteLine($"Модель: {model}\nТип топлива: {fuelType}");
    }
}
