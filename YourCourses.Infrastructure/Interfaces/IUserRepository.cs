using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using YourCourses.Data.Models;

namespace YourCourses.Infrastructure.Interfaces
{
    public interface IUserRepository:IBaseRepository<ApplicationUser>
    {
        string getLoggedUser();
        int getLoggedTeacherId();
        int getLoggedStudentId();

        ApplicationUser getUserByID(string id);

    }
}
