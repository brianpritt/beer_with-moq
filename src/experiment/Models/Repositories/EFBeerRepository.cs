using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Bar.Models.Repositories
{
    public class EFBeerRepository : IBeerRepository
    {
        BarDbContext db = new BarDbContext();

        public IQueryable<Beer> Beers
        { get { return db.Beers; } }

        public Beer Add(Beer beer)
        {
            db.Beers.Add(beer);
            db.SaveChanges();
            return beer;
        }
        public Beer Edit(Beer beer)
        {
            db.Entry(beer).State = EntityState.Modified;
            db.SaveChanges();
            return beer;
        }
        public void Remove (Beer beer)
        {
            db.Beers.Remove(beer);
            db.SaveChanges();
        }
    }
}
