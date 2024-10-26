using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace A
{
   
    public abstract class Book
    {
        //название, автор, количество страниц
        public string Title { get; set; }
        public string Author { get; set; }
        public int Pages { get; set; }

        
        protected Book(string title, string author, int pages)
        {
            Title = title;
            Author = author;
            Pages = pages;
        }

        
        public abstract void DisplayInfo();
    }

    // Интерфейс IBookOperations для операций с книгами
    public interface IBookOperations
    {
        void AddBook(Book book);       // добавление книги
        void RemoveBook(string title); // Удаление
        Book FindBook(string title);   // Поиск книги
    }

    //если книга не найдена то проводятся исключения

    public class BookNotFoundException : Exception
    {
        public BookNotFoundException(string message) : base(message) { }
    }

    // Класс FictionBook
    public class FictionBook : Book
    {
        public FictionBook(string title, string author, int pages) : base(title, author, pages) { }

        //DisplayInfo для художественных книг
        public override void DisplayInfo()
        {
            Console.WriteLine($"[Художественная] Название: {Title}, Автор: {Author}, Страниц: {Pages}");
        }
    }

    // Класс NonFictionBook
    public class NonFictionBook : Book
    {
        public NonFictionBook(string title, string author, int pages) : base(title, author, pages) { }

        // Переопределяем DisplayInfo для документальных книг
        public override void DisplayInfo()
        {
            Console.WriteLine($"[Документальная] Название: {Title}, Автор: {Author}, Страниц: {Pages}");
        }
    }

    // Класс Library
    public class Library : IBookOperations
    {
        // Список книг для хранения коллекции
        private List<Book> books = new List<Book>();

        // Метод для добавления книги в библиотеку
        public void AddBook(Book book)
        {
            books.Add(book);
            Console.WriteLine($"Книга '{book.Title}' добавлена.");
        }

        //удаление книги по названию
        public void RemoveBook(string title)
        {
            var book = FindBook(title);
            if (book != null)
            {
                books.Remove(book);
                Console.WriteLine($"Книга '{title}' удалена.");
            }
            else
            {
                throw new BookNotFoundException($"Книга '{title}' не найдена.");
            }
        }

        // Метод для поиска книги по названию
        public Book FindBook(string title)
        {
            var book = books.Find(b => b.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
            if (book == null)
            {
                throw new BookNotFoundException($"Книга '{title}' не найдена.");
            }
            return book;
        }

        
        // Асинхронный метод для сохранения списка книг 
        public async Task SaveToFileAsync()
        {
            try
            {
                string json = JsonSerializer.Serialize(books);             // Преобразуем список в JSON
                await File.WriteAllTextAsync("library.txt", json);         // Асинхронно записываем JSON в файл
                Console.WriteLine("Книги загружены");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка, файлы повреждены или указаны неверно!: {ex.Message}");
            }
        }

        // Асинхронный метод для загрузки списка книг из файла
        public async Task LoadFromFileAsync()
        {
            try
            {
                // Проверяем, существует ли файл
                if (!File.Exists("library.txt"))
                {
                    Console.WriteLine("Файл library.txt не найден.");
                    return; // Если файл не найден, выходим из метода
                }

                // Читаем данные из файла асинхронно
                string json = await File.ReadAllTextAsync("library.txt");

                // Преобразуем JSON-данные в список книг
                books = JsonSerializer.Deserialize<List<Book>>(json);

                Console.WriteLine("Список книг загружен из файла.");
            }
            catch (Exception ex)
            {
                // Если произошла ошибка, выводим её сообщение
                Console.WriteLine($"Ошибка при загрузке из файла: {ex.Message}");
            }
        }
    }

    
    class Program
    {
        static async Task Main(string[] args)
        {
            Library library = new Library();

            // Добавляем книги в библиотеку
            library.AddBook(new FictionBook("Как стать геем", "Атабеков", 1200));
            library.AddBook(new NonFictionBook("АХАХАХАХААХ", "А", 2500));

            // Поиск книги и отображение информации о ней
            try
            {
                Book book = library.FindBook("Как стать геем");
                book.DisplayInfo();
            }
            catch (BookNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }

            // Удаление книги
            try
            {
                library.RemoveBook("Как стать геем");
            }
            catch (BookNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }

            

            // Асинхронное сохранение и загрузка списка книг
            await library.SaveToFileAsync();
            await library.LoadFromFileAsync();
        }
    }
}
    