using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace DBMS_PRO1.Models
{
    public class ViewBookToUserModel
    {
        [Display(Name ="Book ID")]
        public int Bookid { get; set; }

        [Display(Name = "Book Title")]
        public string BookTitle { get; set; }

        [Display(Name = "Publication Date")]
        public DateTime PublicationDate { get; set; }

        

        [Display(Name = "Author ID")]
        public int Authorid { get; set; }

        [Display(Name = "Author Name")]
        public string AuthorName { get; set; }
    }
}