using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;


namespace Bar.Models
{
    public class Beer
    {
        public Beer()
        {

        }
        public Beer(string name, string type, int price, byte[] picture)
        {
            Name = name;
            Type = type;
            Price = price;
            Picture = picture;
        }
        public int BeerId { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int Price { get; set; }
        public byte[] Picture { get; set; }
        public List<BeerPatron> BeerPatrons { get; set; }

    }
}
