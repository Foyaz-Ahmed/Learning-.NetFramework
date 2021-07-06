using FMSApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FMSApplication.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        FMSEntities context = new FMSEntities();
        public ActionResult Index()
        {
           //Salary Count 
            ViewBag.total_salary = context.Salaries.Sum(e => e.Amount) + context.Salaries.Sum(e => e.Bonus);

           //Player count
            var countfr = context.Players.Count(t => t.Position == "Forward");
            ViewBag.count_forward = countfr;

            var countcdm = context.Players.Count(t => t.Position == "CDM");
            ViewBag.count_cdm = countcdm;

            var countgk = context.Players.Count(t => t.Position == "GoalKeeper");
            ViewBag.count_gk = countgk;

            var countdf = context.Players.Count(t => t.Position == "Defender");
            ViewBag.count_df = countdf;

            ViewBag.total = countfr + countcdm + countgk + countdf;

            //employee count
            var t1 = context.EmployeeInformations.Count(e => e.E_Designation == "Coach");
            ViewBag.count_coach = t1;

            var t2 = context.EmployeeInformations.Count(e => e.E_Designation == "Staff");
            ViewBag.count_staff = t2;

            var t3 = context.EmployeeInformations.Count(e => e.E_Designation == "Assistant Coach");
            ViewBag.count_acoach = t3;

            var t4 = context.EmployeeInformations.Count(e => e.E_Designation == "Physio");
            ViewBag.count_physio = t4;

            var t5 = context.EmployeeInformations.Count(e => e.E_Designation == "Admin");
            ViewBag.count_admin = t5;

            ViewBag.t = t1 + t2 + t3 + t5 + t4;

            return View();
        }

    }
}