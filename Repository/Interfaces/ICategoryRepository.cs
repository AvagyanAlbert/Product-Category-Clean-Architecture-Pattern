using Domain;
using Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface ICategoryRepository
    {
        Task<int> CreateAsync(Category category);
        Task<Category?> GetByIdAsync(int id);
        Task<List<Category>> GetAllPagedAsync(int pageNumber,int pageSize);
        Task UpdateAsync(Category category);
        Task DeleteAsync(Category category);
    }
}
