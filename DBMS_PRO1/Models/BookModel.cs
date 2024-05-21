using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace DBMS_PRO1.Models
{
    public class BookModel
    {
        [Display(Name ="Book ID")]
        public int BookID { get; set; }

        [Display(Name ="Book Titile")]
        public string BookTitle { get; set; }

        [Display(Name = "Publish Date")]
        public DateTime publishedDate{ get; set; }
        
    }
}