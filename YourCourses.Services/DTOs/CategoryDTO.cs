using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YourCourses.Services.DTOs
{
    public class CategoryDTO
    {
        [Required]
        public string Name_en { get; set; }

        [Required]
        public string Name_ar { get; set; }
    }
}
