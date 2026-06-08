namespace ValueAndReferenceTypes
{
    // различие стека и кучи (значимые vs ссылочные типы)
    public class StackVsHeapDemo
    {
        public static void Run()
        {
            int age = 25; // int — значимый, значение в стеке
            string name = "Tom"; // string — ссылочный, ссылка в стеке, объект в куче

            Console.WriteLine($"int age = {age} (значение в стеке)");
            Console.WriteLine($"string name = {name} (ссылка в стеке, объект 'Tom' в куче)");
        }
    }
}
