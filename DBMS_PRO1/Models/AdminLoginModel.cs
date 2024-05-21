using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DBMS_PRO1.Models
{
    public class AdminLoginModel
    {
        public int AdminID { get; set; }

        [Required(ErrorMessage = "This Field is mandatory")]
        [Display(Name = "Admin Name")]
        public string Admin_Name { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "This Field is mandatory")]
        public string Password { get; set; }
    }
}