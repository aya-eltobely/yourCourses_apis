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
    public class StudentService : IStudentService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IStudentRepository studentRepository;

        public IUserRepository userRepository { get; }

        public StudentService( IUnitOfWork _unitOfWork,
            IStudentRepository _studentRepository, 
            IUserRepository _userRepository
            ) 
        {
            unitOfWork = _unitOfWork;
            studentRepository = _studentRepository;
            userRepository = _userRepository;
        }

        //public PageResult<GetUsersDTO> GetAllStudent(int pagenumber, int pagesize, string search)
        //{
        //    var data = userManager.GetUsersInRoleAsync(WebSiteRoles.SiteStudent).GetAwaiter().GetResult();
        //    int totalCount;
        //    try
        //    {
        //        var query = data.AsQueryable();
        //        var ExcludedData = (pagenumber * pagesize) - pagesize;
        //        query = query.Include("AppUser");
        //        if (!string.IsNullOrWhiteSpace(search))
        //        {
        //            data = data.Where(d => d.UserName.ToLower().Contains(search.ToLower())).ToList();
        //        }
        //        data = data.Skip(ExcludedData).Take(pagesize).ToList();

        //        totalCount = data.ToList().Count;


        //        List<GetUsersDTO> studentsDTO = new List<GetUsersDTO>();

        //        foreach (var student in data)
        //        {
        //            Student st = unitOfWork.Student.GetAll().SingleOrDefault(s => s.AppUserId == student.Id);

        //            studentsDTO.Add(
        //                new GetUsersDTO()
        //                {
        //                    Id = st.Id,
        //                    FirstName = student.firstName,
        //                    LastName = student.lastName,
        //                    IsActivate = student.isActivate,
        //                    UserName = student.UserName,
        //                    Email = student.Email,
        //                    PhoneNumber = student.PhoneNumber,
        //                });
        //        }

        //        return new PageResult<GetUsersDTO>()
        //        {
        //            Data = studentsDTO,
        //            PageNumber = pagenumber,
        //            PageSize = pagesize,
        //            TotalItem = totalCount
        //        };
        //    }

        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}


        public List<GetUsersDTO> GetAllStudent()
        {
            var data = studentRepository.GetAllUserStudent();
            try
            {
               
                List<GetUsersDTO> studentsDTO = new List<GetUsersDTO>();

                foreach (var student in data)
                {
                    Student st = studentRepository.GetAll().SingleOrDefault(s => s.AppUserId == student.Id);

                    studentsDTO.Add(
                        new GetUsersDTO()
                        {
                            Id = st.Id,
                            FirstName = student.firstName,
                            LastName = student.lastName,
                            IsActivate = student.isActivate,
                            UserName = student.UserName,
                            Email = student.Email,
                            PhoneNumber = student.PhoneNumber,
                        });
                }

                return studentsDTO;
            }

            catch (Exception)
            {
                throw;
            }
        }

        public List<GetUsersDTO> GetAllInactiveStudents()
        {
            var data = studentRepository.GetAllInactive();
            try
            {
                List<GetUsersDTO> studentsDTO = new List<GetUsersDTO>();

                foreach (var student in data)
                {
                    Student st = studentRepository.GetAll().SingleOrDefault(s => s.AppUserId == student.Id);

                    studentsDTO.Add(
                        new GetUsersDTO()
                        {
                            Id = st.Id,
                            FirstName = student.firstName,
                            LastName = student.lastName,
                            IsActivate = student.isActivate,
                            UserName = student.UserName,
                            Email = student.Email,
                            PhoneNumber = student.PhoneNumber,
                        });
                }

                return studentsDTO;
            }

            catch (Exception)
            {
                throw;
            }
        }


        public bool DeleteStudentById(int id)
        {
            using var transaction = unitOfWork.BeginTransaction();
            try
            {
                Student student = studentRepository.GetById(id);
                bool res = studentRepository.Delete(student);

                ApplicationUser user = userRepository.getUserByID(student.AppUserId); 
                userRepository.Delete(user);

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

        public bool DeactiveStudentById(int id)
        {
            using var transaction = unitOfWork.BeginTransaction();
            try
            {
                Student student = studentRepository.GetById(id);
                bool res = studentRepository.Deactive(student);

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
