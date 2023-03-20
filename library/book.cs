using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library
{
     public class book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public string ISBN { get; set; }
        public string Availability { get; set; }

        public book(string Title, string Author, string Genre, string ISBN, string Availability)
        {
            this.Title = Title;
            this.Author = Author;
            this.Genre = Genre;
            this.ISBN = ISBN;
            this.Availability = Availability;
        }

        public book()
        {
        }
    }
}
