using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourCourses.Data.Models;
using YourCourses.Infrastructure.Interfaces;
using YourCourses.Services.DTOs;

namespace YourCourses.Services.Interfaces
{
    public interface ICategoryService
    {
        bool AddCategory(CategoryDTO categoryDTO);
        bool EditCategory(int dd , CategoryDTO categoryDTO);
        bool DeleteCategory(int id);
        List<GetCategoryDTO> GetAllCategory();

    }
}
