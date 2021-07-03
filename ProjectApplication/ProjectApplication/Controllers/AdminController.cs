using ProjectApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectApplication.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin


        FMSEntities conxtext = new FMSEntities(); 
        public ActionResult Index()
        {
               
            return View();
        }
    }
}