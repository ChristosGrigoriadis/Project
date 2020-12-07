using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace UberTappDeveloping.Models
{
    public class UserBeer
    {
        [Key]
        [Column(Order = 1)]
        public int FavouriteBeerId { get; set; }

        [Key]
        [Column(Order = 2)]
        public string BeerEnthusiastId { get; set; }

        public Beer FavouriteBeer { get; set; }

        public ApplicationUser BeerEnthusiast { get; set; }
    }
}