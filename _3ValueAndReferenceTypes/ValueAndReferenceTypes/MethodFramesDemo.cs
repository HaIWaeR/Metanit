namespace ValueAndReferenceTypes
{
    // как методы создают фреймы в стеке
    public class MethodFramesDemo
    {
        static void Calculate(int t)
        {
            int x = 6;
            int y = 7;
            int z = y + t;
            Console.WriteLine($"Calculate: t={t}, x={x}, y={y}, z={z} — все в стеке");
        }

        public static void Run()
        {
            Console.WriteLine("Вызов Calculate(5) — создаётся фрейм в стеке");
            Calculate(5);
            Console.WriteLine("Calculate завершён — фрейм удалён из стека");
        }
    }
}
