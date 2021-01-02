using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using UberTappDeveloping.DAL;
using UberTappDeveloping.Models;
using UberTappDeveloping.Models.ModelDtos;
using System.Data.Entity;
using UberTappDeveloping.Helper.Roles;

namespace UberTappDeveloping.Controllers.API
{
    [Authorize(Roles = RoleNames.VenueOwner)]
    public class VenuesController : ApiController
    {
        private ApplicationDbContext context;

        public VenuesController()
        {
            context = new ApplicationDbContext();
        }

        [HttpDelete]
        [Route("api/venues/image/{imageId}")]
        public IHttpActionResult DeleteVenueImage(int imageId)
        {
            var image = context.VenueImages.SingleOrDefault(vi => vi.Id == imageId);

            if (image == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            context.VenueImages.Remove(image);
            context.SaveChanges();


            return Ok();
        }

        [HttpPost]
        [Route("api/Venues")]
        public IHttpActionResult PostVenueBeers([FromBody] VenueBeersDto venueBeersDto)
        {

            if (venueBeersDto.VenueId == 0)
                return BadRequest("Please select a Venue");


            int venueId = venueBeersDto.VenueId;

            var beersDB = context.VenueBeers
                .Where(vb => vb.VenueId == venueId)
                .Select(vb => vb.AvailableBeerId)
                .ToList();

            if (venueBeersDto.BeersArray == null)//if posted beers are null remove all existing beers
            {
                foreach (var beerId in beersDB)
                {
                    var venueBeer = context.VenueBeers.SingleOrDefault(vb => vb.AvailableBeerId == beerId && vb.VenueId == venueId);
                    context.VenueBeers.Remove(venueBeer);
                }
                context.SaveChanges();
                return Ok();
            }



            var allBeersId = context.Beers.Select(b => b.Id).ToList();

            foreach (var beerId in allBeersId) // search all beer ids
            {
                if (venueBeersDto.BeersArray.ToList().Contains(beerId))
                {
                    if (!beersDB.Contains(beerId))
                    {
                        context.VenueBeers.Add(new VenueBeer { VenueId = venueId, AvailableBeerId = beerId, Price = venueBeersDto.PricesArray[Array.IndexOf(venueBeersDto.BeersArray, beerId)] });
                    }
                    else
                    {
                        var venueBeer = context.VenueBeers.SingleOrDefault(vb => vb.AvailableBeerId == beerId && vb.VenueId == venueId);
                        venueBeer.Price = venueBeersDto.PricesArray[Array.IndexOf(venueBeersDto.BeersArray, beerId)];
                    }

                }
                else
                {
                    if (beersDB.Contains(beerId))
                    {
                        var venueBeer = context.VenueBeers.SingleOrDefault(vb => vb.AvailableBeerId == beerId && vb.VenueId == venueId);
                        context.VenueBeers.Remove(venueBeer);
                    }
                }
            }

            context.SaveChanges();
            return Ok(venueBeersDto);
        }

        [HttpGet]
        [Route("api/Venues/{venueId}")]
        public IHttpActionResult GetVenueBeers([FromUri] int venueId)
        {
            var beerDtos = context.VenueBeers
                .Include(vb => vb.AvailableBeer)
                .Where(vb => vb.VenueId == venueId)
                .Select(vb => new BeerDto { Id = vb.AvailableBeerId, Name = vb.AvailableBeer.Name, Price = vb.Price })
                .ToList();

            return Ok(beerDtos);
        }

        [HttpGet]
        [Route("api/Venues")]
        public IHttpActionResult GetAllBeers()
        {
            var allBeersDtos = context.Beers
                .Select(b => new BeerDto { Id = b.Id, Name = b.Name })
                .ToList();

            return Ok(allBeersDtos);
        }


    }
}
