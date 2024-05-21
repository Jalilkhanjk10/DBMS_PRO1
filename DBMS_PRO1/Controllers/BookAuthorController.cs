using DBMS_PRO1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DBMS_PRO1.FUNCTIONS;

namespace DBMS_PRO1.Controllers
{

    public class BookAuthorController : Controller
    {

        private static int bid;
        private static int aid;

        // GET: BookAuthor
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult AddBookAuthor()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddBookAuthor(BookAuthorModel bam)
        {
            BookAuthorClass bac = new BookAuthorClass();

            int a = bac.addbookauthor(bam);
            
            if(a > 0)
            {
                ViewBag.Message = "Book Author Added Successfully";
            }

            return View();
        }

        public ActionResult ViewBookAuthor()
        {
            BookAuthorClass bac = new BookAuthorClass();

            List<BookAuthorModel> list = bac.viewbookauthor();

            return View(list);
        }

        public ActionResult Delete(int Bookid, int Authorid)
        {
            BookAuthorClass bac = new BookAuthorClass();

            bac.deletebookauthor(Bookid, Authorid);

            return RedirectToAction("ViewBookAuthor", "BookAuthor");
        }

        [HttpGet]
        public ActionResult Edit(int Bookid, int Authorid)
         {
            BookAuthorClass bac = new BookAuthorClass();

            BookAuthorModel bam = bac.getbookauthor(Bookid, Authorid);

            bid = Bookid;
            aid = Authorid;

            return View(bam);
        }

        [HttpPost]
        public ActionResult Edit(BookAuthorModel bam)
        {
            BookAuthorClass bac = new BookAuthorClass();

            int a = bac.updatebookauthor(bam, bid, aid);

            if(a > 0)
            {
                ViewBag.Message = "Book ID & Author ID Updated Successfully";
            }

            return View();
        }
    }
}