using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UberTappDeveloping.Models;

namespace UberTappDeveloping.ViewModels
{
    public class UserViewModel
    {
        public IEnumerable<ApplicationUser> AllUsers { get; set; }
        public bool ShowActions { get; set; }
        public ILookup<string, Following> Followers { get; set; }
    }
}