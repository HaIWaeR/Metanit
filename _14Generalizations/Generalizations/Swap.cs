namespace Generalizations
{
    public class Swap
    {
        public void SwapValues<T>(ref T a, ref T b)
        {
            Console.WriteLine($"x; {a}, y; {b}");


            T temp = a;
            a = b;
            b = temp;

            Console.WriteLine($"x; {a}, y; {b}");
        }
    }
}
