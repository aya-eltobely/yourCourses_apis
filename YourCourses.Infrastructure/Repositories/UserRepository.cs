using Microsoft.AspNetCore.Http;
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
    public class UserRepository : BaseRepository<ApplicationUser>, IUserRepository
    {
        private readonly IHttpContextAccessor httpContextAccessor;


        public UserRepository(ApplicationDBContext context, IHttpContextAccessor _httpContextAccessor) : base(context)
        {
            httpContextAccessor = _httpContextAccessor;
        }

        public int getLoggedStudentId()
        {
            Student std = Context.Students.FirstOrDefault(s => s.AppUserId == getLoggedUser());
            return std.Id;
            
        }

        public int getLoggedTeacherId()
        {
            Teacher teacher = Context.Teachers.FirstOrDefault(t => t.AppUserId == getLoggedUser());
            return teacher.Id;
        }

        public string getLoggedUser()
        {
            var userIdClaim = httpContextAccessor.HttpContext?.User?.Claims
                .FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
            return userIdClaim.ToString();
        }

        public ApplicationUser getUserByID(string id)
        {
            ApplicationUser user = Context.Users.SingleOrDefault(u=>u.Id == id);
            return user;
        }

        
    }
}
