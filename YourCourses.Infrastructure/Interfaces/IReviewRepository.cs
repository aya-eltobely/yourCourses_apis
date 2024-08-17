using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourCourses.Data.Models;

namespace YourCourses.Infrastructure.Interfaces
{
    public interface IReviewRepository:IBaseRepository<Review>
    {
        Review GetReviewByCourseId(int courseId);

        List<Review> GetReviewsByCourseId(int courseId);
    }
}
