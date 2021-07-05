using FMSApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FMSApplication.Controllers
{
    [Authorize]
    public class EmployeeController : Controller
    {
        // GET: Employee
        
            FMSEntities context = new FMSEntities();
            public ActionResult Index()
            {
            var employees = context.EmployeeInformations.ToList();
            
            return View(employees);
            

            }

            public ActionResult Create()
            {
                return View();

            }

            [HttpPost]
            public ActionResult Create(EmployeeInformation e)
            {
                context.EmployeeInformations.Add(e);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            public ActionResult Edit(int Id)
            {

                var e = context.EmployeeInformations.FirstOrDefault(s => s.Id == Id);
                return View(e);
            }
            [HttpPost]
            public ActionResult Edit(EmployeeInformation e)
            {
                var old_value = context.EmployeeInformations.FirstOrDefault(p => p.Id == e.Id);
                context.Entry(old_value).CurrentValues.SetValues(e);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            public ActionResult Details(int Id)
            {
                var e = context.EmployeeInformations.FirstOrDefault(p => p.Id == Id);
                return View(e);
            }
            public ActionResult Delete(int Id)
            {
                var e = context.EmployeeInformations.FirstOrDefault(p => p.Id == Id);
                return View(e);
            }
            [HttpPost]
            [ActionName("Delete")]
            public ActionResult DeleteP(int Id)
            {
                var employee_remove = context.EmployeeInformations.FirstOrDefault(p => p.Id == Id);

                context.EmployeeInformations.Remove(employee_remove);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
           
        
    }
}