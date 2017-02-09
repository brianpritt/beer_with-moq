using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Bar.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Bar.Controllers
{
    public class BeersController : Controller
    {
        private BarDbContext db = new BarDbContext();
        public IActionResult Index()
        {
            return View(db.Beers.ToList());
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Beer newBeer)
        {
            db.Beers.Add(newBeer);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            return View(db.Beers.Include(beers => beers.BeerPatrons)
                .FirstOrDefault(beers => beers.BeerId == id));
        }
    }
}
