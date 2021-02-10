using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ksiazki.Models
{
    public class BookSearchModel
    {
        public List<Book> Books { get; set; }
        public SelectList Authors{ get; set; }
        public SelectList Genres { get; set; }
        public string BookGenre { get; set; }
        public string BookAuthor { get; set; }
        public string SearchString { get; set; }
        public string ISBNString { get; set; }
    }
}
