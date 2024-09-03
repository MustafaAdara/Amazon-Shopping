using Amazon.Models;
using AutoMapper;
using BusinessLogicLayer.DTOs;
using BusinessLogicLayer.IServices;
using DataAccessLayer.IterfacesRepositories;
using DataAccessLayer.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CategoryService(IUnitOfWork unitOfWork, IMapper mapper) 
        {

            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public void CreateCategory(CategoryDto categoryDto)
        {
            var category = _mapper.Map<Category>(categoryDto);
            _unitOfWork.CategoryRepository.Add(category);
            _unitOfWork.CompleteAsync();
        }

        public async Task<ICollection<CategoryDto>> GetAll()
        {
            var categories = await _unitOfWork.CategoryRepository.GetAll();

            return  _mapper.Map<ICollection<CategoryDto>>(categories);
        }

        public async Task<CategoryDto> GetCategory(string id)
        {
            var category = await _unitOfWork.CategoryRepository.GetById(id);
            return _mapper.Map<CategoryDto>(category);
        }
    }
}
