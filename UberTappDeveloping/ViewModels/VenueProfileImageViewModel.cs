using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UberTappDeveloping.ViewModels
{
    public class VenueProfileImageViewModel
    {
        public int VenueId { get; set; }
        public HttpPostedFileBase PostedImage { get; set; }
    }
}