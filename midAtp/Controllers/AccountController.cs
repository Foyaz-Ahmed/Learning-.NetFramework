using db.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace db.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        CoachEntities context = new CoachEntities();

        public ActionResult Index()
        {
            return this.RedirectToAction("Index", "Home");
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(User u)
        {
            context.Users.Add(u);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(User u)
        {
            
            
            if (context.Users.Where(e => e.Email == u.Email && e.Password == u.Password).FirstOrDefault() == null)
            {
                ModelState.AddModelError("Error", "Ivalid Credintials");
                return View();
            }
            else
            {
                Session["Email"] = u.Email;
                return RedirectToAction("Index", "Coach");
            }
               
            
            


        }

        public ActionResult LogOut()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }

    }
}