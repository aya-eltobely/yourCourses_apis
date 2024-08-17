using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using YourCourses.Data.Models;
using Microsoft.EntityFrameworkCore.Storage;

namespace YourCourses.Infrastructure.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository AppUser { get; }
        ICategoryRepository Category { get; }
        ICommentRepository Comment { get; }
        ICourseRepository Course { get; }
        IReviewRepository Review { get; }
        IStudentRepository Student { get; }
        ISubCategoryRepository SubCategory { get; }
        ITeacherRepository Teacher { get; }
        IVideoRepository Video { get; }

        void Save();

        IDbContextTransaction BeginTransaction();
    }
}
