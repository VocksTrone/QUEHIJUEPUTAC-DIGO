using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto02___PA
{
    public class Books
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
        public string LiteralyGenre { get; set; }
        public bool Availability { get; set; }
        public Books(string title, string author, string isbn, string literalygenre, bool availability)
        {
            Title = title;
            Author = author;
            ISBN = isbn;
            LiteralyGenre = literalygenre;
            Availability = availability;
        }   
    }
}