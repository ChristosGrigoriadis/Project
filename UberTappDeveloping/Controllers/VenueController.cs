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

namespace UberTappDeveloping.Controllers
{
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


        public ActionResult VenueBeers()
        {
            var viewModel = new VenueBeersViewModel
            {
                AllBeers = context.Beers
            };

            return View(viewModel);
        }

        // GET: Venue
        public ActionResult Index()
        {
            return View();
        }

        //Get: Edit/id
        [Authorize(Roles = "Venue Owner")]
        public ActionResult Edit(int id)
        {
            var venue = context.Venues.SingleOrDefault(v => v.Id == id);

            var viewModel = new VenueFormViewModel
            {
                Locations = GetLocations(),
                ManagerName = GetUser().FirstName + " " + GetUser().LastName,
                Venue = venue
            };

            return View("VenueForm", viewModel);
        }

        [HttpPost]
        [Authorize(Roles = "Venue Owner")]
        public ActionResult Update(Venue venue)
        {
            if (venue == null)
                return HttpNotFound();

            if (!ModelState.IsValid)
            {
                var viewModel = new VenueFormViewModel
                {
                    Locations = GetLocations(),
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

        [Authorize(Roles = "Venue Owner")]
        public ActionResult UserVenues()
        {
            var userId = User.Identity.GetUserId();

            var userVenues = context.Venues
                .Include(v => v.Location)
                .Where(v => v.OwnerId == userId);

            return View(userVenues);
        }

        private IEnumerable<object> GetLocations()
        {
            return context.Locations
                .Select(l => new { value = l.Id, text = l.Country + " | " + l.City + " | " + l.AddressLine1 + " " + l.AddressNumber });
            //    as IEnumerable<object>;
        }

        private ApplicationUser GetUser()
        {
            var userId = User.Identity.GetUserId();
            return context.Users.SingleOrDefault(u => u.Id == userId);
        }

        //GET : venue/new
        [Authorize(Roles = "Venue Owner")]
        public ActionResult New()
        {
            
            var viewModel = new VenueFormViewModel
            {
                Locations = GetLocations(),
                ManagerName = GetUser().FirstName + " " + GetUser().LastName,
                Venue = new Venue()
            };


            return View("VenueForm", viewModel);
        }

        [HttpPost]
        [Authorize(Roles = "Venue Owner")]
        public ActionResult New(Venue venue)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new VenueFormViewModel
                {
                    Locations = GetLocations(),
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