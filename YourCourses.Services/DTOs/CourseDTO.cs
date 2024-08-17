using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YourCourses.Services.DTOs
{
    public class CourseDTO
    {
        public string name_en { get; set; }
        public string name_ar { get; set; }
        public int subcategoryId { get; set; }
        public string description_en { get; set; }
        public string description_ar { get; set; }
    }
}
