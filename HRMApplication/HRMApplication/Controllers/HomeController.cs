using HRMApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HRMApplication.Controllers
{
    public class HomeController : Controller
    {
        HRMSEntities context = new HRMSEntities();
        public ActionResult Index()
        {
            ViewBag.total_salary = context.Employees.Sum(e => e.Salary); 

            //Player count
            var countfr = context.Designations.Count(t => t.Name == "Manager");
            ViewBag.count_forward = countfr;

            var countcdm = context.Designations.Count(t => t.Name == "Sr Software Eng");
            ViewBag.count_cdm = countcdm;

            var countcdm1 = context.Designations.Count(t => t.Name == "Jr Software Eng");
            ViewBag.count_cdm1 = countcdm;

            var countgk = context.Designations.Count(t => t.Name == "Seller");
            ViewBag.count_gk = countgk;

            var countdf = context.Designations.Count(t => t.Name == "Jr Exicutive");
            ViewBag.count_df = countdf;

            ViewBag.total = countfr + countcdm + countcdm1 + countgk + countdf;

            var Details = context.Employees
               .Join(context.Departments
               , od => od.Dept_ID
               , o => o.ID
               , (o, od) => new
               {
                   o.ID,
                   o.Name,
                   o.Salary,
                   o.Age,
                   o.JoiningDate,
                   od.Name
               });

            return View();
        }

    }
}