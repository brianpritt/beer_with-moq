using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Bar.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Bar.Controllers
{
    public class PatronsController : Controller
    {
        private BarDbContext db = new BarDbContext();

        public IActionResult Index()
        {
            return View(db.Patrons.ToList());
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Patron newPatron)
        {
            db.Patrons.Add(newPatron);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            ViewBag.Beers = new SelectList(db.Beers, "BeerId", "Name");
            return View(db.Patrons
                .Include(p => p.BeerPatrons)
                .ThenInclude(bp => bp.Beer)
                .FirstOrDefault(patron => patron.PatronId == id));
        }
        [HttpPost]
        public IActionResult Details(int id, Beer selectedBeer)
        {
            //Debug.WriteLine(selectedBeer.Name);
            //BeerPatron newBeerPatron = new BeerPatron(selectedBeer.BeerId, id);
            //db.BeerPatron.Add(newBeerPatron);
            //db.SaveChanges();
            return RedirectToAction("Details");
        }
    }
}
