using AkiExpress.Data;
using AkiExpress.Models;
using AkiExpress.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace AkiExpress.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IProducts _products;
        private readonly ICategories _categories;
        public HomeController(ApplicationDbContext db, UserManager<IdentityUser> userManager, IProducts products, ICategories categories)
        {
            _db = db;
            _userManager = userManager;
            _products = products;
            _categories = categories;
        }
        public async Task<IActionResult> Index()
        {
            var categories = await _categories.GetAllAsync();
            var products = await _products.GetAllAsync();

            MainViewModel model = new MainViewModel();
            model.Categories = categories;
            model.Products = products;
            return View(model);
        }

        public async Task<IActionResult> Category(int id, string name)
        {
            var products = await _products.GetProductsByCategory(id);
            if(products != null)
            {
                MainViewModel model = new MainViewModel();
                model.Products = products;

                return View(model);
            }

            return View("NotFound");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        
    }
}
