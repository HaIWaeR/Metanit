namespace private_protectedTrain
{
    public class ToyotaDealer : Car
    {
        // Наследник видит vin (та же сборка)
        public void ShowCode() => Console.WriteLine(vinCode);
    }
}
