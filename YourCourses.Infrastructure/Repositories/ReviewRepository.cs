using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourCourses.Data.Models;
using YourCourses.Infrastructure.Context;
using YourCourses.Infrastructure.Interfaces;

namespace YourCourses.Infrastructure.Repositories
{
    public class ReviewRepository : BaseRepository<Review>, IReviewRepository
    {
        public ReviewRepository(ApplicationDBContext context) : base(context)
        {
        }

        public Review GetReviewByCourseId(int courseId)
        {
            var review = Context.Reviews.FirstOrDefault(r => r.CourseId == courseId);
            return review;
        }

        public List<Review> GetReviewsByCourseId(int courseId)
        {
            var reviews = Context.Reviews.Where(r => r.CourseId == courseId).ToList();
            return reviews;
        }
    }
}
