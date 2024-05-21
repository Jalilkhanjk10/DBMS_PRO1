using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace DBMS_PRO1.Models
{
    public class BookAuthorModel
    {
        [Display(Name ="Book ID")]
        public int BookID { get; set; }

        [Display(Name = "Author ID")]
        public int AuthorID { get; set; }
    }
}