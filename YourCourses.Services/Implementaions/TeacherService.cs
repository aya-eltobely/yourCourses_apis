using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourCourses.Data.Helpers;
using YourCourses.Data.Models;
using YourCourses.Infrastructure.Context;
using YourCourses.Infrastructure.Interfaces;
using YourCourses.Infrastructure.Repositories;
using YourCourses.Services.DTOs;
using YourCourses.Services.Interfaces;

namespace YourCourses.Services.Implementaions
{
    public class TeacherService : ITeacherService
    {
        private readonly UserManager<ApplicationUser> userManager;
        public readonly IUnitOfWork unitOfWork;
        public readonly IUserRepository userRepository;
        public readonly ITeacherRepository teacherRepository;
        private readonly IReviewRepository reviewRepository;
        private readonly ICourseRepository courseRepository;

        public TeacherService(UserManager<ApplicationUser> _userManager
            , IUnitOfWork _unitOfWork,
            IUserRepository _userRepository,
            ITeacherRepository _teacherRepository,
            IReviewRepository _reviewRepository,
            ICourseRepository _courseRepository
            )
        {
            userManager = _userManager;
            unitOfWork = _unitOfWork;
            userRepository = _userRepository;
            teacherRepository = _teacherRepository;
            reviewRepository = _reviewRepository;
            courseRepository = _courseRepository;
        }


        public List<GetUsersDTO> GetAllTeachers()
        {
            var user = teacherRepository.AllTeachersUser();
            try
            {
                List<GetUsersDTO> teachersDTO = new List<GetUsersDTO>();

                foreach (var _user in user)
                {
                    Teacher te = teacherRepository.GetTeacherByUserId(_user.Id);

                    teachersDTO.Add(
                        new GetUsersDTO()
                        {
                            Id = te.Id,
                            FirstName = _user.firstName,
                            LastName = _user.lastName,
                            IsActivate = _user.isActivate,
                            UserName = _user.UserName,
                            Email = _user.Email,
                            PhoneNumber = _user.PhoneNumber,
                        });
                }

                return teachersDTO;   
            }

            catch (Exception)
            {
                throw;
            }
        }

        public bool DeleteTeacherById(int id)
        {
            using var transaction = unitOfWork.BeginTransaction();
            try
            {
                Teacher teacher = unitOfWork.Teacher.GetById(id);
                //if (teacher != null)
                //{
                bool res = unitOfWork.Teacher.Delete(teacher);

                ApplicationUser user =  unitOfWork.AppUser.GetAll().SingleOrDefault(u => u.Id == teacher.AppUserId);
                unitOfWork.AppUser.Delete(user);
                //    return res;
                //}
                //return false;


                unitOfWork.Save();
                transaction.Commit();
                return res ;
            }
            catch (Exception)
            {
                transaction.Rollback();
                return false;
            }

            
        }

        public bool ActivateTeacherById(int id)
        {
            using var transaction = unitOfWork.BeginTransaction();
            try
            {
                Teacher teacher = teacherRepository.GetById(id);
                ApplicationUser applicationUser = userRepository.getUserByID(teacher.AppUserId);
                applicationUser.isActivate = 1;
                bool res = userRepository.Update(applicationUser);

                unitOfWork.Save();
                transaction.Commit();
                return res;
            }
            catch (Exception)
            {
                transaction.Rollback();
                return false;
            }
        }


    }
}
