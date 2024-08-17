using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourCourses.Data.Models;

namespace YourCourses.Infrastructure.Interfaces
{
    public interface ICommentRepository:IBaseRepository<Comment>
    {
    }
}
