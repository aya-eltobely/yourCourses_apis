using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YourCourses.Data.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string Content { get; set; }


        public int VideoId { get; set; }
        [ForeignKey("VideoId")]
        public virtual Video Video { get; set; }
    }
}
