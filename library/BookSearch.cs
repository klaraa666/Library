using library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSearch
{
    public class Program
    {
        private static Program? instance = null;
        library.book book = new book();
        private static string Booksfilepath = "C:\\Users\\klara.hagelin\\source\repos\\library\\library\\books.txt";

        private List<book> books = new List<book>();
        public List<book> GetBooks() { return books; }

        private Program()
        {
            LoadBooks();
        }
        public void AddBook(book book)
        {
            book.Add(book);
            Save();
        }

        public void Save()
        {
            string[] booksStringArr = books.Select(book => $"{book.Title} {book.Author} {book.Genre} {book.ISBN} {book.Availability}").ToArray();

            File.WriteAllLines(Booksfilepath, booksStringArr);
        }

        public static Program GetInstance()
        {
            if (instance == null)
            {
                instance = new Program();
            }
            return instance;
        }
        void LoadCars()
        {
            string data = File.ReadAllText(@"C:\Users\klara.hagelin\source\repos\library\library\books.txt");

            foreach (var c in data)
            {
                book book = new((string)c.Title, (string)c.Author, (string)c.Genre, (string)c.ISBN, (string)c.Availability);
                books.Add(book);
            }
        }

        static public void FussySearch()
        {
            // raderar historiken i terminalen (ascii erase display)
            Console.WriteLine("\u001b[2J\u001b[3J");
            Console.Clear();

            while (true)
            {
                Console.Write("Sök efter en bok: ");
                var query = Console.ReadLine();
                Console.WriteLine("\n");

                // raderar historiken i terminalen (ascii erase display)
                Console.WriteLine("\u001b[2J\u001b[3J");
                Console.Clear();

                Console.WriteLine($"Sök efter en nok: {query}\n");

                var result = FindBook(query);

                for (var i = 0; i < result.Count; i++)
                {
                    var book = result[i];

                    Console.WriteLine($"Model: {book.Title}");
                    Console.WriteLine($"Brand: {book.Author}");
                    Console.WriteLine($"Model Year:{book.ISBN}\n");
                }
            }

            static List<book> FindBook(string text)
            {
                var textLowerCase = text.ToLower();
                int maxDistance = 2;

                var result = new List<book>();

                foreach (var book in books)
                {
                    var TitleDistance = LevesteinDistance.GetDistance(book.Title.ToLower(), textLowerCase);
                    var AuthorDistance = LevesteinDistance.GetDistance(book.Author.ToLower(), textLowerCase);
                    var GenreDistance = LevesteinDistance.GetDistance(book.Genre.ToLower(), textLowerCase);
                    var ISBNDistance = LevesteinDistance.GetDistance(book.ISBN.ToLower(), textLowerCase);


                    if (TitleDistance <= maxDistance || AuthorDistance <= maxDistance || GenreDistance <= maxDistance || ISBNDistance <= maxDistance)
                    {
                        result.Add(book);
                    }
                }

                return result;
            }

        }
    }

}

