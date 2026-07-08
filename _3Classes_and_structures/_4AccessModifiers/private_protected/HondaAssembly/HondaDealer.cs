using private_protectedTrain;

namespace HondaAssembly
{
    // Дилер Honda наследник, но другая сборка
    public class HondaDealer : Car
    {
        public void ShowCode()
        {
            // Наследник, но другая сборка — не видит
            // Console.WriteLine(vinCode);
        }
    }
}
