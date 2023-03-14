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
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private ICategoriesBL _categoriesBL;
        
        public HomeController(ILogger<HomeController> logger, ICategoriesBL categoriesBL)
        {
            _logger = logger;
            _categoriesBL = categoriesBL;
        }

        public async Task<IActionResult> Index()
        {
            var categories = await _categoriesBL.GetAllCategoriesAsync();
            var categoriesModels = categories.Select(CategoriesModel.FromEntity).ToList();
            return View(categoriesModels);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
