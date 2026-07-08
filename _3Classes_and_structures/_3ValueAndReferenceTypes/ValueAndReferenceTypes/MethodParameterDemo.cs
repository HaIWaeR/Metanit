namespace ValueAndReferenceTypes
{
    // передача ссылочных типов в методы
    class Person { public string name = string.Empty; }

    class MethodParameterDemo
    {
        static void ChangeWithoutRef(Person p)
        {
            p.name = "Alice"; // изменит оригинал
            p = new Person { name = "Bill" }; // не изменит оригинал
        }

        static void ChangeWithRef(ref Person p)
        {
            p.name = "Charlie"; // изменит оригинал
            p = new Person { name = "David" }; // изменит оригинал
        }

        public static void Run()
        {
            Person p1 = new Person { name = "Tom" };
            Person p2 = new Person { name = "Tom" };

            ChangeWithoutRef(p1);
            ChangeWithRef(ref p2);

            Console.WriteLine($"Без ref: p1.name = {p1.name}"); // Alice
            Console.WriteLine($"С ref:   p2.name = {p2.name}"); // David
        }
    }
}
