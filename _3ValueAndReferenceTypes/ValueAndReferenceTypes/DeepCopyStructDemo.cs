namespace ValueAndReferenceTypes
{
    // как сделать независимую копию структуры с полем-классом
    class Book2 { public string Title; }
    struct Reader2
    {
        public string Name;
        public Book2 Book;
    }

    class DeepCopyStructDemo
    {
        public static void Run()
        {
            Reader2 r1 = new Reader2();
            r1.Name = "Tom";
            r1.Book = new Book2 { Title = "1984" };

            Reader2 r2 = r1; // копия структуры
            r2.Book = new Book2(); // создаём НОВЫЙ объект в куче
            r2.Book.Title = r1.Book.Title; // копируем значение
            r2.Book.Title = "Brave New World"; // меняем новый объект

            Console.WriteLine($"r1.Book.Title = {r1.Book.Title}"); // 1984 (не изменился)
            Console.WriteLine($"r2.Book.Title = {r2.Book.Title}"); // Brave New World
        }
    }
}
