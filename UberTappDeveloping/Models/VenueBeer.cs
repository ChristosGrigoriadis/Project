using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace UberTappDeveloping.Models
{
    public class VenueBeer
    {
        [Key]
        [Column(Order = 1)]
        public int AvailableBeerId { get; set; }

        [Key]
        [Column(Order = 2)]
        public int VenueId { get; set; }

        public double Price { get; set; }

        public Beer AvailableBeer { get; set; }
        public Venue Venue { get; set; }
    }
}