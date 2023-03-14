using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ShopApp.BLL.Interfaces;
using ShopApp.WebPL.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ShopApp.WebPL.Controllers
{
    public class BooksController : Controller
    {
        private readonly ILogger<BooksController> _logger;
        private IBooksBL _booksBL;

        public BooksController(ILogger<BooksController> logger, IBooksBL booksBL)
        {
            _logger = logger;
            _booksBL = booksBL;
        }
        [HttpGet]
        public async Task<IActionResult> BooksList(int categoryID)
        {
            var books = await _booksBL.GetAllBooksAsync(categoryID);
            var booksModels = books.Select(BooksModel.FromEntity).ToList();            
            return View(booksModels);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
