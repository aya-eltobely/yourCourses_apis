using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourCourses.Data.Models;
using YourCourses.Services.DTOs;

namespace YourCourses.Services.Interfaces
{
    public interface ISubCategoryService
    {
        List<GetSubCategoryDTO> GetSubCategories();
        bool AddSubCategory(SubCategoryDTO subCategoryDTO); 
        bool EditSubCategory(int id , SubCategoryDTO subCategoryDTO); 
        bool DeleteSubCategory(int id);

    }
}
