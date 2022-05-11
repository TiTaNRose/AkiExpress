using AkiExpress.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AkiExpress.Repository
{
    public interface ICategories
    {
        Task<IEnumerable<Categories>> GetAllAsync();
        Task<Categories> GetByIdAsync(int id);
        Task AddAsync(Categories category);
        Task UpdateAsync(UpsertVM model);
        Task DeleteAsync(Categories category);
        Task SaveAsync(); 
    }
}
