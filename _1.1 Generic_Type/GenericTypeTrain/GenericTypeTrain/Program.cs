namespace GenericTypeTrain
{
    class Program
    {
        static void Main(string[] args)
        {
            Cell<int> cellInt = new Cell<int>(5);
            Cell<string> cellString = new Cell<string>("Hello");

            cellInt.Show();
            cellString.Show();

            //-------------------------------------------------------------------
            Console.WriteLine($"\n{new string('_', 50)}\n");

            Pair<string, int> nikol = new Pair<string, int>("Николай", 30);
            nikol.Show();

            Console.WriteLine();

            Pair<float, bool> albert = new Pair<float, bool>(25, true);
            albert.Show();

            //-------------------------------------------------------------------
            Console.WriteLine($"\n{new string('_', 50)}\n");

            Shelf<string> person = new Shelf<string>();
            person.Add("Bob");
            person.Add("Sam");
            person.Add("Tom");
            Console.WriteLine();
            person.ShowAll();
            Console.WriteLine(person.Get(1));
            Console.WriteLine();
            person.ShowAll();

            //-------------------------------------------------------------------
            Console.WriteLine($"\n{new string('_', 50)}\n");

            Shelf<(string, int)> product = new Shelf<(string, int)>();
            product.Add(("Яблоки", 8));
            product.Add(("Груши", 4));
            product.Add(("Помидоры", 10));
            product.ShowAll();

            //-------------------------------------------------------------------
            Console.WriteLine($"\n{new string('_', 50)}\n");

            Shelf<Pair<string, int>> shelfPair = new Shelf<Pair<string, int>>();
            Pair<string, int> monitor = new Pair<string, int>("Monitor", 2);
            Pair<string, int> mous = new Pair<string, int>("Mous", 5);
            shelfPair.Add(monitor);
            shelfPair.Add(mous);
            shelfPair.ShowAll();

            //-------------------------------------------------------------------
            Console.WriteLine($"\n{new string('_', 50)}\n");

            List<int> numbers = new List<int> { 1, 2, 3 };
            List<string> names = new List<string> { "Bob", "Sam", "Tom" };
            Console.WriteLine(GetLast<int>(numbers));
            Console.WriteLine(GetLast<string>(names));
        }
        public static T GetLast<T>(List<T> values)
        {
            return values[values.Count - 1];
        }
    }
}