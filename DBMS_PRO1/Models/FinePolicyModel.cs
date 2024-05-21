using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace DBMS_PRO1.Models
{
    public class FinePolicyModel
    {

        public int Policyid { get; set; }

        [Display(Name ="Fine Max Days")]
        public int Finemaxdays { get; set; }

        [Display(Name = "Fine Amount")]
        public int Fineamount { get; set; }

        [Display(Name = "Member ID")]
        public int Memberid { get; set; }
    }
}