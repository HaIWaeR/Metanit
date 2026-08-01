using System.Reflection.Metadata;

namespace ExceptionsTrain
{
    public class Program
    {
        static void Main(string[] args)
        {
            int x = 10;
            int y = 0;

            try
            {
                int c = x / y;
            }
            catch(DivideByZeroException ex) when (x > 20) 
            {
                Console.WriteLine($"x > 20{ex.Message}");
            }
            catch(DivideByZeroException ex) when (x > 5)
            {
                Console.WriteLine($"x > 5 {ex.Message}");
            }
            finally
            {
                Console.WriteLine("Блок finaly");
            }
        }
    }
}
