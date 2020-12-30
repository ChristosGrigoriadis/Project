using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using UberTappDeveloping.Models;

namespace UberTappDeveloping.ViewModels
{
    public class BeerViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }


        public int? EBC { get; set; } // European Brewery Convention -Colour-
        public double? ABV { get; set; } // Alcohol By Volume 3% - 13% for beers
        public int? IBU { get; set; } // International Bitterness Units
        public string Description { get; set; }

        public BeerViewModel(Beer beer)
        {
            Id = beer.Id;
            Name = beer.Name;
            EBC = beer.EBC;
            ABV = beer.ABV;
            Description = beer.Description;
        }

        public BeerViewModel() { }
    }
}