using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YourCourses.Data.Models;
using YourCourses.Infrastructure.Interfaces;
using YourCourses.Infrastructure.Repositories;
using YourCourses.Services.DTOs;
using YourCourses.Services.Implementaions;
using YourCourses.Services.Interfaces;

namespace YourCourses.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IStudentService studentService;
        public readonly ITeacherService teacherService;
        public readonly ICategoryService categoryService;
        private readonly ISubCategoryService subCategoryService;
        private readonly ICourseService courseService;
        private readonly IReviewService reviewService;

        public AdminController(IStudentService _studentService,
            ITeacherService _teacherService,
            ICategoryService _categoryService,
            ISubCategoryService _subCategoryService,
            ICourseService _courseService,
            IReviewService _reviewService
)
        {
            studentService = _studentService;
            teacherService = _teacherService;
            categoryService = _categoryService;
            subCategoryService = _subCategoryService;
            courseService = _courseService;
            reviewService = _reviewService;

        }

        #region Student

        //[HttpGet("student")]
        //public IActionResult GetAllStudents(int pagenumber, int pagesize, string? search = null)
        //{
        //    var allStudents = studentService.GetAllStudent(pagenumber, pagesize, search);
        //    return Ok(allStudents);
        //}

        [HttpGet("student")]
        public IActionResult GetAllStudents()
        {
            var allStudents = studentService.GetAllStudent();
            return Ok(allStudents);
        }

        [HttpGet("student/Inactive")]
        public IActionResult GetAllInactiveStudents()
        {
            var allStudents = studentService.GetAllInactiveStudents();
            return Ok(allStudents);
        }


        [HttpDelete("student/{id}")]
        public IActionResult DeleteStudent(int id)
        {
            bool res = studentService.DeleteStudentById(id);
            if (res)
            {
                return Ok(res);
            }
            return BadRequest(res);
        }


        [HttpPut("student/{id}")]
        public IActionResult DeactiveStudent(int id)
        {
            bool res = studentService.DeactiveStudentById(id);
            if (res)
            {
                return Ok(res);
            }
            return BadRequest(res);
        }

        #endregion

        #region Teacher

        [HttpGet("teacher")]
        public IActionResult GetAllTeachers()
        {
            var allTeachers = teacherService.GetAllTeachers();
            return Ok(allTeachers);
        }
        

        [HttpDelete("teacher/{id}")]
        public IActionResult DeleteTeacher(int id)
        {
            bool res = teacherService.DeleteTeacherById(id);
            if (res)
            {
                return Ok(res);
            }
            return BadRequest(res);
        }


        [HttpPut("teacher/activate/{id}")]
        public IActionResult ActivateTeacher(int id)
        {
            bool res = teacherService.ActivateTeacherById(id);
            if (res)
            {
                return Ok(res);
            }
            return BadRequest(res);
        }


        [HttpGet("teacher/courses/{teacherId}")]
        public IActionResult Getcourses(int teacherId)
        {
            var courses = courseService.GetCoursesByTeacherId(teacherId);
            return Ok(courses);
        }

        [HttpGet("teacher/review/{courseId}")]
        public IActionResult GetReviews(int courseId)
        {
            var reviews = reviewService.GetReviews(courseId);
            return Ok(reviews);
        }



        #endregion

        #region Category

        [HttpPost("category")]
        public IActionResult AddCategory(CategoryDTO categoryDTO)
        {
            bool res = categoryService.AddCategory(categoryDTO);
            if(res)
            {
                return Ok(res);
            }
            return BadRequest(res);
        }


        [HttpPut("category/{id}")]
        public IActionResult EditCategory(int id , CategoryDTO categoryDTO)
        {
            bool res = categoryService.EditCategory(id , categoryDTO);
            if (res)
            {
                return Ok(res);
            }
            return BadRequest(res);
        }

        [HttpDelete("category/{id}")]
        public IActionResult DeleteCategory(int id)
        {
            bool res = categoryService.DeleteCategory(id);
            if (res)
            {
                return Ok(res);
            }
            return BadRequest(res);
        }


        [HttpGet("category")]
        public IActionResult GetCategories()
        {
            List<GetCategoryDTO> categories = categoryService.GetAllCategory();
            return Ok(categories);
        }
        #endregion


        #region Sub Category

        [HttpPost("subCategory")]
        public IActionResult AddSubCategory(SubCategoryDTO subCategoryDTO)
        {
            bool res = subCategoryService.AddSubCategory(subCategoryDTO);
            if (res)
            {
                return Ok(res);
            }
            return BadRequest(res);
        }


        [HttpPut("subCategory/{id}")]
        public IActionResult EditSubCategory(int id, SubCategoryDTO subCategoryDTO)
        {
            bool res = subCategoryService.EditSubCategory(id, subCategoryDTO);
            if (res)
            {
                return Ok(res);
            }
            return BadRequest(res);
        }

        [HttpDelete("subCategory/{id}")]
        public IActionResult DeleteSubCategory(int id)
        {
            bool res = subCategoryService.DeleteSubCategory(id);
            if (res)
            {
                return Ok(res);
            }
            return BadRequest(res);
        }


        [HttpGet("subCategory")]
        public IActionResult GetSubCategories()
        {
            List<GetSubCategoryDTO> subcategories = subCategoryService.GetSubCategories();
            return Ok(subcategories);
        }
        #endregion

    }
}
