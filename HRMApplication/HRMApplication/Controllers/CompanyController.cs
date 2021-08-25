using HRMApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HRMApplication.Controllers
{
    public class CompanyController : Controller
    {
        // GET: Company
        HRMSEntities context = new HRMSEntities();

        public ActionResult Index()
        {
            var comapniesIfno = context.Companies.ToList();
            return View(comapniesIfno);
        }
        public ActionResult Create()
        {
            return View();

        }

        [HttpPost]
        public ActionResult Create(Company p)
        {
            if (ModelState.IsValid)
            {
                context.Companies.Add(p);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();

        }
        public ActionResult Edit(int Id)
        {

            var p = context.Companies.FirstOrDefault(e => e.ID == Id);
            return View(p);


        }
        [HttpPost]
        public ActionResult Edit(Company p)
        {
            if (ModelState.IsValid)
            {
                var old_value = context.Companies.FirstOrDefault(e => e.ID == p.ID);
                context.Entry(old_value).CurrentValues.SetValues(p);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
        public ActionResult Details(int Id)
        {
            var p = context.Companies.FirstOrDefault(e => e.ID == Id);
            return View(p);
        }
        public ActionResult Delete(int Id)
        {
            var p = context.Companies.FirstOrDefault(e => e.ID == Id);
            return View(p);
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteP(int Id)
        {
            var company_remove = context.Companies.FirstOrDefault(e => e.ID == Id);
            context.Companies.Remove(company_remove);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}