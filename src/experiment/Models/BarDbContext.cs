using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Bar.Models
{
    public class BarDbContext : DbContext
    {
        public BarDbContext()
        {

        }
        public DbSet<Beer> Beers { get; set; }
        public DbSet<Patron> Patrons { get; set; }
        public DbSet<BeerPatron> BeerPatron { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=BarDb;integrated security=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<BeerPatron>()
            //    .HasKey(p => new { p.BeerId, p.PatronId });
            modelBuilder.Entity<BeerPatron>()
                .HasOne(bp => bp.Beer)
                .WithMany(b => b.BeerPatrons)
                .HasForeignKey(bp => bp.BeerId);
            modelBuilder.Entity<BeerPatron>()
                .HasOne(bp => bp.Patron)
                .WithMany(p => p.BeerPatrons)
                .HasForeignKey(bp => bp.PatronId);
        }
    }

    public class BeerPatron
    {
        public BeerPatron()
        {

        }
        public BeerPatron(int beerId, int patronId)
        {
            BeerId = beerId;
            PatronId = patronId;
        }
        [Key]
        public int BeerPatronId { get; set; }
        public int BeerId { get; set; }
        public Beer Beer { get; set; }
        public int PatronId { get; set; }
        public Patron Patron { get; set; }
         
    }
}
