using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourCourses.Services.DTOs;

namespace YourCourses.Services.Interfaces
{
    public interface ICourseService
    {
        List<GetCoursesDTO> GetCourses();
        bool addCourse(CourseDTO courseDto);

        List<GetCourses> GetCoursesByTeacherId(int id);

    }
}
