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
           
            ViewBag.total_salary = context.Salaries.Sum(e => e.Amount) + context.Salaries.Sum(e => e.Bonus);

            // ViewBag.count = context.Players..Count(*);
            //ViewBag.count = (from o in context.Players.Count();
            var countfr = context.Players.Count(t => t.Position == "Forward");
            ViewBag.count_forward = countfr;

            var countcdm = context.Players.Count(t => t.Position == "CDM");
            ViewBag.count_cdm = countcdm;

            var countgk = context.Players.Count(t => t.Position == "GoalKeeper");
            ViewBag.count_gk = countgk;

            var countdf = context.Players.Count(t => t.Position == "Defender");
            ViewBag.count_df = countdf;

            ViewBag.total = countfr + countcdm + countgk + countdf;



            return View();
        }

    }
}