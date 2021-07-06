using FMSApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FMSApplication.Controllers
{
    [Authorize]
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

        [HttpPost]
        public ActionResult PlayerList(string Name)
        {

            var players = context.Players.ToList();
            if (Name != null)
            {

                players = context.Players.Where(e => e.Name.Contains(Name)).ToList();


            }

            return View(players);

        }

        public ActionResult Create()
        {
            return View();

        }

        [HttpPost]
        public ActionResult Create(Player p)
        {
            if (ModelState.IsValid)
            {
                context.Players.Add(p);
                context.SaveChanges();
                return RedirectToAction("PlayerList");
            }
            return View();
            
        }
        public ActionResult Edit(int Id)
        {
            
                var p = context.Players.FirstOrDefault(e => e.Id == Id);
                return View(p);
            
           
        }
        [HttpPost]
        public ActionResult Edit(Player p)
        {
            if (ModelState.IsValid)
            {
                var old_value = context.Players.FirstOrDefault(e => e.Id == p.Id);
                context.Entry(old_value).CurrentValues.SetValues(p);
                context.SaveChanges();
                return RedirectToAction("PlayerList");
            }
            return View();
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

        public ActionResult Defenders() {

            var defenders = context.Players.ToList().Where(e => e.Position == "Defender");
            return View(defenders);
        
        }

        public ActionResult Forward()
        {

            var defenders = context.Players.ToList().Where(e => e.Position == "Forward");
            return View(defenders);

        }

        public ActionResult CDM()
        {

            var cdm = context.Players.ToList().Where(e => e.Position == "CDM");
            return View(cdm);

        }
        public ActionResult GK()
        {

            var gk = context.Players.ToList().Where(e => e.Position == "Goalkeeper");
            return View(gk);

        }


    }
}