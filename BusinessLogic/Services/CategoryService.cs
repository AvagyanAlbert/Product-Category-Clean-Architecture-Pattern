using AutoMapper;
using BusinessLogic.Interfaces;
using Domain.CategoryDTOs;
using Repository.Entities;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class CategoryService:ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        public CategoryService(ICategoryRepository categoryRepository,IMapper mapper)
        {
            _categoryRepository=categoryRepository;
            _mapper=mapper;
        }

        public async Task<int> Create(CreateCategoryDTO createCategoryDTO)
        {
            var createdCategory = _mapper.Map<Category>(createCategoryDTO);
            await _categoryRepository.CreateAsync(createdCategory);
            return createdCategory.Id;
        }
        public async Task<CategoryDTO> GetById(int id)
        {
            var category = await GetCategoryOrThrowExceptionAsync(id);
            return _mapper.Map<CategoryDTO>(category);
        }

        public async Task<List<CategoryDTO>> GetAllPaged(int pageNumber, int pageSize)
        {
            var categories = await _categoryRepository.GetAllPagedAsync(pageNumber, pageSize);
            return _mapper.Map<List<CategoryDTO>>(categories);
        }


        public async Task Update(int id, UpdateCategoryDTO updateCategoryDTO)
        {
            var category = await GetCategoryOrThrowExceptionAsync(id);
            _mapper.Map(updateCategoryDTO, category);
            await _categoryRepository.UpdateAsync(category);
        }
        public async Task Delete(int id)
        {
            var category=await GetCategoryOrThrowExceptionAsync(id);
            await _categoryRepository.DeleteAsync(category);
        }
        private async Task<Category> GetCategoryOrThrowExceptionAsync(int id)
        {
            var category = await _categoryRepository.GetByIdAsync(id);
            if (category == null)
                throw new NotFoundException($"Category with ID {id} not found");
            return category;
        }
    }
}
