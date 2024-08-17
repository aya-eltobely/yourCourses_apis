using Microsoft.EntityFrameworkCore.Update;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourCourses.Data.Models;
using YourCourses.Infrastructure.Interfaces;

namespace YourCourses.Services.Interfaces
{
    public interface IUserService 
    {
        ApplicationUser GetUserByEmail(string email);
    }
}
