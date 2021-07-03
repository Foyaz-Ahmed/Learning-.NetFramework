using ProjectApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectApplication.Controllers
{
    public class PlayerController : Controller
    {
        // GET: Player

        FMSEntities context = new FMSEntities();
        public ActionResult Index()
        {
            var players = context.Players.ToList();
            return View(players);
        }

        public ActionResult Create() {

            return View();
        }

        [HttpPost]
        public ActionResult Create(Player p) {
            context.Players.Add(p);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}