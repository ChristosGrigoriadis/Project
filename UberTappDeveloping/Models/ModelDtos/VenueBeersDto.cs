using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UberTappDeveloping.Models.ModelDtos
{
    public class VenueBeersDto
    {
        public int[] BeersArray { get; set; }
        public int VenueId { get; set; }
        public double[] PricesArray { get; set; }
    }
}