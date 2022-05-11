using AkiExpress.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AkiExpress.Repository
{
    public interface IProducts
    {
        Task<CategoriesDropDownList> GetCategoriesDropDownList();
        Task<IEnumerable<Products>> GetAllAsync();
        Task<IEnumerable<Products>> GetProductsByCategory(int id);
        Task<Products> GetByIdAsync(int id);
        //Task<GetProductsByCategory> GetProductsByCategoryId(int id);
        Task AddAsync(Products product);
        Task UpdateAsync(Products product);
        Task DeleteAsync(Products product);
        Task SaveAsync();
    }
}
