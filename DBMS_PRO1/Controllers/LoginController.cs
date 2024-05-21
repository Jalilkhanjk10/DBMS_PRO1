using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using DBMS_PRO1.FUNCTIONS;
using DBMS_PRO1.Models;

namespace DBMS_PRO1.Controllers
{
    public class LoginController : Controller
    {
        public static int current_user;
        // GET: Login
        //[Authorize]
        public ActionResult Index()
        {
            return View();
        }


        /// <summary>
        /// 
        /// 
        /// SIGN UP CONTROLLER
        /// 
        /// 
        /// </summary>
        /// <returns></returns>


        [HttpGet]
        public ActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignUp(LoginModel lm)
        {
            int check;

            LoginClass lc = new LoginClass();

            check = lc.signup(lm);

            if (check > 0)
            {
                ViewBag.Message = "Successfully Signed Up";
                return RedirectToAction("Login", "Login");
            }

            return View();
        }

        /// <summary>
        /// 
        /// 
        /// LOGIN CONTROLLER
        /// 
        /// 
        /// </summary>
        /// <returns></returns>

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginModel lm, string ReturnUrl)
        {
            int a;

            LoginClass lc = new LoginClass();

            a = lc.login(lm);

            if(a > 0)
            {
                FormsAuthentication.SetAuthCookie(lm.User_Name, false);
                Session["User_Name"] = lm.User_Name.ToString();

                if (ReturnUrl != null)
                {
                    return Redirect(ReturnUrl);
                }
                else
                {
                    
                    int b = lc.getuserid(lm);
                    current_user = b;
                    return RedirectToAction("ViewIssue", "IssueBook");
                }
            }

            return View();
        }

        /// <summary>
        /// 
        /// 
        /// ADMIN LOGIN CONTROLLER
        /// 
        /// 
        /// </summary>
        /// <returns></returns>


        [HttpGet]
        public ActionResult AdminLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AdminLogin(AdminLoginModel alm, string ReturnUrl)
        {
            LoginClass lc = new LoginClass();

            int a = lc.adminlogin(alm);

            if (a > 0)
            {
                FormsAuthentication.SetAuthCookie(alm.Admin_Name, false);
                Session["Admin_Name"] = alm.Admin_Name.ToString();

                if (ReturnUrl != null)
                {
                    return Redirect(ReturnUrl);
                }
                else
                {
                    return RedirectToAction("Index", "Login");
                }
            }

            return View();
        }
        
        public ActionResult Logout()
        {
            Session["Admin_Name"] = null;
            return RedirectToAction("AdminLogin", "Login");
        }
    }
}