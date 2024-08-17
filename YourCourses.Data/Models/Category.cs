using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YourCourses.Data.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name_en { get; set; }
        public string Name_ar { get; set; }

        public virtual List<SubCategory> SubCategories { get; set; }
    }
}
