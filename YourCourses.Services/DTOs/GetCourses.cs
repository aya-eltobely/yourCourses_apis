using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YourCourses.Services.DTOs
{
    public class GetCourses
    {
        public int Id { get; set; }
        public string Name_en { get; set; }
        public string Name_ar { get; set; }
        public string Description_ar { get; set; }
        public string Description_en { get; set; }

    }
}
