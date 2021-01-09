using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using UberTappDeveloping.DAL;
using UberTappDeveloping.Models;

namespace UberTappDeveloping.Controllers.API
{
    public class FollowersController : ApiController
    {
        private ApplicationDbContext context;

        public FollowersController()
        {
            context = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult AddFavourite(string id)
        {
            var userId = User.Identity.GetUserId();
            var exists = context.Followings.Any(f => f.FollowerId == userId && f.FolloweeId == id);
            if (exists)
                return BadRequest("User already followed");

            if (userId == id)
            {
                return BadRequest("You cant follow yourself ;)");
            }

            var newFollow = new Following
            {
                FolloweeId = id,
                FollowerId = userId
            };

            context.Followings.Add(newFollow);
            context.SaveChanges();

            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult RemoveFavourite(string id)
        {
            var userId = User.Identity.GetUserId();

            var follower = context.Followings.SingleOrDefault(f => f.FolloweeId == id);

            if (follower == null)
                return NotFound();

            context.Followings.Remove(follower);
            context.SaveChanges();



            return Ok();
        }
    }
}
