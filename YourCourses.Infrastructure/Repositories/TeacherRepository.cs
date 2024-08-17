using Microsoft.AspNetCore.Identity;
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
    public class TeacherRepository : BaseRepository<Teacher>, ITeacherRepository
    {
        private readonly UserManager<ApplicationUser> userManager;

        public TeacherRepository(ApplicationDBContext context, UserManager<ApplicationUser> _userManager) : base(context)
        {
            userManager = _userManager;
        }


        public List<ApplicationUser> AllTeachersUser()
        {
            var data = userManager.GetUsersInRoleAsync(WebSiteRoles.SiteTeacher).GetAwaiter().GetResult().ToList();
            return data;
        }
      

        public Teacher GetTeacherByUserId(string userId)
        {
            Teacher te = Context.Teachers.Where(t => t.AppUserId == userId).FirstOrDefault();
            return te;
        }

    }
}
