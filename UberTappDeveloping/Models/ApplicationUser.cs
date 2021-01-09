using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using UberTappDeveloping.Helper.Enums;

namespace UberTappDeveloping.Models
{
	public class ApplicationUser : IdentityUser
	{
		// User Properties here //
		[Display(Name = "First Name")]
		[StringLength(50, MinimumLength = 3, ErrorMessage = "First Name should be 3-50 characters long")]
		public string FirstName { get; set; }

		[Display(Name = "Last Name")]
		[StringLength(50, MinimumLength = 3, ErrorMessage = "Last Name should be 3-50 characters long")]
		public string LastName { get; set; }

		[DataType(DataType.Date)]
		[DisplayFormat(DataFormatString = "{0:dd/MMM/yyyy}", ApplyFormatInEditMode = true)]
		[Display(Name = "Date Of Birth")]
		public DateTime? BirthDate { get; set; }

		public Gender? Gender { get; set; }

		[Display(Name = "Are you a Venue Owner?")]
		public bool IsVenueOwner { get; set; }

		public ICollection<Venue> VenuesOwned { get; set; }

		public ICollection<UserBeer> UserBeers { get; set; }

		[Display(Name = "Location")]
		public int LocationId { get; set; }
		public Location Location { get; set; }

		[Display(Name = "Is Premium User?")]
		public bool IsPremiumUser { get; set; }

		public ICollection<Following> Followers { get; set; }
		public ICollection<Following> Followees { get; set; }


		public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
		{
			// Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
			var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
			// Add custom user claims here
			return userIdentity;
		}
	}
}