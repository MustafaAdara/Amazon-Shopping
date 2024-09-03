using Amazon.Models;
using AutoMapper;
using BusinessLogicLayer.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Helper
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<Category, CategoryDto>();
            CreateMap<CategoryDto, Category>();

            //CreateMap<Category, CategoryDto>();
        }
    }
}
