using Ksiazki.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ksiazki.DataAccessLayer
{
    public interface IBookRepository
    {
        IEnumerable<Book> Get();
        Book GetById(int bookId);
        void Insert(Book book);
        void Update(Book book);
        void Delete(int bookId);
        void Save();
    }
}
