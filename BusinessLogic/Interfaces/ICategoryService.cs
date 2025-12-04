using Domain.CategoryDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
    public interface ICategoryService
    {
        Task<int> Create(CreateCategoryDTO createCategoryDTO);
        Task<CategoryDTO> GetById(int id);
        Task<List<CategoryDTO>> GetAllPaged(int pageNumber,int pageSize);
        Task Update(int id, UpdateCategoryDTO updateCategoryDTO);
        Task Delete(int id);
    }
}
    