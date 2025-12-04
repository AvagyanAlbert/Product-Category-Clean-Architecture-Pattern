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
    public class ProductRepository:IProductRepository
    {
        private readonly ApplicationContext _dbContext;
        public ProductRepository(ApplicationContext context)
        {
            _dbContext = context;
        }
        public async Task<int> CreateProductAsync(Product product)
        {
            _dbContext.Products.Add(product);
            await _dbContext.SaveChangesAsync();
            return product.Id;
        }

        public async Task<Product?> GetByIdWithCategoriesAsync(int id)
        {
           return await _dbContext.Products
               .Include(p => p.Categories)
               .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<List<Product>> GetAllPagedAsync(int pageNumber, int pageSize)
        {
            return await _dbContext.Products
               .Include(p => p.Categories)
               .OrderBy(p => p.Id)
               .Skip((pageNumber - 1) * pageSize)
               .Take(pageSize)
               .ToListAsync();
        }

        public async Task UpdateProductAsync(Product product)
        {
            _dbContext.Products.Update(product);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteProductAsync(Product product)
        {
            _dbContext.Products.Remove(product);
            await _dbContext.SaveChangesAsync();
        }
        public async Task<List<Category>> GetCategoriesByIdsAsync(List<int> categoryIds)
        {
            return await _dbContext.Categories
                .Where(c => categoryIds.Contains(c.Id))
                .ToListAsync();
        }
    }
}

