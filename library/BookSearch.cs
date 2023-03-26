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
        private static string Booksfilepath = "C:\\Users\\klara\\source\\repos\\Library\\library\\books.txt";

        public static List<book> books = new List<book>();
        public   List<book> GetBooks() { return books; }

        public void AddBook(book book)
        {
            books.Add(book);
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
        static void LoadBooks()
        {
            string[] booksdata = System.IO.File.ReadAllLines(@"C:\\Users\\klara\\source\\repos\\Library\\library\\books.txt");
            for (int i = 0; i < booksdata.Length; i++)
            {
                var line = booksdata[i].Trim();
                string[] parts = line.Split(',');
                book book = new book(parts[0], parts[1], parts[2], parts[3], parts[4]);
                books.Add(book);
            }
        }
         static public void FussySearch()
        {
            // raderar historiken i terminalen (ascii erase display)
            Console.WriteLine("\u001b[2J\u001b[3J");
            Console.Clear();
            LoadBooks();
            while (true)
            {
                Console.Write("Sök efter en bok: ");
                var query = Console.ReadLine();
                Console.WriteLine("\n");

                // raderar historiken i terminalen (ascii erase display)
                Console.WriteLine("\u001b[2J\u001b[3J");
                Console.Clear();

                Console.WriteLine($"Sök efter en bok: {query}\n");

                var result = FindBook(query);

                for (var i = 0; i < result.Count; i++)
                {
                    var book = result[i];

                    Console.WriteLine($"Title: {book.Title}");
                    Console.WriteLine($"Författare: {book.Author}");
                    Console.WriteLine($"ISBN:{book.ISBN}\n");
                }
            }
        }
        static List<book> FindBook(string text)
        {
            var textLowerCase = text.ToLower();
            int maxDistance = 2;

            var result = new List<book>();

            foreach (book book in books)
            {
                
                var TitleDistance = LevesteinDistance.GetDistance(textLowerCase, book.Title.ToLower());
                var AuthorDistance = LevesteinDistance.GetDistance(textLowerCase, book.Author.ToLower());
                var GenreDistance = LevesteinDistance.GetDistance(textLowerCase, book.Genre.ToLower());
                var ISBNDistance = LevesteinDistance.GetDistance(textLowerCase, book.ISBN.ToLower());


                if (TitleDistance <= maxDistance || AuthorDistance <= maxDistance || GenreDistance <= maxDistance || ISBNDistance <= maxDistance)
                {
                    result.Add(book);
                }
            }

            return result;
        }
    }

}

