using HRMApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HRMApplication.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        HRMSEntities context = new HRMSEntities();

        public ActionResult Index(string sortOrder, string sortBy)
        {
            ViewBag.sortOrder = sortOrder;
            var info = context.Employees.ToList();

            switch (sortBy)
            {
                case "Name":
                    {
                        switch (sortOrder)
                        {
                            case "Asc":
                                {
                                    info = info.OrderBy(e => e.Name).ToList();
                                    break;
                                }
                            case "Desc":
                                {
                                    info = info.OrderByDescending(e => e.Name).ToList();
                                    break;
                                }
                            default:
                                {
                                    info = info.OrderBy(e => e.Name).ToList();
                                    break;
                                }
                        }
                        break;
                    }
                case "Age":
                    {
                        switch (sortOrder)
                        {
                            case "Asc":
                                {
                                    info = info.OrderBy(e => e.Age).ToList();
                                    break;
                                }
                            case "Desc":
                                {
                                    info = info.OrderByDescending(e => e.Age).ToList();
                                    break;
                                }
                            default:
                                {
                                    info = info.OrderBy(e => e.Age).ToList();
                                    break;
                                }
                        }
                        break;
                    }
                case "JoiningDate":
                    {
                        switch (sortOrder)
                        {
                            case "Asc":
                                {
                                    info = info.OrderBy(e => e.JoiningDate).ToList();
                                    break;
                                }
                            case "Desc":
                                {
                                    info = info.OrderByDescending(e => e.JoiningDate).ToList();
                                    break;
                                }
                            default:
                                {
                                    info = info.OrderBy(e => e.Age).ToList();
                                    break;
                                }
                        }
                        break;
                    }
                case "Salary":
                    {
                        switch (sortOrder)
                        {
                            case "Asc":
                                {
                                    info = info.OrderBy(e => e.Salary).ToList();
                                    break;
                                }
                            case "Desc":
                                {
                                    info = info.OrderByDescending(e => e.Salary).ToList();
                                    break;
                                }
                            default:
                                {
                                    info = info.OrderBy(e => e.Salary).ToList();
                                    break;
                                }
                        }
                        break;
                    }
                default:
                    {
                        info = info.OrderBy(e => e.Name).ToList();
                        break;
                    }
            }
            return View(info);
            //var employeesIfno = context.Employees.ToList();
            //return View(employeesIfno);
        }
        public ActionResult Create()
        {
            return View();

        }

        [HttpPost]
        public ActionResult Create(Employee p)
        {
            if (ModelState.IsValid)
            {
                context.Employees.Add(p);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();

        }

        
        public ActionResult Edit(int Id)
        {

            var p = context.Employees.FirstOrDefault(e => e.ID == Id);
            return View(p);
        }

        [HttpPost]
        public ActionResult Edit(Employee p)
        {
            if (ModelState.IsValid)
            {
                var old_value = context.Employees.FirstOrDefault(e => e.ID == p.ID);
                context.Entry(old_value).CurrentValues.SetValues(p);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
        public ActionResult Details(int Id)
        {
            var p = context.Employees.FirstOrDefault(e => e.ID == Id);
            return View(p);
        }
        public ActionResult Delete(int Id)
        {
            var p = context.Employees.FirstOrDefault(e => e.ID == Id);
            return View(p);
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteP(int Id)
        {
            var employee_remove = context.Employees.FirstOrDefault(e => e.ID == Id);
            context.Employees.Remove(employee_remove);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}