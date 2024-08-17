﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YourCourses.Data.Helpers
{
    public class PageResult<T> where T : class
    {
        public PageResult() { }
        public List<T> Data { get; set; }
        public int TotalItem { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
