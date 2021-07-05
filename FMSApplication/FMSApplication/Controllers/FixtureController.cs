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
        public ActionResult Create()
        {
            return View();

        }

        [HttpPost]
        public ActionResult Create(Fixture f)
        {
            context.Fixtures.Add(f);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int Id)
        {
            var f = context.Fixtures.FirstOrDefault(s => s.Id == Id);
            return View(f);
        }
        [HttpPost]
        public ActionResult Edit(EmployeeInformation e)
        {
            var old_value = context.Fixtures.FirstOrDefault(p => p.Id == e.Id);
            context.Entry(old_value).CurrentValues.SetValues(e);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Details(int Id)
        {
            var f = context.Fixtures.FirstOrDefault(p => p.Id == Id);
            return View(f);
        }
 
    }
}