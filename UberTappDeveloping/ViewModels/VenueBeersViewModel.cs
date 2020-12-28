using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UberTappDeveloping.Models;

namespace UberTappDeveloping.ViewModels
{
    public class VenueBeersViewModel
    {
        public IEnumerable<Beer> AllBeers { get; set; }
        
        public IEnumerable<Venue> MyVenues { get; set; }
    }
}