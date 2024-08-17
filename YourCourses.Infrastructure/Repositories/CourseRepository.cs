using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using YourCourses.Data.Models;
using YourCourses.Infrastructure.Context;
using YourCourses.Infrastructure.Interfaces;

namespace YourCourses.Infrastructure.Repositories
{
    public class CourseRepository : BaseRepository<Course> , ICourseRepository
    {
        private readonly IUserRepository userRepository;

        public CourseRepository(ApplicationDBContext context,IUserRepository _userRepository) : base(context)
        {
            userRepository = _userRepository;
        }

        public List<Course> GetAllCourseByTeacherId()
        {
            List<Course> courses = Context.Courses.Where(c => c.TeacherId == userRepository.getLoggedTeacherId()).ToList();
            return courses;
        }


        public List<Course> GetCoursesForTeacher(int id)
        {
            var courses = Context.Courses.Where(c => c.TeacherId == id).ToList();
            return courses;
        }
    }
}
