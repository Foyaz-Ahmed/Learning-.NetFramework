using FMSApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FMSApplication.Controllers
{
    [Authorize]
    public class SalaryController : Controller
    {
        // GET: Salary
        FMSEntities context = new FMSEntities();
        public ActionResult Index()
        {

            var salaries = context.Salaries.ToList();
            return View(salaries);

        }

        public ActionResult Create()
        {
            return View();

        }

        [HttpPost]
        public ActionResult Create(Salary s)
        {
            if (ModelState.IsValid)
            {
                context.Salaries.Add(s);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
        public ActionResult Edit(int Id)
        {

            var s = context.Salaries.FirstOrDefault(e => e.Id == Id);
            return View(s);
        }
        [HttpPost]
        public ActionResult Edit(Salary s)
        {
            if (ModelState.IsValid)
            {
                var old_value = context.Salaries.FirstOrDefault(e => e.Id == s.Id);
                context.Entry(old_value).CurrentValues.SetValues(s);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
        public ActionResult Details(int Id)
        {
            var s = context.Salaries.FirstOrDefault(e => e.Id == Id);
            return View(s);
        }
        public ActionResult Delete(int Id)
        {
            var s = context.Salaries.FirstOrDefault(e => e.Id == Id);
            return View(s);
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteP(int Id)
        {
            var salary_remove = context.Salaries.FirstOrDefault(e => e.Id == Id);
            context.Salaries.Remove(salary_remove);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}