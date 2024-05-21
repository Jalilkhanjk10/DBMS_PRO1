using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DBMS_PRO1.Models
{
    public class DetailBookModel
    {
        public int Issuanceid { get; set; }


        public string Copyid { get; set; }


        public DateTime bookreturndate { get; set; }


        public int Finepolicyid { get; set; }
    }
}