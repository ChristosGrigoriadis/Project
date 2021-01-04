using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using UberTappDeveloping.DAL;
using UberTappDeveloping.Models;

namespace UberTappDeveloping.Controllers.API
{
    public class VenueFollowingsController : ApiController
    {
        private ApplicationDbContext context;

        public VenueFollowingsController()
        {
            context = new ApplicationDbContext();
        }


        [HttpPost] // api/venueFollowings
        public IHttpActionResult Follow(int id)
        {
            var userId = User.Identity.GetUserId();
            var exists = context.UserVenueFollowings
                .Any(f => f.BeerEnthusiastId == userId && f.VenueId == id);

            if (exists)
                return BadRequest("You already Follow this Venue.");

            var following = new UserVenueFollowing
            {
                BeerEnthusiastId = userId,
                VenueId = id
            };

            context.UserVenueFollowings.Add(following);
            context.SaveChanges();

            return Ok(); 
        }

        [HttpDelete]
        public IHttpActionResult Unfollow(int id)
        {
            var userId = User.Identity.GetUserId();

            var following = context.UserVenueFollowings
                .SingleOrDefault(f => f.BeerEnthusiastId == userId && f.VenueId == id);

            if (following == null)
                return NotFound();

            context.UserVenueFollowings.Remove(following);
            context.SaveChanges();

            return Ok();
        }

    }
}
