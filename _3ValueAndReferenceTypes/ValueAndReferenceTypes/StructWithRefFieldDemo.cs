namespace ValueAndReferenceTypes
{
    // внутри структуры есть поле-класс
    class Book { public string Title = string.Empty; }

    struct Reader
    {
        public string Name;
        public int Age;
        public Book Book;
    }

    class StructWithRefFieldDemo
    {
        public static void Run()
        {
            Reader r1 = new Reader();
            r1.Name = "Tom";
            r1.Age = 25;
            r1.Book = new Book { Title = "1984" };

            Reader r2 = r1; // копируем структуру
            r2.Name = "Bob";
            r2.Age = 30;
            r2.Book.Title = "Brave New World"; // меняем объект в куче

            Console.WriteLine($"r1.Name = {r1.Name}"); // Tom
            Console.WriteLine($"r1.Age = {r1.Age}"); // 25
            Console.WriteLine($"r1.Book.Title = {r1.Book.Title}"); // Brave New World (изменился!)
        }
    }
}
