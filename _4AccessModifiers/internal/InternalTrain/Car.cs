namespace InternalTrain
{
    public class Car
    {
        public string model = "Toyota";
        internal string secretOilFormula = "T-OIL-777";
        internal void ShowSecretFormula()
        {
            Console.WriteLine($"Секретная формула масла: {secretOilFormula}");
        }
        public void ShowInfo()
        {
            Console.WriteLine($"Модель: {model}");
        }
    }
}
