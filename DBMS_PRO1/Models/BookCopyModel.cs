using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace DBMS_PRO1.Models
{
    public class BookCopyModel
    {

        [Display(Name ="Copy ID")]
        public int Copyid { get; set; }


        [Display(Name = "Book ID")]
        public int Bookid { get; set; }
    }
}