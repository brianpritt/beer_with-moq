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
using Bar.Models.Repositories;


namespace Bar.Controllers
{
    public class BeersController : Controller
    {
        private IBeerRepository beerRepo;
        public BeersController(IBeerRepository thisRepo = null)
        {
            if(thisRepo == null)
            {
                this.beerRepo = new EFBeerRepository();
            }
            else
            {
                this.beerRepo = thisRepo;
            }
        }
        public IActionResult Index()
        {
            Debug.WriteLine("hello");
            return View(beerRepo.Beers.ToList());
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(string name, string type, int price, IFormFile picture)
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
            Beer newBeer = new Models.Beer(name, type, price, pictureArray);
            beerRepo.Add(newBeer);
            
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            return View(beerRepo.Beers.Include(beers => beers.BeerPatrons)
                .FirstOrDefault(beers => beers.BeerId == id));
        }
    }
}
