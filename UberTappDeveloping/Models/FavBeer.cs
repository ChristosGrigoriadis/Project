using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace UberTappDeveloping.Models
{
    public class FavBeer
    {
        [Key]
        [Column(Order = 1)]
        public string UserThatFollows { get; set; }

        [Key]
        [Column(Order = 2)]
        public int BeerToBeFollowed { get; set; }


        public ApplicationUser User { get; set; }
        public Beer Beer { get; set; }
    }
}