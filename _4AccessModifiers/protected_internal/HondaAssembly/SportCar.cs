using ToyotaAssembly;

namespace HondaAssembly
{
    public class SportCar : Car
    {
        public new string company = "Honda";
        // Работает потому что наследние
        public new void ShowManual() => Console.WriteLine($"Компания: {company}\nТранспорт: {transport}\nРуководство: {serviceManual}");
    }
}
