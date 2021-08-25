using HRMApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HRMApplication.Controllers
{
    public class DesignationController : Controller
    {
        // GET: Designation
        HRMSEntities context = new HRMSEntities();

        public ActionResult Index()
        {
            var dsg_Ifno = context.Designations.ToList();
            return View(dsg_Ifno);
        }
        public ActionResult Create()
        {
            return View();

        }

        [HttpPost]
        public ActionResult Create(Designation p)
        {
            if (ModelState.IsValid)
            {
                context.Designations.Add(p);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();

        }
        public ActionResult Edit(int Id)
        {

            var p = context.Designations.FirstOrDefault(e => e.desig_ID == Id);
            return View(p);


        }
        [HttpPost]
        public ActionResult Edit(Designation p)
        {
            if (ModelState.IsValid)
            {
                var old_value = context.Designations.FirstOrDefault(e => e.desig_ID == p.desig_ID);
                context.Entry(old_value).CurrentValues.SetValues(p);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
        public ActionResult Details(int Id)
        {
            var p = context.Designations.FirstOrDefault(e => e.desig_ID == Id);
            return View(p);
        }
        public ActionResult Delete(int Id)
        {
            var p = context.Designations.FirstOrDefault(e => e.desig_ID == Id);
            return View(p);
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteP(int Id)
        {
            var company_remove = context.Designations.FirstOrDefault(e => e.desig_ID == Id);
            context.Designations.Remove(company_remove);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}