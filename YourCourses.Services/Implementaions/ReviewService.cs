using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourCourses.Data.Models;
using YourCourses.Infrastructure.Interfaces;
using YourCourses.Infrastructure.Repositories;
using YourCourses.Services.DTOs;
using YourCourses.Services.Interfaces;

namespace YourCourses.Services.Implementaions
{
    public class ReviewService : IReviewService
    {
        private readonly IReviewRepository reviewRepository;

        public ReviewService(IReviewRepository _reviewRepository)
        {
            reviewRepository = _reviewRepository;
        }

        public List<GetREviewsDTO> GetReviews(int courseId)
        {
            List<Review> reviews =  reviewRepository.GetReviewsByCourseId(courseId);

            List<GetREviewsDTO> getREviewsDTOs = new List<GetREviewsDTO>();

            foreach (Review review in reviews)
            {
                getREviewsDTOs.Add(new GetREviewsDTO()
                {
                    Id = review.Id,
                    Content = review.Content,
                    CourseName = review.Course.Name_en,
                    StudentName = review.Student.AppUser.firstName + ' ' + review.Student.AppUser.lastName,
                });
            }

            return getREviewsDTOs;

        }
    }
}
