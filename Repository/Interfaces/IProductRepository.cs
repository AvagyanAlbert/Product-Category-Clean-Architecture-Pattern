using Domain;
using Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IProductRepository
    {
        Task<int> CreateProductAsync(Product product);
        Task<Product?> GetByIdWithCategoriesAsync(int id);
        Task<List<Product>> GetAllPagedAsync(int pageNumber, int pageSize);
        Task UpdateProductAsync(Product product);
        Task DeleteProductAsync(Product product);

        Task<List<Category>> GetCategoriesByIdsAsync(List<int> categoryIds);
    }
}
