using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourCourses.Data.Helpers;
using YourCourses.Data.Models;
using YourCourses.Infrastructure.Context;

namespace YourCourses.Infrastructure.Seeder
{
    public static class SeedData
    {

        public static void Seed(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            var dbContext = serviceProvider.GetRequiredService<ApplicationDBContext>();


            //create Roles
            if (!roleManager.RoleExistsAsync(WebSiteRoles.SiteAdmin).GetAwaiter().GetResult())
            {
                roleManager.CreateAsync(new IdentityRole(WebSiteRoles.SiteAdmin)).GetAwaiter().GetResult();
                roleManager.CreateAsync(new IdentityRole(WebSiteRoles.SiteTeacher)).GetAwaiter().GetResult();
                roleManager.CreateAsync(new IdentityRole(WebSiteRoles.SiteStudent)).GetAwaiter().GetResult();
            }

            //aya

            //Create Admin
            userManager.CreateAsync(new ApplicationUser
            {
                UserName = "Aya",
                Email = "admin@gmail.com",
                firstName = "Admin",
                lastName = ""
            }, "Admin123#").GetAwaiter().GetResult();

            //check admin exist
            var AppAdmin = userManager.FindByEmailAsync("admin@gmail.com").GetAwaiter().GetResult();

            //asign role to admin
            if (AppAdmin != null)
            {
                userManager.AddToRoleAsync(AppAdmin, WebSiteRoles.SiteAdmin).GetAwaiter().GetResult();
            }

            //////////////    

            dbContext.SaveChanges();

        }

    }
}
