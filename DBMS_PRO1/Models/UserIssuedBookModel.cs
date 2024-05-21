using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace DBMS_PRO1.Models
{
    public class UserIssuedBookModel
    {
        [Display(Name ="User Name")]
        public string Username { get; set; }

        [Display(Name ="Book Title")]
        public string Booktitle { get; set; }

        [Display(Name = "Book Issuance Date")]
        public DateTime Bookissuancedate { get; set; }

        [Display(Name = "Book Due Date")]
        public DateTime Bookduedate { get; set; }
    }
}