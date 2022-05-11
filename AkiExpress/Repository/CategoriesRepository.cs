using AkiExpress.Data;
using AkiExpress.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AkiExpress.Repository
{
    public class CategoriesRepository : ICategories
    {
        private readonly ApplicationDbContext _db;

        public CategoriesRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task AddAsync(Categories category)
        {
            await _db.Categories.AddAsync(category);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteAsync(Categories category)
        {
            _db.Categories.Remove(category);
            await _db.SaveChangesAsync();
        }

        public async Task<IEnumerable<Categories>> GetAllAsync()
        {
            return await _db.Categories.ToListAsync();
        }

        public async Task<Categories> GetByIdAsync(int id)
        {
            return await _db.Categories.FirstOrDefaultAsync(u => u.Id == id);
        }


        public async Task SaveAsync()
        {
            await _db.SaveChangesAsync();
        }

        public async Task UpdateAsync(UpsertVM model)
        {
            var dbCategory = await _db.Categories.FirstOrDefaultAsync(u => u.Id == model.Id);

            if (dbCategory != null)
            {
                dbCategory.Name = model.Name;
                await _db.SaveChangesAsync();
            }
            
        }
    }
}
