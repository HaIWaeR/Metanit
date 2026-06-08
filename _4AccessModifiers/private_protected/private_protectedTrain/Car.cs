namespace private_protectedTrain
{
    public class Car
    {
        private protected string vinCode = "Секретный VIN-код двигателя";

        // Сам класс видит свой vin 
        public void ShowFromCar() => Console.WriteLine(vinCode);
    }
}
