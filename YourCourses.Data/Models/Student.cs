﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YourCourses.Data.Models
{
    public class Student
    {
        public int Id { get; set; }



        //////////////////////////////
        public string AppUserId { get; set; }
        [ForeignKey("AppUserId")]
        public virtual ApplicationUser AppUser { get; set; }


        public virtual List<Review> Reviews { get; set; }

    }
}
