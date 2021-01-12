using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using UberTappDeveloping.Helper.CustomDA;
using UberTappDeveloping.Helper.Enums;
using UberTappDeveloping.Models;

namespace UberTappDeveloping.ViewModels
{
	public class UserFormViewModel
	{
		public string Id { get; set; }

		[Required]
		[EmailAddress]
		[Display(Name = "Email")]
		public string Email { get; set; }

		[Required]
		[Display(Name = "Username")]
		[StringLength(50, MinimumLength = 3, ErrorMessage = "Username should be 3-50 characters long")]
		public string UserName { get; set; }

		[Display(Name = "First Name")]
		[StringLength(50, MinimumLength = 3, ErrorMessage = "First Name should be 3-50 characters long")]
		public string FirstName { get; set; }

		[Display(Name = "Last Name")]
		[StringLength(50, MinimumLength = 3, ErrorMessage = "Last Name should be 3-50 characters long")]
		public string LastName { get; set; }

		[DataType(DataType.Date)]
		[DisplayFormat(DataFormatString = "{0:dd/MMM/yyyy}", ApplyFormatInEditMode = true)]
		[Display(Name = "Date Of Birth")]
		[IsAdult(ErrorMessage = "You have to be over 18!")]
		public DateTime? BirthDate { get; set; }

		public Gender? Gender { get; set; }

		[Display(Name = "Are you a Venue Owner?")]
		public bool IsVenueOwner { get; set; }

		[Display(Name = "Location")]
		public int LocationId { get; set; }
		public IEnumerable<Location> Locations { get; set; }

		[Display(Name = "Is Premium User?")]
		public bool IsPremiumUser { get; set; }
	}
}