using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ksiazki.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public string ISBN { get; set; }

        
        [DataType(DataType.Date)]
        [Display(Name = "Release Date")]
        /*[DisplayFormat(DataFormatString = "{0:MM/yyyy}", ApplyFormatInEditMode = true)]*/
        public DateTime ReleaseDate { get; set; }

    }
}
