using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YourCourses.Data.Models
{
    public class Video
    {
        public int Id { get; set; }
        public string Name_en { get; set; }
        public string Name_ar { get; set; }
        public string Description_en { get; set; }
        public string Description_ar { get; set; }
        public DateTime CreationDate { get; set; }
        public double Rate { get; set; }


        public int CourseId { get; set; }
        [ForeignKey("CourseId")]
        public virtual Course Course { get; set; }


        public virtual List<Comment> Comments { get; set; }

    }
}
