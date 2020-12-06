using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UberTappDeveloping.DAL;
using UberTappDeveloping.Models;
using UberTappDeveloping.ViewModels;

namespace UberTappDeveloping.Controllers
{
    public class VenueController : Controller
    {
        private ApplicationDbContext context;

        public VenueController()
        {
            context = new ApplicationDbContext();
        }

        // GET: Venue
        public ActionResult Index()
        {
            return View();
        }

        private IEnumerable<object> GetLocations()
        {
            return context.Locations
                .Select(l => new { value = l.Id, text = l.Country + " | " + l.City + " | " + l.AddressLine1 + " " + l.AddressNumber });
        }

        //GET : venue/new
        public ActionResult New()
        {
            //var list = context.Locations
            //    .Select(l => new { value = l.Id, text = l.Country + " | " + l.City + " | " + l.AddressLine1 + " " + l.AddressNumber })
            //    as IEnumerable<object>;

            var viewModel = new VenueFormViewModel
            {
                Locations = GetLocations()
            };


            return View("VenueForm", viewModel);
        }

        [HttpPost]
        public ActionResult New(Venue venue)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new VenueFormViewModel { Locations = GetLocations() };
                return View("VenueForm", viewModel);
            }

            if (venue == null)
                return HttpNotFound();

            context.Venues.Add(venue);
            context.SaveChanges();

            return RedirectToAction("Index", "home");
        }
    }
}