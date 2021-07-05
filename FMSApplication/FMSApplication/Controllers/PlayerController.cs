using FMSApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FMSApplication.Controllers
{
    public class PlayerController : Controller
    {
        // GET: Admin
        
        FMSEntities context = new FMSEntities();
        public ActionResult Index()
        {
            return View();

        }
        public ActionResult PlayerList() {
           
            var players = context.Players.ToList();
            return View(players);
            
        }

        public ActionResult Create()
        {
            return View();

        }

        [HttpPost]
        public ActionResult Create(Player p)
        {
            context.Players.Add(p);
            context.SaveChanges();
            return RedirectToAction("PlayerList");
        }
        public ActionResult Edit(int Id)
        {

            var p = context.Players.FirstOrDefault(e => e.Id == Id);
            return View(p);
        }
        [HttpPost]
        public ActionResult Edit(Player p)
        {
            var old_value = context.Players.FirstOrDefault(e => e.Id == p.Id);
            context.Entry(old_value).CurrentValues.SetValues(p);
            context.SaveChanges();
            return RedirectToAction("PlayerList");
        }
        public ActionResult Details(int Id)
        {
            var p = context.Players.FirstOrDefault(e => e.Id == Id);
            return View(p);
        }
        public ActionResult Delete(int Id)
        {
            var p = context.Players.FirstOrDefault(e => e.Id == Id);
            return View(p);
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteP(int Id)
        {
            var player_remove = context.Players.FirstOrDefault(e => e.Id == Id);
            context.Players.Remove(player_remove);
            context.SaveChanges();
            return RedirectToAction("PlayerList");
        }
        
        
    }
}