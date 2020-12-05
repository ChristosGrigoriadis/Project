using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UberTappDeveloping.Models;

namespace UberTappDeveloping.ViewModels
{
    public class BeerViewModel
    {
        public IEnumerable<Beer> Beers { get; set; }
        public Beer Beer { get; set; }
        public bool ShowActions { get; set; }
    }
}