using AutoMapper;
using Domain.ProductDTOs;
using Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.MappingProfile
{
    public class ProductMappingProfile:Profile
    {
        public ProductMappingProfile()
        {
            CreateMap<Product, ProductDTO>()
                .ForMember(dest => dest.Categories,
                           opt => opt.MapFrom(src => src.Categories)); 

            CreateMap<CreateProductDTO, Product>()
                .ForMember(dest => dest.Categories, opt => opt.Ignore()); 

            CreateMap<UpdateProductDTO, Product>()
                .ForMember(dest => dest.Categories, opt => opt.Ignore()); 
        }
    }
}
