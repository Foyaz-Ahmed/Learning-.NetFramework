using HRMApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HRMApplication.Controllers
{
    public class DepartmentController : Controller
    {
        // GET: Deparmnt

        HRMSEntities context = new HRMSEntities();
        public ActionResult Index()
        {
           var  deptIfno = context.Departments.ToList();
            return View(deptIfno);
           
        }
        public ActionResult Create()
        {
            return View();

        }

        [HttpPost]
        public ActionResult Create(Department p)
        {
            if (ModelState.IsValid)
            {
                context.Departments.Add(p);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();

        }
        public ActionResult Edit(int Id)
        {

            var p = context.Departments.FirstOrDefault(e => e.ID == Id);
            return View(p);
        }

        [HttpPost]
        public ActionResult Edit(Department p)
        {
            if (ModelState.IsValid)
            {
                var old_value = context.Departments.FirstOrDefault(e => e.ID == p.ID);
                context.Entry(old_value).CurrentValues.SetValues(p);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
        public ActionResult Details(int Id)
        {
            var p = context.Departments.FirstOrDefault(e => e.ID == Id);
            return View(p);
        }
        public ActionResult Delete(int Id)
        {
            var p = context.Departments.FirstOrDefault(e => e.ID == Id);
            return View(p);
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteP(int Id)
        {
            var department_remove = context.Departments.FirstOrDefault(e => e.ID == Id);
            context.Departments.Remove(department_remove);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}