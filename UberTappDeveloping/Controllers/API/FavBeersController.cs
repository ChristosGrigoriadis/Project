using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using UberTappDeveloping.DAL;
using UberTappDeveloping.Models;
using UberTappDeveloping.Models.ModelDtos;

namespace UberTappDeveloping.Controllers.API
{
    public class FavBeersController : ApiController
    {
        private ApplicationDbContext context;

        public FavBeersController()
        {
            context = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult AddFavourite(int id)
        {
            var userId = User.Identity.GetUserId();
            var exists = context.FavBeer.Any(f => f.UserThatFollows == userId && f.BeerToBeFollowed == id);
            if (exists)
                return BadRequest("Beer already in favourites.");

            var newFavBeer = new FavBeer
            {
                BeerToBeFollowed = id,
                UserThatFollows = userId
            };

            context.FavBeer.Add(newFavBeer);
            context.SaveChanges();

            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult RemoveFavourite(int id)
        {
            var userId = User.Identity.GetUserId();

            var favourite = context.FavBeer.SingleOrDefault(f => f.BeerToBeFollowed == id);

            if (favourite == null)
                return NotFound();

            context.FavBeer.Remove(favourite);
            context.SaveChanges();



            return Ok();
        }


    }
}
