using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UberTappDeveloping.Models;

namespace UberTappDeveloping.ViewModels
{
    public class VenueFormViewModel
    {
        public Venue Venue { get; set; }

        public IEnumerable<object> Locations { get; set; }


    }
}