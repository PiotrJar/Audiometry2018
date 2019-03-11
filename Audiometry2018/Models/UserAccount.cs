using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Audiometry2018.Models
{
    public class UserAccount
    {
        [Key]
        [Required(ErrorMessage = "User Name is Required.")]
        public string UserName { get; set; }

        [EmailAddress(ErrorMessage = "Please enter a vaild email.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is Required.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Please confirm your password")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }


    }
}