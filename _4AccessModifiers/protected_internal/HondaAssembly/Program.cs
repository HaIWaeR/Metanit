namespace HondaAssembly
{
    // protected internal = доступно если ты либо наследник (protected), либо в той же сборке (internal).
    public class Program
    {
        static void Main(string[] args)
        {
            SportCar sportCar = new SportCar();
            sportCar.ShowManual();
        }
    }
}
