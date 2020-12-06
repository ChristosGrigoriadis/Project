using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UberTappDeveloping.Models
{
	public class Location
	{
		public int Id { get; set; }

		[Required]
		public string Country { get; set; }

		[Required]
		public string City { get; set; }

		[Required]
		public string AddressLine1 { get; set; }
		public string AddressLine2 { get; set; }

		[Required]
		public string AddressNumber { get; set; }
		public int PostalCode { get; set; }

		public string GetLocation()
        {
			return Country + " | " + City + " | " + AddressLine1 + " | " + AddressNumber;

		}

        public ICollection<ApplicationUser> UserLocations { get; set; }
        public ICollection<Venue> VenueLocations { get; set; }

    }
}