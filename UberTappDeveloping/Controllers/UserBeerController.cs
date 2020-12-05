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
    public class UserBeerController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public UserBeerController()
        {
            db = new ApplicationDbContext();
        }

        // GET: UserBeer/Create
        public ActionResult Create()
        {
            var viewModel = new BeerViewModel
            {
                Beers = db.Beers.ToList()
            };
            return View("Create", viewModel);
        }

        // POST: UserBeer/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BeerViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.Beers = db.Beers.ToList();
                return View("Create", viewModel);
            }

            var favorite = new UserBeer
            {
                BeerEnthusiastId = User.Identity.GetUserId(),
            };

            db.UserBeers.Add(favorite);
            db.SaveChanges();

            return RedirectToAction("Index", "Home");
        }

        // GET: UserBeer
        public ActionResult Index()
        {
            return View();
        }
    }
}