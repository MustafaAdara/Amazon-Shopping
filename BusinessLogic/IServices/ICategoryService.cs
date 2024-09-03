using Amazon.Models;
using BusinessLogicLayer.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.IServices
{
    public interface ICategoryService
    {
        public void CreateCategory(CategoryDto category);
        public Task<ICollection<CategoryDto>> GetAll();
        public Task<CategoryDto> GetCategory(string id);
    }
}
