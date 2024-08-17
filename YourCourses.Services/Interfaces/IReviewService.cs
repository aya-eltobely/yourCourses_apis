using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourCourses.Services.DTOs;

namespace YourCourses.Services.Interfaces
{
    public interface IReviewService
    {
        List<GetREviewsDTO> GetReviews(int courseId);
    }
}
