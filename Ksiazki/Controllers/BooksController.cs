using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Ksiazki.Data;
using Ksiazki.Models;
using Ksiazki.DataAccessLayer;
using Ksiazki.Service;

namespace Ksiazki.Controllers
{
    public class BooksController : Controller
    {
        /*private readonly IBookRepository _bookRepository;

        public BooksController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }*/
        private readonly IBookService _bookService;
        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        


        // GET: Books
        public IActionResult Index(/*string searchString*/)
        {

            var book = _bookService.Get();
            return View(book);


            
            /*var books = from b in _bookRepository.Get()
                        select b;

            //gdzie najlepiej dodać filtrowanie?
            if (!String.IsNullOrEmpty(searchString))
            {
                //stary linq
                books = books.Where(b => b.Author.Contains(searchString) ||
                b.Title.Contains(searchString) ||
                b.Genre.Contains(searchString));
            }

            return View(books);*/
        }



        // GET: Books/Details/5
        public ViewResult Details(int id)
        {
            Book book = _bookService.GetById(id);

            return View(book);
        }



        // GET: Books/Create
        public ActionResult Create()
        {
            return View();
        }



        // POST: Books/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("Id,Title,Author,Genre,ISBN,ReleaseDate")] Book book)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _bookService.Insert(book);
                    _bookService.Save();
                    return RedirectToAction("Create");
                }
            }
            catch (DataMisalignedException)
            {
                ModelState.AddModelError(string.Empty, "Unable to save changes.");
            }
            return View(book);
        }

        // GET: Books/Edit/5
        public ActionResult Edit(int id)
        {
            Book book = _bookService.GetById(id);
            return View(book);
        }

        // POST: Books/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, [Bind("Id,Title,Author,Genre,ISBN,ReleaseDate")] Book book)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _bookService.Update(book);
                    _bookService.Save();
                    return RedirectToAction("Index");
                }
            }
            catch (DataMisalignedException /* dex */)
            {
                //Log the error (uncomment dex variable name after DataException and add a line here to write a log.
                ModelState.AddModelError(string.Empty, "Unable to save changes. Try again, and if the problem persists contact your system administrator.");
            }
            return View(book);
        }

        // GET: Books/Delete/5
        public ActionResult Delete(bool? saveChangesError = false, int id = 0)
        {
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Delete failed. Try again, and if the problem persists see your system administrator.";
            }
            Book book= _bookService.GetById(id);
            return View(book);
        }

        // POST: Books/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                Book book = _bookService.GetById(id);
                _bookService.Delete(id);
                _bookService.Save();
            }
            catch (DataMisalignedException)
            {
                //Log the error (uncomment dex variable name after DataException and add a line here to write a log.
                return RedirectToAction("Delete", new { id = id, saveChangesError = true });
            }
            return RedirectToAction("Index");
        }



    }
}
