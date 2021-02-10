using Ksiazki.DataAccessLayer;
using Ksiazki.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ksiazki.Service
{
    public interface IBookService {
        IEnumerable<Book> Get();
        Book GetById(int bookId);
        void Insert(Book book);
        void Update(Book book);
        void Delete(int bookId);
        void Save();
    }
    
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public IEnumerable<Book> Get()
        {
            var book = _bookRepository.Get();
            return book;
        }
        public Book GetById(int bookId)
        {
            var book = _bookRepository.GetById(bookId);
            return book;
        }
        /*void Insert(Book book)
        {
            _bookRepository.Insert(book);

        }
        void Update(Book book)
        {
            _bookRepository.Update(book);
        }
        void Delete(int bookId)
        {
            _bookRepository.Delete(bookId);
            
        }*/

        void IBookService.Insert(Book book)
        {
            _bookRepository.Insert(book);
        }

        void IBookService.Update(Book book)
        {
            _bookRepository.Update(book);
        }

        void IBookService.Delete(int bookId)
        {
            _bookRepository.Delete(bookId);
        }

        void IBookService.Save()
        {
            _bookRepository.Save();
        }

    }
}
