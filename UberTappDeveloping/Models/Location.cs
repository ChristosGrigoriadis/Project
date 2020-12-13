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
		public int PostalCode { get; set; }

		public string Territory { get; set; }

		public decimal Latitude { get; set; }

		public decimal Longitude { get; set; }

		public string Display
		{
			get
			{
				return PostalCode + " - " + Territory;
			}
		}

		public ICollection<ApplicationUser> UserLocations { get; set; }
        public ICollection<Venue> VenueLocations { get; set; }

    }
}