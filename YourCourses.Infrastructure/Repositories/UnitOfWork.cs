using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using YourCourses.Data.Models;
using YourCourses.Infrastructure.Context;
using YourCourses.Infrastructure.Interfaces;
using static System.Net.Mime.MediaTypeNames;

namespace YourCourses.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDBContext Context;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IHttpContextAccessor httpContextAccessor;


        public IUserRepository AppUser { get; set; }
         public ICategoryRepository Category { get; set; }
        public ICommentRepository Comment { get; set; }

        public ICourseRepository Course { get; set; }

        public IReviewRepository Review { get; set; }

        public IStudentRepository Student { get; set; }

        public ISubCategoryRepository SubCategory { get; set; }

        public ITeacherRepository Teacher { get; set; }

        public IVideoRepository Video { get; set; }

        public UnitOfWork(ApplicationDBContext context, UserManager<ApplicationUser> _userManager, IHttpContextAccessor _httpContextAccessor)
        {
            Context = context;
            userManager = _userManager;
            httpContextAccessor = _httpContextAccessor;
            AppUser = new UserRepository(Context, httpContextAccessor);
            Category = new CategoryRepository(Context);
            Comment = new CommentRepository(Context);
            Course = new CourseRepository(Context, AppUser);
            Review = new ReviewRepository(Context);
            Student = new StudentRepository(Context,userManager);
            SubCategory = new SubCategoryRepository(Context);
            Teacher = new TeacherRepository(Context, userManager);
            Video = new VideoRepository(Context);
        }

        void IDisposable.Dispose()
        {
            Context.Dispose();
        }

        void IUnitOfWork.Save()
        {
            Context.SaveChanges();
        }

        public IDbContextTransaction BeginTransaction()
        {
            return Context.Database.BeginTransaction();
        }
    }
}
