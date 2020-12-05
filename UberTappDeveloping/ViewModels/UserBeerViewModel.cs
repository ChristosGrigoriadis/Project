using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using UberTappDeveloping.Models;

namespace UberTappDeveloping.ViewModels
{
    public class UserBeerViewModel
    {
        [Display(Name = "Venue")]
        [Required]
        public byte VenueId { get; set; }
        public IEnumerable<Venue> Venues { get; set; }
    }
}