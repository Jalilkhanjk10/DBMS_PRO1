using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DBMS_PRO1.Models;
using DBMS_PRO1.FUNCTIONS;


namespace DBMS_PRO1.Controllers
{
    public class BookController : Controller
    {
        // GET: Book
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult AddBook()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddBook(BookModel bm)
        {
            BookClass bc = new BookClass();

            int a = bc.addbook(bm);

            if(a > 0)
            {
                ViewBag.Message = "Book Added Successfully.";
            }

            return View();
        }


        public ActionResult ViewBook()
        {
            BookClass bc = new BookClass();

            List<BookModel> lst = bc.viewbook();

            return View(lst);
        }


        public ActionResult Delete(int id)
        {
            BookClass bc = new BookClass();

            bc.deletebook(id);

            return RedirectToAction("ViewBook", "Book");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            BookClass bc = new BookClass();

            BookModel bm = bc.getbook(id);

            return View(bm);
        }
        
        [HttpPost]
        public ActionResult Edit(BookModel bm)
        {
            BookClass bc = new BookClass();

            int a = bc.updatebook(bm);

            if(a > 0)
            {
                ViewBag.Message = "Book Update Successfully";
            }

            return RedirectToAction("ViewBook", "Book");
        }

        /// <summary>
        /// 
        /// JOIN QUERY ACTIONRESULT WORK
        /// 
        /// </summary>
        /// <param name="bm"></param>
        /// <returns></returns>


        //public ActionResult ViewBookToUser()
        //{
        //    BookClass bc = new BookClass();

        //    List<ViewBookToUserModel> lst = bc.viewbooktouser();

        //    return View(lst);
        //}
    }
}