using Microsoft.AspNet.Identity;
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
    public class BeerController : Controller
    {
        private ApplicationDbContext context;

        public BeerController()
        {
            context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            context.Dispose();
        }


        #region GET
        // GET: Beer
        public ActionResult Beers()
        {
            var userId = User.Identity.GetUserId();

            var viewModel = new BeersViewModel()
            {
                AllBeers = context.Beers.ToList(),
                FavBeers = context.FavBeer.Where(fb => fb.UserThatFollows == userId).ToLookup(b => b.BeerToBeFollowed)
            };

            return View(viewModel);
        }

        public ActionResult Edit(int id)
        {
            var beer = context.Beers.SingleOrDefault(b => b.Id == id);
            var viewModel = new BeerFormViewModel
            {
                Heading = "Update beer information.",
                Id = beer.Id,
                Name = beer.Name,
                ABV = beer.ABV,
                IBU = beer.IBU,
                Description = beer.Description
            };


            if (viewModel == null)
                return HttpNotFound();

            return View("BeerForm", viewModel);
        }

        public ActionResult Create()
        {

            var viewModel = new BeerFormViewModel()
            {
                Heading = "Add a new beer."
            };

            return View("BeerForm", viewModel);
        }

        public ActionResult Details(int id)
        {
            var beer = context.Beers.SingleOrDefault(b => b.Id == id);
            return View(beer);
        }

        #endregion


        #region POST

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BeerFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return View("BeerForm", viewModel);

            var beer = new Beer
            {
                Name = viewModel.Name,
                ABV = viewModel.ABV,
                Description = viewModel.Description,
                EBC = viewModel.EBC,
                IBU = viewModel.IBU
            };

            context.Beers.Add(beer);
            context.SaveChanges();

            return RedirectToAction("Beers", "Beer");
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Update(BeerFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return View("BeerForm", viewModel);

            var beerToBeUpdated = context.Beers.SingleOrDefault(b => b.Id == viewModel.Id);
            beerToBeUpdated.Name = viewModel.Name;
            beerToBeUpdated.ABV = viewModel.ABV;
            beerToBeUpdated.IBU = viewModel.IBU;
            beerToBeUpdated.EBC = viewModel.EBC;
            beerToBeUpdated.Description = viewModel.Description;

            context.SaveChanges();

            return RedirectToAction("Beers", "Beer");
        }

        public ActionResult Delete(int id)
        {
            var beer = context.Beers.SingleOrDefault(b => b.Id == id);

            if (beer == null)
                return HttpNotFound();
            else
            {
                context.Beers.Remove(beer);
                context.SaveChanges();
                return RedirectToAction("Beers", "Beer");
            }
        }


        #endregion


    }
}