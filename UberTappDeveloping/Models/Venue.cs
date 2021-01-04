using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace UberTappDeveloping.Models
{
	public class Venue
	{
		public int Id { get; set; }

		[Required]
		[StringLength(225)]
		public string Name { get; set; }

		[Required]
		[StringLength(225)]
		public string Manager { get; set; }

		[Display(Name = "Date Founded")]
		public DateTime? DateOpened { get; set; }

        //[ForeignKey("ApplicationUser")]
        public string OwnerId { get; set; }
        public ApplicationUser Owner { get; set; }

        public ICollection<VenueBeer> VenueBeers { get; set; }

        [Display(Name = "Venue Location")]
        public int LocationId { get; set; }
        public Location Location { get; set; }

        public ICollection<VenueImage> VenueImages { get; set; }
        public VenueProfileImage ProfileImage { get; set; }
        public ICollection<Event> Events { get; set; }

        //[Required]
        //[Display(Name = "Address")]
        //public int LocationId { get; set; }
        //public Location Location { get; set; }

        //public ICollection<Beer> AvailableBeers { get; set; }

        //public ICollection<User> PeopleBeenHere { get; set; }
    }
}