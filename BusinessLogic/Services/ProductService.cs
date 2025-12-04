using AutoMapper;
using BusinessLogic.Interfaces;
using Domain.ProductDTOs;
using Repository;
using Repository.Entities;
using Repository.Interfaces;
using Repository.RepositoryServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<int> CreateProduct(CreateProductDTO createProductDTO)
        {
            var product = _mapper.Map<Product>(createProductDTO);

            await AssignCategoriesAsync(product, createProductDTO.CategoryIds);
            await _productRepository.CreateProductAsync(product);
            return product.Id;
        }

        public async Task<List<ProductDTO>> GetProducts(int pageNumber, int pageSize)
        {
            var products = await _productRepository.GetAllPagedAsync(pageNumber, pageSize);
            return _mapper.Map<List<ProductDTO>>(products);
        }

        public async Task<ProductDTO> GetProductById(int id)
        {
            var product = await GetProductOrThrowAsync(id);
            return _mapper.Map<ProductDTO>(product);
        }

        public async Task UpdateProduct(int id, UpdateProductDTO updateProductDTO)
        {
            var product = await GetProductOrThrowAsync(id);

            _mapper.Map(updateProductDTO, product);
            await AssignCategoriesAsync(product, updateProductDTO.CategoryIds);
            await _productRepository.UpdateProductAsync(product);
        }

        public async Task DeleteProduct(int id)
        {
            var product = await GetProductOrThrowAsync(id);
            await _productRepository.DeleteProductAsync(product);
        }
        private async Task AssignCategoriesAsync(Product product, List<int>? categoryIds)
        {
            product.Categories.Clear();

            if (categoryIds?.Any() == true)
            {
                var categories = await _productRepository.GetCategoriesByIdsAsync(categoryIds);
                product.Categories.AddRange(categories);
            }
        }
        private async Task<Product> GetProductOrThrowAsync(int id)
        {
            var product = await _productRepository.GetByIdWithCategoriesAsync(id);
            if (product == null)
                throw new NotFoundException($"Product with ID {id} not found");
            return product;
        }
    }
}

