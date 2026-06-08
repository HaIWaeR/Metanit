namespace ToyotaAssembly
{
    public class Car
    {
        public string company = "Toyota";
        public string transport = "car";
        protected internal string serviceManual = "Доступ к инструкции";
        public void ShowManual() => Console.WriteLine($"Компания: {company}\nТранспорт: {transport}\nРуководство: {serviceManual}");
    }
}
