using AutoMapper;
using Domain.CategoryDTOs;
using Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.MappingProfile
{
    public class CategoryMappingProfile:Profile
    {
        public CategoryMappingProfile()
        {
            
            CreateMap<Category, CategoryDTO>().ReverseMap();
            CreateMap<CreateCategoryDTO, Category>();
            CreateMap<UpdateCategoryDTO, Category>();
        }
    }
}
