using AkiExpress.Data;
using AkiExpress.Models;
using AkiExpress.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace AkiExpress.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProducts _products;
        private readonly ICategories _categories;
        private readonly ApplicationDbContext _db;

        public ProductsController(IProducts products, ICategories categories, ApplicationDbContext db)
        {
            _products = products;
            _categories = categories;
            _db = db;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _products.GetAllAsync();
            MainViewModel model = new MainViewModel();
            model.Products = result;

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var dropDownList = await _products.GetCategoriesDropDownList();

            ViewBag.Categories = new SelectList(dropDownList.Categories, "Id", "Name");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductsCreateVM model)
        {
            if (!ModelState.IsValid)
            {
                var dropDownList = await _products.GetCategoriesDropDownList();

                ViewBag.Categories = new SelectList(dropDownList.Categories, "Id", "Name");
                return View(model);
            }
            var categoryName = await _categories.GetByIdAsync(model.CategoryId);
            var items = new Products() 
            { 
                CategoryId = model.CategoryId, 
                CategoryName = categoryName.Name,
                Name = model.Name, 
                Description = model.Description,
                Quantity = model.Quantity,
                Price = model.Price,
                Thumbnail = model.Thumbnail,
                Image01 = model.Image01,
                Image02 = model.Image02,
                Image03 = model.Image03,
                Image04 = model.Image04,
                Image05 = model.Image05
            };
            await _products.AddAsync(items);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var product = await _products.GetByIdAsync(id);

            var dropDownList = await _products.GetCategoriesDropDownList();
            ViewBag.Categories = new SelectList(dropDownList.Categories, "Id", "Name");

            if (product != null)
            {
                var model = new ProductsCreateVM()
                {
                    Id = product.Id,
                    Name = product.Name,
                    CategoryId = product.CategoryId,
                    CategoryName = product.CategoryName,
                    Description = product.Description,      
                    Price = product.Price,
                    Quantity = product.Quantity,
                    Thumbnail = product.Thumbnail,
                    Image01 = product.Image01,
                    Image02 = product.Image02,
                    Image03 = product.Image03,
                    Image04 = product.Image04,
                    Image05 = product.Image05
                };
                return View(model);
            }
            return View("NotFound");
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ProductsCreateVM model)
        {
            if (ModelState.IsValid)
            {
                var categoryName = await _categories.GetByIdAsync(model.CategoryId);
                var product = new Products()
                {
                    Id = model.Id,
                    Name = model.Name,
                    CategoryId = model.CategoryId,
                    CategoryName = categoryName.Name,
                    Description = model.Description,
                    Price = model.Price,
                    Quantity = model.Quantity,
                    Thumbnail = model.Thumbnail,
                    Image01 = model.Image01,
                    Image02 = model.Image02,
                    Image03 = model.Image03,
                    Image04 = model.Image04,
                    Image05 = model.Image05
                };
                await _products.UpdateAsync(product);
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var product = await _products.GetByIdAsync(id);

            if(product != null)
            {
                await _products.DeleteAsync(product);
                return RedirectToAction(nameof(Index));
            }
            return View("NotFound");
        }

        public async Task<IActionResult> Details(ProductsCreateVM model, string name, int id)
        {
            var product = await _products.GetByIdAsync(id);
            if(product == null)
            {
                return View("NotFound");
            }
            var viewModel = new ProductsCreateVM()
            {
                Id = product.Id,
                CategoryId = product.CategoryId,
                CategoryName = product.CategoryName,
                Name = product.Name,
                Description = product.Description,
                Quantity = product.Quantity,
                Price = product.Price,
                Thumbnail = product.Thumbnail,
                Image01 = product.Image01,
                Image02 = product.Image02,
                Image03 = product.Image03,
                Image04 = product.Image04,
                Image05 = product.Image05
            };
            return View(viewModel);
        }
    }
}
