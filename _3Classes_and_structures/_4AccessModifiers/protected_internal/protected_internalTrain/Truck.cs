namespace ToyotaAssembly
{
    public class Truck : Car
    {
        public new string company = "Toyota";

        // наследник потому всё хорошо
        public new void ShowManual() => Console.WriteLine($"Компания: {company}\nТранспорт: {transport}\nРуководство: {serviceManual}");
    }
}
