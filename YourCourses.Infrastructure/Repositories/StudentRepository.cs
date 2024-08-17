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

namespace YourCourses.Infrastructure.Repositories
{
    public class StudentRepository : BaseRepository<Student>, IStudentRepository
    {
        private readonly UserManager<ApplicationUser> userManager;

        public StudentRepository(ApplicationDBContext context, UserManager<ApplicationUser> _userManager) : base(context)
        {
            userManager = _userManager;
        }

        public bool Deactive(Student student)
        {
            var user = Context.Users.Find(student.AppUserId);
            user.isActivate = 0;
            Context.Update(user);
            var res = Context.SaveChanges();
            if(res>0)
            {
                return true;
            }
            return false;
        }

        public List<ApplicationUser> GetAllInactive()
        {
            DateTime sixMonthsAgo = DateTime.Now.AddMonths(-6);
            var data = userManager.GetUsersInRoleAsync(WebSiteRoles.SiteStudent).GetAwaiter().GetResult().Where(s => s.LastLoginTime < sixMonthsAgo).ToList();
            return data;
        }

        public List<ApplicationUser> GetAllUserStudent()
        {
            var data = userManager.GetUsersInRoleAsync(WebSiteRoles.SiteStudent).GetAwaiter().GetResult().ToList();
            return data;
        }
    }
}
