using Commands;
using Microsoft.AspNetCore.Mvc;
using Models;
using Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookQuery _iBookQuery;
        private readonly IBookCommand _iBookCommand;
        public BookController(IBookQuery iBookQuery, IBookCommand iBookCommand)
        {
            _iBookQuery = iBookQuery;
            _iBookCommand = iBookCommand;
        }
        public async Task<IActionResult> Index()
        {
            var books = await _iBookQuery.GetAllBook();
            return View(books);
        }
        public IActionResult Create()
        {
            return View();
        }
        public async Task<IActionResult> Detail(int id)
        {
            var book = await _iBookQuery.GetBookById(id);
            return View(book);
        }
        [HttpPost]
        public async Task<IActionResult> Index(BookModel bookModel)
        {
            if (ModelState.IsValid)
            {
                await _iBookCommand.InsertBook(bookModel);
                var books = await _iBookQuery.GetAllBook();
                return View(books);
            }
            
            return View();

        }

        public async Task<IActionResult> Edit(int id)
        {
            var book = await _iBookQuery.GetBookById(id);
            return View(book);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(BookModel bookModel)
        {
            var updatedBooks = await _iBookCommand.UpdateBook(bookModel);
            return View("Edit", updatedBooks);
        }
    }
}
