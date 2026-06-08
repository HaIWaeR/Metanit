namespace ValueAndReferenceTypes
{
    public class Program
    {
        static void Main(string[] args)
        {
            StackVsHeapDemo.Run();
            Console.WriteLine("\n-----------------------------------\n");

            MethodFramesDemo.Run();
            Console.WriteLine("\n-----------------------------------\n");

            ClassVsStructCopyDemo.Run();
            Console.WriteLine("\n-----------------------------------\n");

            StructWithRefFieldDemo.Run();
            Console.WriteLine("\n-----------------------------------\n");

            DeepCopyStructDemo.Run();
            Console.WriteLine("\n-----------------------------------\n");

            MethodParameterDemo.Run();

            Console.ReadKey();
        }
    }
}
