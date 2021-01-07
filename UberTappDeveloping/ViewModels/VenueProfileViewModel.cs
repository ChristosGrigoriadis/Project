using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UberTappDeveloping.Models;

namespace UberTappDeveloping.ViewModels
{
    public class VenueProfileViewModel
    {
        public int VenueId { get; set; }
        public Venue Venue { get; set; }
        public HttpPostedFileBase PostedImage { get; set; }
        public IEnumerable<VenueImage> GetImages { get; set; }
        public VenueProfileImage ProfileImage { get; set; }
        public IEnumerable<BeerPriceViewModel> Beers { get; set; }
        public IEnumerable<Event> Events { get; set; }
        public Location Location { get; set; }


    }
}