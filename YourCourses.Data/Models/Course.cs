using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YourCourses.Data.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Name_en { get; set; }
        public string Name_ar { get; set; }
        public string Description_en { get; set; }
        public string Description_ar { get; set; }


        ///////////////////////////
        public int TeacherId { get; set; }
        [ForeignKey("TeacherId")]
        public virtual Teacher Teacher { get; set; }


        public virtual List<Review> Reviews { get; set; }


        public int SubCategoryId { get; set; }
        [ForeignKey("SubCategoryId")]
        public virtual SubCategory SubCategory { get; set; }


        public virtual List<Video> Videos { get; set; }



    }
}
