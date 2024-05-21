using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DBMS_PRO1.FUNCTIONS;
using DBMS_PRO1.Models;

namespace DBMS_PRO1.Controllers
{
    public class AuthorController : Controller
    {
        // GET: Author
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult AddAuthor()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddAuthor(AuthorModel am)
        {
            AuthorClass ac = new AuthorClass();

            int a = ac.addauthor(am);

            if(a > 0)
            {
                ViewBag.Message = "Author Added Successfully";
            }

            return View();
        }

        public ActionResult ViewAuthor()
        {
            AuthorClass ac = new AuthorClass();

            List<AuthorModel> lst = ac.viewauthor();

            return View(lst);
        }

        public ActionResult Delete(int id)
        {
            AuthorClass ac = new AuthorClass();

            ac.deleteauthor(id);

            return RedirectToAction("ViewAuthor", "Author");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            AuthorClass ac = new AuthorClass();

            AuthorModel am = ac.getauthor(id);

            return View(am);
        }

        [HttpPost]
        public ActionResult Edit(AuthorModel am)
        {
            AuthorClass ac = new AuthorClass();

            int a = ac.updateauthor(am);
            
            if(a > 0)
            {
                ViewBag.Message = "Author Updated Successfully";
            }

            return View();
        }
    }
}