using db.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList.Mvc;
using PagedList;

namespace db.Controllers
{
    public class CoachController : Controller
    {
        CoachEntities context = new CoachEntities();

        public ActionResult Index(string sortOrder, string sortBy)
        {
            ViewBag.sortOrder = sortOrder;
            var player = context.Players.ToList();

            switch(sortBy)
            {
                case "Name":
                    {
                        switch (sortOrder)
                        {
                            case "Asc":
                                {
                                    player = player.OrderBy(e => e.Name).ToList();
                                    break;
                                }
                            case "Desc":
                                {
                                    player = player.OrderByDescending(e => e.Name).ToList();
                                    break;
                                }
                            default:
                                {
                                    player = player.OrderBy(e => e.Name).ToList();
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
                                    player = player.OrderBy(e => e.Age).ToList();
                                    break;
                                }
                            case "Desc":
                                {
                                    player = player.OrderByDescending(e => e.Age).ToList();
                                    break;
                                }
                            default:
                                {
                                    player = player.OrderBy(e => e.Age).ToList();
                                    break;
                                }
                        }
                        break;
                    }
                default:
                    {
                        player = player.OrderBy(e => e.Name).ToList();
                        break;
                    }
            }

            return View(player);
        }
        [HttpPost]
        public ActionResult Index(string searchText)
        {
            var player = context.Players.ToList();
            if (searchText != null)
            {
                player = context.Players.Where(e => e.Name.Contains (searchText) || e.Position.Contains(searchText) || e.Style.Contains(searchText) || e.Age.Contains(searchText)).ToList();
            }
            return View(player);
        }

        public ActionResult Formation()
        {
            var formations = context.Formations.ToList();
            return View(formations);
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Formation f)
        {
            if(ModelState.IsValid)
            {
                context.Formations.Add(f);
                context.SaveChanges();
                return RedirectToAction("Formation");
            }
            return View();
            
        }

        public ActionResult Edit(int id)
        {
            var f = context.Formations.FirstOrDefault(e => e.id == id);
            return View(f);
        }
        [HttpPost]
        public ActionResult Edit(Formation f)
        {
            var oldf = context.Formations.FirstOrDefault(e => e.id == f.id);
            context.Entry(oldf).CurrentValues.SetValues(f);
            context.SaveChanges();
            return RedirectToAction("Formation");
        }

        public ActionResult Details(int id)
        {
            var f = context.Formations.FirstOrDefault(e => e.id == id);
            return View(f);
        }

        public ActionResult Delete(int id)
        {
            var f = context.Formations.FirstOrDefault(e => e.id == id);
            return View(f);
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteF(int id)
        {
            var f = context.Formations.FirstOrDefault(e => e.id == id);
            context.Formations.Remove(f);
            context.SaveChanges();
            return RedirectToAction("Formation");
        }


        public ActionResult Selection()
        {
            return View();
        }


        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}