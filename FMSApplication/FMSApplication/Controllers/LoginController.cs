using FMSApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FMSApplication.Controllers
{
    public class LoginController : Controller
    {
        FMSEntities context = new FMSEntities();
        // GET: Login

        public ActionResult Index() {

            return View();
        }
        [HttpPost]
        public ActionResult Index(string Username, string Password)
        {
            var match_value = context.Users.FirstOrDefault(uname => uname.UserName == Username && uname.Password == Password);

            if (match_value != null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.message = "Input Field is Empty or Your are givien wrong info";

                return View();
            }

        }
    }
}