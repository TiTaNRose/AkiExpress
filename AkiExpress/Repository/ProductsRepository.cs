using AkiExpress.Data;
using AkiExpress.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AkiExpress.Repository
{
    public class ProductsRepository : IProducts
    {
        private readonly ApplicationDbContext _db;
        public ProductsRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task AddAsync(Products product)
        {
            await _db.Products.AddAsync(product);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteAsync(Products product)
        {
             _db.Products.Remove(product);
            await _db.SaveChangesAsync();
        }

        public async Task<IEnumerable<Products>> GetAllAsync()
        {
            return await _db.Products.ToListAsync();
        }

        
        public async Task<Products> GetByIdAsync(int id)
        {
           return await _db.Products.Where(u => u.Id == id).FirstOrDefaultAsync();
        }

        //public async Task<GetProductsByCategory> GetProductsByCategoryId(int id)
        //{

        //    var response = new GetProductsByCategory()
        //    {
        //        Products = await _db.Products.Where(u => u.CategoryId == id).ToListAsync()
        //    };
        //    return response;
        //}

        public async Task<CategoriesDropDownList> GetCategoriesDropDownList()
        {
            var response = new CategoriesDropDownList()
            {
                Categories = await _db.Categories.OrderBy(u => u.Name).ToListAsync()    
            };
            return response;
        }

        public async Task<IEnumerable<Products>> GetProductsByCategory(int id)
        {
            return await _db.Products.Where(u => u.CategoryId == id).ToListAsync();
        }

        public async Task SaveAsync()
        {
            await _db.SaveChangesAsync();
        }

        public async Task UpdateAsync(Products product)
        {
             _db.Products.Update(product);
            await _db.SaveChangesAsync();
        }
    }
}
