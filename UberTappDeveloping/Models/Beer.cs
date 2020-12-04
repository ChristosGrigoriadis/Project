using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UberTappDeveloping.Models
{
    public class Beer
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        
        public int? EBC { get; set; } // European Brewery Convention -Colour-
        public double? ABV { get; set; } // Alcohol By Volume 3% - 13% for beers
        public int? IBU { get; set; } // International Bitterness Units
        public string Description { get; set; }

        public ICollection<UserBeer> UserBeers { get; set; }
        public ICollection<VenueBeer> VenueBeers { get; set; }



    }
}