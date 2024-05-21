using DBMS_PRO1.FUNCTIONS;
using DBMS_PRO1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DBMS_PRO1.Controllers;

namespace DBMS_PRO1.Controllers
{
    public class IssueBookController : Controller
    {
        // GET: IssueBook

        public int CUserid = LoginController.current_user;

        public ActionResult Index()
        {

            return View();
        }

        public ActionResult ViewIssue()
        {
            IssueBookClass bc = new IssueBookClass();

            List<ViewBookToUserModel> lst = bc.viewbooktouser();

            return View(lst);
        }

        public ActionResult UserIssuebook(int Bookid)
        {
            DateTime issuedate = DateTime.Now;
            DateTime DueDate = issuedate.AddDays(14);

            IssueBookClass issueBookClass = new IssueBookClass();

            int a = issueBookClass.issuebook(CUserid, Bookid, DueDate);

            if(a > 0)
            {
                ViewBag.Message = "Book Issued Successfully";
                return RedirectToAction("UserIssuedBook", "IssueBook");
            }

            return View();
        }

        public ActionResult UserIssuedBook()
        {
            IssueBookClass ibc = new IssueBookClass();

            List<UserIssuedBookModel> lst = ibc.userissuedbook(CUserid);

            return View(lst);
        }

        public ActionResult ViewBookIssuanceToAdmin()
        {
            IssueBookClass obj = new IssueBookClass();

            List<IssueModel> lst = obj.ViewBookIssuanceToAdmin();

            return View(lst);
        }
    }   

}