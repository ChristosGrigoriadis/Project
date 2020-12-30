using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UberTappDeveloping.Models;

namespace UberTappDeveloping.ViewModels
{
    public class VenuesViewModel
    {
        public IEnumerable<Venue> Venues { get; set; }
        public bool IsIndexAction { get; set; }
    }
}