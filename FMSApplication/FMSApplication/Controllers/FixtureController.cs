using FMSApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FMSApplication.Controllers
{
    [Authorize]
    public class FixtureController : Controller
    {
        // GET: Fixture
        FMSEntities context = new FMSEntities();
        public ActionResult Index()
        {

            var fixures = context.Fixtures.ToList();
            return View(fixures);

        }
        public ActionResult Details(int Id)
        {
            var f = context.Fixtures.FirstOrDefault(p => p.Id == Id);
            return View(f);
        }
 
    }
}