using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UberTappDeveloping.Models;

namespace UberTappDeveloping.ViewModels
{
    public class ControlPanelViewModel
    {
        public ApplicationUser ActiveUser { get; set; }
        public ICollection<ApplicationUser> AllUsers { get; set; }
        public ICollection<Beer> AllBeers { get; set; }
        public ICollection<Venue> AllVenues { get; set; }
        public ICollection<UserBeer> MyFavBeers { get; set; }
        
    }
}