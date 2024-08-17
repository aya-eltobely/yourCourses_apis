using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using YourCourses.Services.DTOs;
using YourCourses.Services.Interfaces;

namespace YourCourses.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly ICourseService courseService;

        public TeacherController(ICourseService _courseService)
        {
            courseService = _courseService;
        }

        #region Course

        [HttpGet("course")]
        public IActionResult getAllCourses()
        {
            List<GetCoursesDTO> getCoursesDTOs = courseService.GetCourses().ToList();
            return Ok(getCoursesDTOs);
        }

        [HttpPost("course")]
        public IActionResult addCourses(CourseDTO courseDTO)
        {
            bool res = courseService.addCourse(courseDTO);
            if (res)
            {
                return Ok(res);
            }
            return BadRequest("SomeThing Wrong");
        }

        #endregion


    }
}
