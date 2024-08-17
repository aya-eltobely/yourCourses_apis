using Microsoft.AspNetCore.DataProtection.KeyManagement.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using YourCourses.Data.Models;
using YourCourses.Infrastructure.Context;
using YourCourses.Infrastructure.Interfaces;
using YourCourses.Infrastructure.Repositories;
using YourCourses.Services.DTOs;
using YourCourses.Services.Interfaces;

namespace YourCourses.Services.Implementaions
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork unitOfWork;

        public CategoryService( IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
        }

        public bool AddCategory(CategoryDTO categoryDTO)
        {
            using var transaction = unitOfWork.BeginTransaction();
            try
            {
                Category category = new Category() { Name_en = categoryDTO.Name_en, Name_ar = categoryDTO.Name_ar };
                unitOfWork.Category.Create(category);

                unitOfWork.Save();
                transaction.Commit();
                return true;
            }
            catch (Exception)
            {
                transaction.Rollback();
                return false;
            }
        }

        public bool DeleteCategory(int id)
        {
            using var transaction = unitOfWork.BeginTransaction();
            try
            {
                Category category = unitOfWork.Category.GetById(id);
                unitOfWork.Category.Delete(category);

                unitOfWork.Save();
                transaction.Commit();
                return true;
            }
            catch (Exception)
            {
                transaction.Rollback();
                return false;
            }
        }

        public bool EditCategory(int id, CategoryDTO categoryDTO)
        {
            using var transaction = unitOfWork.BeginTransaction();
            try
            {
                Category category = unitOfWork.Category.GetById(id);
                category.Name_en = categoryDTO.Name_en;
                category.Name_ar = categoryDTO.Name_ar;

                unitOfWork.Category.Update(category);

                unitOfWork.Save();
                transaction.Commit();
                return true;
            }
            catch (Exception)
            {
                transaction.Rollback();
                return false;
            }
        }

        public List<GetCategoryDTO> GetAllCategory()
        {
            List<Category> categories = unitOfWork.Category.GetAll().ToList();

            List<GetCategoryDTO> categoriesDTOs = new List<GetCategoryDTO>();

            foreach (var category in categories)
            {
                categoriesDTOs.Add(new GetCategoryDTO() {Id = category.Id, Name_ar = category.Name_ar, Name_en = category.Name_en });
            }
            return categoriesDTOs;
        }
    }
}
