﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YourCourses.Services.DTOs
{
    public class RegisterUserDTO
    {
        //[Required]
        [RegularExpression("^[A-Za-z]+$", ErrorMessage = "Please enter a valid first name with only one word alphabetic characters.")]
        public string FirstName { get; set; }

        //[Required]
        [RegularExpression("^[A-Za-z]+$", ErrorMessage = "Please enter a valid last name with only one word alphabetic characters.")]
        public string LastName { get; set; }

        //[Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        //[Required]
        public string UserName { get; set; }

        //[Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        //[Required]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }

        public string PhoneNumber { get; set; }
        public string UserType { get; set; } // Teacher , Student
    }
}
