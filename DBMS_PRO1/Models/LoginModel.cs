using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Drawing;

namespace DBMS_PRO1.Models
{
    public class LoginModel
    {
        public int User_ID { get; set; }

        [Required(ErrorMessage = "This Field is mandatory")]
        [Display(Name = "User Name")]
        public string User_Name { get; set; }

        [Required(ErrorMessage = "This Field is mandatory")]
        [Display(Name = "Password")]
        public string User_Password { get; set; }

        [Display(Name = "Confirm Password")]
        [Required(ErrorMessage = "This Field is mandatory")]
        [Compare("User_Password", ErrorMessage = "Confirm Password Doesn't Match, Type Again")]
        public string Confirm_Password { get; set; }

        [Display(Name = "User Type")]
        public string UserType {  get; set; }
    }
}