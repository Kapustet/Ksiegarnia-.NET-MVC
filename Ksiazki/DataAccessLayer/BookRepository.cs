using Ksiazki.Data;
using Ksiazki.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ksiazki.DataAccessLayer
{
    public class BookRepository : IBookRepository
    {
        private readonly BookContext _context;
        public BookRepository(BookContext context)
        {
            _context = context;
        }

        public IEnumerable<Book> Get()
        {
            return _context.Book.ToList();
        }

        public Book GetById(int bookId)
        {
            return _context.Book.Find(bookId);
        }

        public void Insert(Book book)
        {
            _context.Book.Add(book);
        }

        public void Update(Book book)
        {
            _context.Entry(book).State = EntityState.Modified;
        }

        public void Delete(int bookId)
        {
            Book book = _context.Book.Find(bookId);
            _context.Book.Remove(book);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        

        
    }
}
