using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YourCourses.Data.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string firstName  { get; set; }
        public string lastName { get; set; }
        public int isActivate  { get; set; }

        public DateTime? LastLoginTime { get; set; }

        //////////////////////////////
        public virtual Student Student { get; set; }
        public virtual Teacher Teacher { get; set; }


    }
}
