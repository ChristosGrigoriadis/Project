using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UberTappDeveloping.Models;

namespace UberTappDeveloping.ViewModels
{
    public class BeersViewModel
    {
        public IEnumerable<Beer> AllBeers { get; set; }
        public ILookup<int, FavBeer> FavBeers { get; set; }
        //public int BeerFilterId { get; set; }
    }
}