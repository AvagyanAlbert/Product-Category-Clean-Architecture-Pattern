using AutoMapper;
using Domain.ProductDTOs;
using Repository.Entities;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
    public interface IProductService
    {
        Task<int> CreateProduct(CreateProductDTO createProductDTO);
        Task<ProductDTO> GetProductById(int id);
        Task<List<ProductDTO>> GetProducts(int pageNumber, int pageSize);
        Task UpdateProduct(int id, UpdateProductDTO updateProductDTO);
        Task DeleteProduct(int id);
    }
}
