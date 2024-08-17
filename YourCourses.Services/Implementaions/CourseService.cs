using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using YourCourses.Data.Models;
using YourCourses.Infrastructure.Interfaces;
using YourCourses.Infrastructure.Repositories;
using YourCourses.Services.DTOs;
using YourCourses.Services.Interfaces;

namespace YourCourses.Services.Implementaions
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository courseRepository;

        public IUnitOfWork unitOfWork { get; }

        private readonly IUserRepository userRepository;

        public CourseService(ICourseRepository _courseRepository,IUnitOfWork _unitOfWork,IUserRepository _userRepository)
        {
            courseRepository = _courseRepository;
            unitOfWork = _unitOfWork;
            userRepository = _userRepository;
        }



        public List<GetCoursesDTO> GetCourses()
        {
            List<Course> courses = courseRepository.GetAllCourseByTeacherId();
            List<GetCoursesDTO> getCoursesDTOs = new List<GetCoursesDTO>();

            foreach (var course in courses)
            {
                getCoursesDTOs.Add(
                    new GetCoursesDTO()
                    {
                        name_en = course.Name_en,
                        name_ar = course.Name_ar,
                        subcategoryId = course.SubCategoryId,
                        subcategoryName_en = course.SubCategory.Name_en,
                        subcategoryName_ar = course.SubCategory.Name_ar,
                        description_en = course.Description_en,
                        description_ar = course.Description_ar,
                    }
                );
            }
            return getCoursesDTOs;
        }

        public bool addCourse(CourseDTO courseDto)
        {
            using var transaction = unitOfWork.BeginTransaction();
            try
            {
                Course course  = new Course() { 
                    Name_en=courseDto.name_en,
                    Name_ar = courseDto.name_ar,
                    TeacherId = userRepository.getLoggedTeacherId(),
                    SubCategoryId=courseDto.subcategoryId,
                    Description_en= courseDto.description_en,
                    Description_ar= courseDto.description_ar,
                };
                courseRepository.Create(course);

                
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

        public List<GetCourses> GetCoursesByTeacherId(int id)
        {
            var courses = courseRepository.GetCoursesForTeacher(id);

            List<GetCourses> getCourseWithReviews = new List<GetCourses>();

            foreach (var course in courses)
            {
                getCourseWithReviews.Add(new GetCourses()
                {
                    Id = course.Id,
                    Name_en = course.Name_en,
                    Name_ar = course.Name_ar,
                    Description_ar = course.Description_ar,
                    Description_en = course.Description_en,
                });
            }

            return getCourseWithReviews;
        }
    }
}
