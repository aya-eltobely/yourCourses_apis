using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourCourses.Data.Models;
using YourCourses.Infrastructure.Context;
using YourCourses.Infrastructure.Interfaces;
using YourCourses.Infrastructure.Repositories;
using YourCourses.Services.Interfaces;

namespace YourCourses.Services.Implementaions
{
    public class UserService :IUserService
    {
        private readonly IUnitOfWork unitOfWork;

        public UserService( IUnitOfWork _unitOfWork) 
        {
            unitOfWork = _unitOfWork;
        }

        public ApplicationUser GetUserByEmail(string email)
        {
            var user = unitOfWork.AppUser.GetAll().FirstOrDefault(u => u.Email == email);
            return user;
        }
    }
}
