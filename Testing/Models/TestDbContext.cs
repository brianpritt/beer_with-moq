using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Bar.Models
{
    public class TestDbContext : BarDbContext
    {
        public override DbSet<Beer> Beers { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=BarDbTest;integrated security = True");
        }
    }
}
