﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YourCourses.Services.DTOs
{
    public class GetREviewsDTO
    {
        public int Id { get; set; }
        public string StudentName { get; set; }
        public string Content { get; set; }
        public string CourseName { get; set; }
    }
}
