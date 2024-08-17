﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YourCourses.Services.DTOs
{
    public class GetSubCategoryDTO
    {
        public int Id { get; set; }
        public string Name_en { get; set; }
        public string Name_ar { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName_en { get; set; }
        public string CategoryName_ar { get; set; }
    }
}
