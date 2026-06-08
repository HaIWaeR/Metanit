namespace ToyotaAssembly
{
    public class ElectricCar
    {
        public string company = "Toyota";
        public string transport = "Electric car";
        public void ShowManual()
        {
            // Не наследник, но в той же сборке
            Car car = new Car();
            Console.WriteLine($"Компания: {company}\nТранспорт: {transport}\nРуководство: {car.serviceManual}");
        }
    }
}
