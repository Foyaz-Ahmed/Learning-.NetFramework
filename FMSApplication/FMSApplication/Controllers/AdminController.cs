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


        [Authorize]
        public ActionResult Index()
        {
            var id = Session["uname"].ToString();

            var s = context.EmployeeInformations.FirstOrDefault(e => e.Id.ToString() == id);
            return View(s);

        }
    }
}