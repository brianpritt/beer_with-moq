
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bar.Models.Repositories
{
    public interface IBeerRepository
    {
        IQueryable<Beer> Beers { get; }
        Beer Add(Beer beer);
        Beer Edit(Beer beer);
        void Remove(Beer beer);
    }
}
