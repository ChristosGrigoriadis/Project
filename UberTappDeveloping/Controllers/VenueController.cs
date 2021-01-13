using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using UberTappDeveloping.DAL;
using UberTappDeveloping.Models;
using UberTappDeveloping.ViewModels;
using System.Data.Entity;
using UberTappDeveloping.Helper.Roles;
using System.IO;
using System.Data.Entity.Migrations;

namespace UberTappDeveloping.Controllers
{
	[Authorize(Roles = RoleNames.VenueOwner+","+RoleNames.Admin)]
	public class VenueController : Controller
	{
		private ApplicationDbContext context;

		public VenueController()
		{
			context = new ApplicationDbContext();
		}

		protected override void Dispose(bool disposing)
		{
			base.Dispose(disposing);
		}

		byte[] ImageBytes(HttpPostedFileBase PostedImage)
		{
			byte[] imageBytes;
			using (BinaryReader br = new BinaryReader(PostedImage.InputStream))
			{
				imageBytes = br.ReadBytes(PostedImage.ContentLength);
			}

			return imageBytes;
		}

		[HttpPost]
		public ActionResult VenueProfileImage(VenueProfileImageViewModel viewModel)
		{
			if (viewModel.PostedImage == null)
				return RedirectToAction("venueprofile", new { id = viewModel.VenueId });

			var image = new VenueProfileImage
			{
				VenueId = viewModel.VenueId,
				Name = viewModel.PostedImage.FileName,
				Data = ImageBytes(viewModel.PostedImage)
			};

			context.VenueProfileImage.AddOrUpdate(image);
			context.SaveChanges();

			return RedirectToAction("venueprofile", new { id = viewModel.VenueId });
		}

		[HttpPost]
		public ActionResult VenueProfile(VenueProfileViewModel viewModel)
		{
			if (viewModel.PostedImage == null)
				return RedirectToAction("venueprofile", new { id = viewModel.VenueId });

			var image = new VenueImage
			{
				VenueId = viewModel.VenueId,
				Name = viewModel.PostedImage.FileName,
				ContentType = viewModel.PostedImage.ContentType,
				Data = ImageBytes(viewModel.PostedImage)
			};

			context.VenueImages.Add(image);
			context.SaveChanges();

			return RedirectToAction("venueprofile", new { id = viewModel.VenueId });
		}

		//Get: venue/VenueProfile/id
		[AllowAnonymous]
		public ActionResult VenueProfile(int id)
		{
			var venue = context.Venues
				.Include(v => v.VenueImages)
				.Include(v => v.ProfileImage)
				.Include(v => v.VenueBeers.Select(vb => vb.AvailableBeer))
				.Include(v => v.Events)
				.Include(v => v.Location)
				.SingleOrDefault(v => v.Id == id);

			var viewModel = new VenueProfileViewModel
			{
				VenueId = id,
				Venue = venue,
				GetImages = venue.VenueImages,
				ProfileImage = venue.ProfileImage,
				Beers = venue.VenueBeers.Select(vb => new BeerPriceViewModel { Name = vb.AvailableBeer.Name, Price = vb.Price }).OrderBy(vm => vm.Name),
				Events = venue.Events.OrderBy(e => e.Date),
				Location = venue.Location
			};

			return View(viewModel);
		}


		//Get venue/venueBeers
		[Authorize(Roles = RoleNames.VenueOwner)]
		public ActionResult VenueBeers()
		{
			var userId = User.Identity.GetUserId();
			var viewModel = new VenueBeersViewModel
			{
				AllBeers = context.Beers,
				MyVenues = context.Venues.Where(v => v.OwnerId == userId)
			};

			return View(viewModel);
		}

		// GET: Venue
		[AllowAnonymous]
		public ActionResult Index()
		{
			var userId = User.Identity.GetUserId();

			var followedVenuesIds = context.UserVenueFollowings
				.Where(vf => vf.BeerEnthusiastId == userId)
				.Select(vf => vf.VenueId)
				.ToList();


			var viewModel = new VenuesViewModel
			{
				IsIndexAction = true,
				Venues = context.Venues.Include(v => v.Location),
				FollowedVenues = followedVenuesIds
			};

			return View("Venues", viewModel);
		}

		//Get: Edit/id
		public ActionResult Edit(int id)
		{
			var venue = context.Venues.SingleOrDefault(v => v.Id == id);

			var viewModel = new VenueFormViewModel
			{
				Locations = context.Locations,
				ManagerName = venue.Manager,
				Venue = venue
			};

			return View("VenueForm", viewModel);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Update(Venue venue)
		{
			if (venue == null)
				return HttpNotFound();

			if (!ModelState.IsValid)
			{
				var viewModel = new VenueFormViewModel
				{
					Locations = context.Locations,
					ManagerName = GetUser().FirstName + " " + GetUser().LastName,
					Venue = venue
				};
				return View("VenueForm", viewModel);
			}

			var venueDb = context.Venues.SingleOrDefault(v => v.Id == venue.Id);

			venueDb.Name = venue.Name;
			venueDb.DateOpened = venue.DateOpened;
			venueDb.Manager = venue.Manager;
			venueDb.LocationId = venue.LocationId;



			context.SaveChanges();


			return RedirectToAction("Index", "home");
		}

		public ActionResult UserVenues()
		{
			var userId = User.Identity.GetUserId();

			var userVenues = context.Venues
				.Include(v => v.Location)
				.Where(v => v.OwnerId == userId);

			var viewModel = new VenuesViewModel
			{
				Venues = userVenues,
				IsIndexAction = false
			};

			return View("Venues", viewModel);
		}

		//private IEnumerable<object> GetLocations()
		//{
		//    //return context.Locations
		//    //    .Select(l => new { value = l.Id, text = l.Country + " | " + l.City + " | " + l.AddressLine1 + " " + l.AddressNumber });
		//    //    as IEnumerable<object>;
		//}

		private ApplicationUser GetUser()
		{
			var userId = User.Identity.GetUserId();
			return context.Users.SingleOrDefault(u => u.Id == userId);
		}

		//GET : venue/new
		public ActionResult New()
		{

			var viewModel = new VenueFormViewModel
			{
				Locations = context.Locations,
				ManagerName = GetUser().FirstName + " " + GetUser().LastName,
				Venue = new Venue()
			};


			return View("VenueForm", viewModel);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult New(Venue venue)
		{
			if (!ModelState.IsValid)
			{
				var viewModel = new VenueFormViewModel
				{
					Locations = context.Locations,
					ManagerName = GetUser().FirstName + " " + GetUser().LastName,
					Venue = new Venue()
				};
				return View("VenueForm", viewModel);
			}

			if (venue == null)
				return HttpNotFound();

			venue.OwnerId = User.Identity.GetUserId();
			context.Venues.Add(venue);
			context.SaveChanges();

			return RedirectToAction("Index", "home");
		}
	}
}