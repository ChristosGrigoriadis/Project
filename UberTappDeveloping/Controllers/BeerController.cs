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
            var beers = context.Beers.ToList();

            return View(beers);
        }

        public ActionResult Edit(int id)
        {
            var viewModel = new BeerViewModel(context.Beers.SingleOrDefault(b => b.Id == id));

            if (viewModel == null)
                return HttpNotFound();

            return View("BeerForm", viewModel);
        }

        public ActionResult Create()
        {
            var viewModel = new BeerViewModel();

            return View("BeerForm", viewModel);
        }

        public ActionResult Details(int id)
        {
            var beer = context.Beers.SingleOrDefault(b => b.Id == id);
            return View(beer);
        }

        #endregion


        #region POST

        public ActionResult Save(Beer beer)
        {
            if (beer.Id == 0)
                context.Beers.Add(beer);
            else
            {
                var beerToBeUpdated = context.Beers.SingleOrDefault(b => b.Id == beer.Id);
                beerToBeUpdated.Name = beer.Name;
                beerToBeUpdated.ABV = beer.ABV;
                beerToBeUpdated.IBU = beer.IBU;
                beerToBeUpdated.EBC = beer.EBC;
                beerToBeUpdated.Description = beer.Description;
            }

            context.SaveChanges();

            return RedirectToAction("Beers","Beer");
        }


        #endregion


    }
}