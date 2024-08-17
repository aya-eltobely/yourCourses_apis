using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YourCourses.Services.DTOs
{
    public class GetCoursesDTO
    {
        public int Id { get; set; }
        public string name_en { get; set; }
        public string name_ar { get; set; }
        public int subcategoryId { get; set; }
        public string subcategoryName_en { get; set; }
        public string subcategoryName_ar { get; set; }
        public string description_en { get; set; }
        public string description_ar { get; set; }
    }
}
