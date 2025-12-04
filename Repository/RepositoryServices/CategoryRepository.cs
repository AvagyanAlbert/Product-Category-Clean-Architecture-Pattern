using Microsoft.EntityFrameworkCore;
using Repository.Entities;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.RepositoryServices
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationContext _dbContext;
        public CategoryRepository(ApplicationContext context)
        {
            _dbContext = context;
        }
        public async Task<int> CreateAsync(Category category)
        {
            await _dbContext.Categories.AddAsync(category);
            await _dbContext.SaveChangesAsync();
            return category.Id;
        }
        public async Task<Category?> GetByIdAsync(int id)
        {
            return await _dbContext.Categories.FirstOrDefaultAsync(c => c.Id == id);
        }
        public async Task<List<Category>> GetAllPagedAsync(int pageNumber, int pageSize)
        {
            return await _dbContext.Categories
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }
        public async Task UpdateAsync(Category category)
        {
            _dbContext.Categories.Update(category);
            await _dbContext.SaveChangesAsync();
        }
        public async Task DeleteAsync(Category category)
        {
            _dbContext.Categories.Remove(category);
            await _dbContext.SaveChangesAsync();
        }
    }
}
