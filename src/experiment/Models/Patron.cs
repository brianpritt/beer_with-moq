using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Bar.Models
{
    public class Patron
    {
        public int PatronId { get; set; }
        public string Name { get; set; }
        public int Tab { get; set; }
        public List<BeerPatron> BeerPatrons { get; set; } 
    }
}
