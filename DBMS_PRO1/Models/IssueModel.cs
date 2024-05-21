using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DBMS_PRO1.Models
{
    public class IssueModel
    {
        [Display(Name ="Book Issuance ID")]
        public int BookIssuanceid { get; set; }

        [Display(Name = "Book Issuance Date")]
        public DateTime BookIssuancedate { get; set; }

        [Display(Name = "Book ID")]
        public int Bookid { get; set; }

        [Display(Name = "Member ID")]
        public int Memberid { get; set; }

        [Display(Name = "Book Due Date")]
        public DateTime Bookduedate { get; set; }

    }
}