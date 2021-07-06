using FMSApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace FMSApplication.Controllers
{
    public class LoginController : Controller
    {
        FMSEntities context = new FMSEntities();
        // GET: Login

        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(string UserName,string Password, string returnUrl)
        {
           //var match_value = context.Users.FirstOrDefault(uname => uname.UserName == user.UserName  && uname.Password == user.Password);
            var match_value = context.Users.FirstOrDefault(uname => uname.UserName == UserName  && uname.Password == Password);

            if (match_value != null)
            {
                 FormsAuthentication.SetAuthCookie(UserName, false);

                //Response.Cookies.Add(new HttpCookie("uname", user.UserName));

                return RedirectToAction("Index", "Home");
            
                 
            }
            else
            {
                ViewBag.message = "Input Field is Empty or Your are givien wrong info";

                return View();
            }

        }

        public ActionResult Logout() 
        {
       //     if (Request.Cookies["uname"] != null)
        //    {

        //        HttpCookie myCookie = new HttpCookie("uname");
         //       myCookie.Expires = DateTime.Now.AddDays(-1d);
       //         Response.Cookies.Add(myCookie);

         ///   }

            FormsAuthentication.SignOut();

            return Redirect("/Home");
        
        }
    }

}