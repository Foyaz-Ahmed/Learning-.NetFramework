using FMSApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FMSApplication.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        FMSEntities context = new FMSEntities();
        public ActionResult Index()
        {
            

            return View();
        }
    }
}