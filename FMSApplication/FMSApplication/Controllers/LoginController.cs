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
        public ActionResult Index(string Username, string Password, string returnUrl)
        {
            var match_value = context.Users.FirstOrDefault(uname => uname.UserName == Username && uname.Password == Password);

            if (match_value != null)
            {
              FormsAuthentication.SetAuthCookie("Username", false);

              //  HttpCookie userInfo = new HttpCookie("userInfo");
              //  userInfo["Uname"] = "Admin";
             //   string value = string.Empty;
              //  value = Request.Cookies["Uname"].Value;
              //  ViewBag.cookie_value = value;
              
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
         
            FormsAuthentication.SignOut();
            
            return Redirect("/Home");
        
        }
    }

}