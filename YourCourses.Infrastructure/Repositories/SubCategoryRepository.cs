﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourCourses.Data.Models;
using YourCourses.Infrastructure.Context;
using YourCourses.Infrastructure.Interfaces;

namespace YourCourses.Infrastructure.Repositories
{
    public class SubCategoryRepository : BaseRepository<SubCategory>, ISubCategoryRepository
    {
        public SubCategoryRepository(ApplicationDBContext context) : base(context)
        {
        }
    }
}
