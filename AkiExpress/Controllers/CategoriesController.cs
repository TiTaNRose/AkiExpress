using AkiExpress.Models;
using AkiExpress.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AkiExpress.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ICategories _categories;

        public CategoriesController(ICategories categories)
        {
            _categories = categories;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _categories.GetAllAsync();
            return View(result);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CategoryCreateVM model)
        {
            if (ModelState.IsValid)
            {
                var VM = new Categories() { Name = model.Name };
                await _categories.AddAsync(VM);

                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // Ovo je Edit

        public async Task<IActionResult> Upsert(int id)
        {
            var categoryDetails = await _categories.GetByIdAsync(id);
            if(categoryDetails == null)
            {
                return View("NotFound");
            }
            var model = new UpsertVM() { Id = categoryDetails.Id, Name = categoryDetails.Name };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Upsert(UpsertVM model)
        {
            if (ModelState.IsValid)
            {
                await _categories.UpdateAsync(model);
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var objFromDb = await _categories.GetByIdAsync(id);
            if (objFromDb != null)
            {
                await _categories.DeleteAsync(objFromDb);
                return RedirectToAction(nameof(Index));
            }
            return View("NotFound");
        }
    }
}
