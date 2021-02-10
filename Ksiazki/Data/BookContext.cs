using Ksiazki.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Threading.Tasks;

namespace Ksiazki.Data
{
    public class BookContext : DbContext
    {
        

        public BookContext(DbContextOptions<BookContext> options)
            : base(options)
        {
            
        }

        public DbSet<Book> Book { get; set; }

        
    }
}
