namespace Сonstructor
{
    // Цеппочка конструкторов
    public class Book
    {
        public string name;
        public string author;
        public int publisherYear;

        public Book(string name, string author, int publisherYear)
        {
            this.name = name;
            this.author = author;
            this.publisherYear = publisherYear;
        }
        public Book(string name, string author) : this(name, author, 0) { }
        public Book(string name) : this(name, "Автора нету") { }
        public Book() : this("Навзания нету") { }

        public void Print()
        {
            Console.WriteLine($"Название: {name}\nАвтор: {author}\nГод выпуска: {publisherYear}");
        }
    }

}
