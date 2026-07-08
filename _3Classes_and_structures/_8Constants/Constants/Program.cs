using System.Reflection;
using System.Security.Principal;

// Система управления библиотекой
// - добавлять книги
// - просматривать список книг
// - искать книгу по автору или названию
// - удалять книгу

namespace Constants
{
    public class Program
    {
        static void Main(string[] args)
        {

        }
    }

    class Book
    {
        private string _title = String.Empty;

        private string _author = String.Empty;

        private int _year;
        private bool _isAvailable;

        public Book(string title, string author, int year, bool isAvailable = false)
        {
            _title = title;
            _author = author;
            _year = year;
            _isAvailable = isAvailable;
        }

        public string Title => _title;
        public string Author => _author;
        public int Year => _year;
        public void Print()
        {
            Console.WriteLine($"Title: {_title}, Author: {_author}, Year: {_year}");
        }
        public void SetAvailability(bool available)
        {
            _isAvailable = available;
        }
    }

    class Library
    {
        private List<Book> _books = new();

        public static int TotalBooks;

        public Library()
        {
            _books = new List<Book>();
        }

        public void AddBook(Book book)
        {
            _books.Add(book);
            TotalBooks++;
        }

        public bool RemoveBook(string title)
        {
            Book? bookToRemove = FindByTitle(title);

            if (bookToRemove is not null)
            {
                _books.Remove(bookToRemove);
                return true;
            }
            return false;
        }

        public Book? FindByTitle(string title)
        {
            _books.Find(x => x.Title == title);
            return _books.FirstOrDefault();
        }
    }
}
