using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UberTappDeveloping.DAL;
using UberTappDeveloping.Helper.Roles;
using UberTappDeveloping.Models;
using System.Data.Entity;
using UberTappDeveloping.ViewModels;

namespace UberTappDeveloping.Controllers
{
	public class ApplicationUserController : Controller
	{
		private ApplicationDbContext context;

		public ApplicationUserController()
		{
			context = new ApplicationDbContext();
		}

		protected override void Dispose(bool disposing)
		{
			context.Dispose();
		}

		#region GET

		// GET: All ApplicationUsers
		//[Authorize(Roles = RoleNames.Admin)]
		public ActionResult AllUsers()
		{
			var applicationUsers = context.Users.ToList();
			return View("AllUsers", applicationUsers);
		}

		// GET: An ApplicationUser
		//[Authorize]
		public ActionResult Edit(string id)
		{
			var applicationUser = context.Users.SingleOrDefault(u => u.Id == id);

			if (applicationUser == null)
				return HttpNotFound();

			var viewModel = new UserFormViewModel 
			{
				Id = applicationUser.Id,
				Email = applicationUser.Email,
				UserName = applicationUser.UserName,
				FirstName = applicationUser.FirstName,
				LastName=applicationUser.LastName,
				BirthDate = applicationUser.BirthDate,
				Gender =applicationUser.Gender,
				IsVenueOwner = applicationUser.IsVenueOwner,
				LocationId = applicationUser.LocationId,
				Locations = context.Locations
			};

			return View("UserForm", viewModel);
		}

		// GET: ApplicationUser Details
		//[Authorize]
		public ActionResult Details(string id)
		{
			var applicationUser = context.Users.SingleOrDefault(u => u.Id == id);

			if (applicationUser == null)
				return HttpNotFound();

			return View("Details", applicationUser);
		}

		#endregion

		#region POST

		// POST: Edit ApplicationUser
		[HttpPost]
		//[Authorize]
		[ValidateAntiForgeryToken]
		public ActionResult Save(ApplicationUser applicationUser)
		{

			if (!ModelState.IsValid)
			{
				return View("UserForm", applicationUser);
			}

			// update applicationUser
			var userDb = context.Users.Single(u => u.Id == applicationUser.Id);
			userDb.UserName = applicationUser.UserName;
			userDb.Email = applicationUser.Email;
			userDb.FirstName = applicationUser.FirstName;
			userDb.LastName = applicationUser.LastName;
			userDb.BirthDate = applicationUser.BirthDate;
			userDb.Gender = applicationUser.Gender;
			userDb.LocationId = applicationUser.LocationId;

			context.SaveChanges();

			return RedirectToAction("Details", applicationUser);
		}

		#endregion

	}
}