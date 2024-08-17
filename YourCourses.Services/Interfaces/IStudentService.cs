using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourCourses.Data.Helpers;
using YourCourses.Data.Models;
using YourCourses.Infrastructure.Interfaces;
using YourCourses.Services.DTOs;

namespace YourCourses.Services.Interfaces
{
    public interface IStudentService
    {
        //PageResult<GetUsersDTO> GetAllStudent(int pagenumber, int pagesize, string search);
        List<GetUsersDTO> GetAllStudent();
        List<GetUsersDTO> GetAllInactiveStudents();
        

        bool DeleteStudentById(int id);
        bool DeactiveStudentById(int id);

    }
}
