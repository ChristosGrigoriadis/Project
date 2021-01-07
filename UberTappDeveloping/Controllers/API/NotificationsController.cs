using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using UberTappDeveloping.DAL;
using System.Data.Entity;
using AutoMapper;
using UberTappDeveloping.Models;
using UberTappDeveloping.Models.ModelDtos;

namespace UberTappDeveloping.Controllers.API
{
    public class NotificationsController : ApiController
    {
        private ApplicationDbContext context;

        public NotificationsController()
        {
            context = new ApplicationDbContext();
        }

        [HttpGet]
        public IHttpActionResult Notifications()
        {
            var userId = User.Identity.GetUserId();

            var notifications = context.UserNotifications
                .Where(un => un.BeerEnthusiastId == userId && !un.IsRead)
                .Select(un => un.Notification)
                .Include(n => n.Event.Venue)
                .ToList();

            return Ok(notifications.Select(Mapper.Map<Notification, NotificationDto>));
        }

        [HttpPost]
        public IHttpActionResult MarkasRead()
        {
            var userId = User.Identity.GetUserId();
            var userNotifications = context.UserNotifications
                .Where(un => un.BeerEnthusiastId == userId && !un.IsRead)
                .ToList();

            foreach (var userNotification in userNotifications)
            {
                userNotification.IsRead = true;
            }
            
            context.SaveChanges();

            return Ok();

        }

    }
}
