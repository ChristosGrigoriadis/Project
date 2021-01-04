using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using UberTappDeveloping.DAL;
using UberTappDeveloping.Helper.Roles;
using UberTappDeveloping.Models;
using UberTappDeveloping.ViewModels;
using System.Data.Entity;
using System.Data.Entity.Migrations;

namespace UberTappDeveloping.Controllers
{
    [Authorize(Roles = RoleNames.VenueOwner)]
    public class EventController : Controller
    {
        private ApplicationDbContext context;

        public EventController()
        {
            context = new ApplicationDbContext();
        }

        // GET: Event
        [AllowAnonymous]
        public ActionResult Index()
        {
            var Events = context.Events
                            .Include(e => e.Venue)
                            .OrderBy(e => e.Date);

            var viewModel = new EventsViewModel
            {
                Events = Events,
                IsIndexAction = true
            };

            return View("Events", viewModel);
        }

        public ActionResult Edit(int id)
        {
            var evt = context.Events.SingleOrDefault(e => e.Id == id);

            return View("EventForm", new EventFormViewModel(User.Identity.GetUserId(), evt));
        }

        public ActionResult VenueOwnerEvents()
        {
            var userId = User.Identity.GetUserId();
            var myEvents = context.Events
                .Include(e => e.Venue)
                .Where(e => e.Venue.OwnerId == userId)
                .OrderBy(e => e.Date);

            var viewModel = new EventsViewModel
            {
                Events = myEvents,
                IsIndexAction = false
            };

            return View("Events", viewModel);
        }

        public ActionResult Update(EventFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors);

                return View("EventForm", new EventFormViewModel(User.Identity.GetUserId(), new Event())); ;
            }

            var evntDb = context.Events.SingleOrDefault(e => e.Id == viewModel.Event.Id);

            evntDb.Description = viewModel.Event.Description;
            evntDb.Date = viewModel.Event.Date;
            evntDb.VenueId = viewModel.Event.VenueId;

            context.SaveChanges();

            return RedirectToAction("venueOwnerEvents", "event");
        }

        [HttpGet]
        public ActionResult New()
        {

            return View("EventForm", new EventFormViewModel(User.Identity.GetUserId(), new Event()));
        }

        [HttpPost]
        public ActionResult New(EventFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors);

                return View("EventForm", new EventFormViewModel(User.Identity.GetUserId(), new Event())); ;
            }


            Event evnt = new Event
            {
                Date = viewModel.Event.Date,
                Description = viewModel.Event.Description,
                VenueId = viewModel.Event.VenueId
            };

            context.Events.Add(evnt);
            context.SaveChanges();


            return RedirectToAction("venueOwnerEvents", "event");
        }

    }
}