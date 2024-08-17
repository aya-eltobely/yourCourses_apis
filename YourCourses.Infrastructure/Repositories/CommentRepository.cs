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
    public class CommentRepository : BaseRepository<Comment>, ICommentRepository
    {
        public CommentRepository(ApplicationDBContext context) : base(context)
        {
        }
    }
}
