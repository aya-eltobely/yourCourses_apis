using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourCourses.Data.Models;
using YourCourses.Infrastructure.Interfaces;
using YourCourses.Infrastructure.Repositories;
using YourCourses.Services.DTOs;
using YourCourses.Services.Interfaces;

namespace YourCourses.Services.Implementaions
{
    public class SubCategoryService : ISubCategoryService
    {
        private readonly ISubCategoryRepository subCategoryRepository;
        private readonly IUnitOfWork unitOfWork;

        public SubCategoryService(ISubCategoryRepository _subCategoryRepository, IUnitOfWork _unitOfWork)
        {
            subCategoryRepository = _subCategoryRepository;
            unitOfWork = _unitOfWork;

        }
        public bool AddSubCategory(SubCategoryDTO subCategoryDTO)
        {
            using var transaction = unitOfWork.BeginTransaction();
            try
            {
                SubCategory subCategory = new SubCategory() { Name_en = subCategoryDTO.Name_en, Name_ar = subCategoryDTO.Name_ar, CategoryId = subCategoryDTO.CategoryId };
                subCategoryRepository.Create(subCategory);

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

        public bool DeleteSubCategory(int id)
        {
            using var transaction = unitOfWork.BeginTransaction();
            try
            {
                SubCategory subcategory = unitOfWork.SubCategory.GetById(id);
                subCategoryRepository.Delete(subcategory);

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

        public bool EditSubCategory(int id, SubCategoryDTO subCategoryDTO)
        {
            using var transaction = unitOfWork.BeginTransaction();
            try
            {
                SubCategory subcategory = subCategoryRepository.GetById(id);
                subcategory.Name_en = subCategoryDTO.Name_en;
                subcategory.Name_ar = subCategoryDTO.Name_ar;
                subcategory.CategoryId = subCategoryDTO.CategoryId;

                subCategoryRepository.Update(subcategory);

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

        public List<GetSubCategoryDTO> GetSubCategories()
        {
            List<SubCategory> subCategories = subCategoryRepository.GetAll().ToList();

            List<GetSubCategoryDTO> subCategoryDTOs = new List<GetSubCategoryDTO>();

            foreach (var subcategory in subCategories)
            {
                subCategoryDTOs.Add(new GetSubCategoryDTO() { Id = subcategory.Id, Name_ar = subcategory.Name_ar, Name_en = subcategory.Name_en  , CategoryId = subcategory.CategoryId, CategoryName_en = subcategory.Category.Name_en, CategoryName_ar = subcategory.Category.Name_ar });
            }
            return subCategoryDTOs;
        }
    }
}
