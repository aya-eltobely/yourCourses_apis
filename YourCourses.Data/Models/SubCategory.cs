using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YourCourses.Data.Models
{
    public class SubCategory
    {
        public int Id { get; set; }
        public string Name_en { get; set; }
        public string Name_ar { get; set; }

        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }


        public virtual List<Course> Courses { get; set; }


    }
}
