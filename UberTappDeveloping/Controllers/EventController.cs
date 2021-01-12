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
    [Authorize(Roles = RoleNames.VenueOwner + "," + RoleNames.Admin)]
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
                            .Where(e => e.Date >= DateTime.Now)
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
                .Where(e => e.Venue.OwnerId == userId && e.Date >= DateTime.Now)
                .OrderBy(e => e.Date);

            var viewModel = new EventsViewModel
            {
                Events = myEvents,
                IsIndexAction = false
            };

            return View("Events", viewModel);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Update(EventFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors);

                return View("EventForm", new EventFormViewModel(User.Identity.GetUserId(), viewModel.Event)); ;
            }

            var evntDb = context.Events.SingleOrDefault(e => e.Id == viewModel.Event.Id);

            if (evntDb.Description == viewModel.Event.Description && evntDb.Date == viewModel.Event.Date && evntDb.VenueId == viewModel.Event.VenueId)
                return RedirectToAction("venueOwnerEvents", "event");//dont create new notification if everything is the same

            var notification = new Notification
            {
                EventId = evntDb.Id,
                OriginalDate = evntDb.Date,
                OriginalDescription = evntDb.Description,
                OriginalVenueId = evntDb.VenueId,
                Type = Helper.Enums.NotificationType.EventUpdated
            };

            context.Notifications.Add(notification);//create new notification

            foreach (var follower in context.UserVenueFollowings.Where(f => f.VenueId == evntDb.VenueId).Select(f => f.BeerEnthusiast).ToList())
            {
                context.UserNotifications.Add(new UserNotification { BeerEnthusiast = follower, Notification = notification });//add a notification to users that follow this venue
            }

            //update event
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
        [ValidateAntiForgeryToken]
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

            var notification = new Notification
            {
                Event = evnt,
                Type = Helper.Enums.NotificationType.EventCreated
            };

            context.Notifications.Add(notification);//create new notification

            
            foreach (var follower in context.UserVenueFollowings.Where(f => f.VenueId == evnt.VenueId).Select(f => f.BeerEnthusiast).ToList())
            {
                context.UserNotifications.Add(new UserNotification { BeerEnthusiast = follower, Notification = notification});//add a notification to users that follow this venue
            }

            context.SaveChanges();


            return RedirectToAction("venueOwnerEvents", "event");
        }

    }
}