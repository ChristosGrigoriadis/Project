using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using UberTappDeveloping.DAL;
using UberTappDeveloping.Models;
using UberTappDeveloping.Models.ModelDTOs;

namespace UberTappDeveloping.Controllers.API
{
    public class UserBeersController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public UserBeersController()
        {
            db = new ApplicationDbContext();
        }

         //api/userbeers
        public IHttpActionResult Follow(UserBeerDto userBeerDto)
        {
            var userId = User.Identity.GetUserId();
            var exists = db.UserBeers.Any(ub => ub.BeerEnthusiastId == userId && ub.FavouriteBeerId == userBeerDto.BeerId);
            if (exists)
                return BadRequest("This already is your favourite Beer.");

            var favoring = new UserBeer
            {
                FavouriteBeerId = userBeerDto.BeerId,
                BeerEnthusiastId = userId
            };

            db.UserBeers.Add(favoring);
            db.SaveChanges();

            return Ok();
        }
    }
}
