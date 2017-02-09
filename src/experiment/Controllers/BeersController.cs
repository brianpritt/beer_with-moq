using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Bar.Models;
using System.Diagnostics;
using Microsoft.AspNetCore.Http;
using System.IO;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Bar.Controllers
{
    public class BeersController : Controller
    {
        private BarDbContext db = new BarDbContext();
        public IActionResult Index()
        {
            Debug.WriteLine("hello");
            return View(db.Beers.ToList());
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(string name, string type, string price, IFormFile picture)
        {
            byte[] pictureArray = new byte[0];
            Debug.WriteLine(picture);
            if (picture.Length > 0)
            {
                using (var fileStream = picture.OpenReadStream())
                using (var ms = new MemoryStream())
                {
                    fileStream.CopyTo(ms);
                    pictureArray = ms.ToArray();
                }
            }
            Beer newBeer = new Models.Beer(name, type, int.Parse(price), pictureArray);
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
