using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using UberTappDeveloping.DAL;
using System.Data.Entity;
using UberTappDeveloping.Models;
using UberTappDeveloping.Helper.Roles;

namespace UberTappDeveloping.Controllers.API
{
    public class EventsController : ApiController
    {
        private ApplicationDbContext context;

        public EventsController()
        {
            context = new ApplicationDbContext();
        }

        public IHttpActionResult DeleteEvent(int id)
        {
            var userId = User.Identity.GetUserId();
            var evnt = context.Events
                .Include(e => e.Venue)
                .Single(e => e.Id == id /*&& (e.Venue.OwnerId == userId || User.IsInRole(RoleNames.Admin))*/);

            if (evnt.IsCanceled)
                return NotFound();

            evnt.IsCanceled = true; //cancel event

            var notification = new Notification //create notification
            {
                Event = evnt,
                Type = Helper.Enums.NotificationType.EventCanceled
            };

            foreach (var follower in context.UserVenueFollowings.Where(uvf => uvf.VenueId == evnt.VenueId).Select(uvf => uvf.BeerEnthusiast).ToList())
            {
                context.UserNotifications.Add(new UserNotification { BeerEnthusiast = follower, Notification = notification });//notify venue followers
            }
            

            context.SaveChanges();

            return Ok(id);
        }
    }
}
