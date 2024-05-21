using DBMS_PRO1.FUNCTIONS;
using DBMS_PRO1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DBMS_PRO1.Controllers
{
    public class BookCopyController : Controller
    {
        // GET: BookCopy
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult AddCopyBookid()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCopyBookid(BookCopyModel bcm)
        {
            BookCopyClass obj = new BookCopyClass();

            int a = obj.insertcopybookid(bcm);

            if(a > 0)
            {
                ViewBag.Message = "Book ID Added Successfully";
            }

            return View();
        }

        public ActionResult ViewCopyBookid()
        {
            BookCopyClass obj = new BookCopyClass();

            List<BookCopyModel> lst = obj.ViewCopyBookid();
 
            return View(lst);
        }

        public ActionResult DeleteCopyBookid(int id)
        {
            BookCopyClass obj = new BookCopyClass();

            int a = obj.deletecopybookid(id);

            if(a > 0)
            {
                ViewBag.Message = "Deleted Successfuly";
            }

            return View();
        }
    }
}