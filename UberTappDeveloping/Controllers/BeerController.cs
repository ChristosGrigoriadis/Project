using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UberTappDeveloping.DAL;
using UberTappDeveloping.Helper.Roles;
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

        public ActionResult FilterBeers(int id)
        {
            if (id == 0)
            {
                return View("ErrorPage", "Home");
            }


            if (id == 1)
            {
                var beers = context.Beers.Where(b => b.EBC <= 4).ToList();
                var userId = User.Identity.GetUserId();

                var viewModel = new BeersViewModel()
                {
                    AllBeers = beers,
                    FavBeers = context.FavBeer.Where(fb => fb.UserThatFollows == userId).ToLookup(b => b.BeerToBeFollowed)
                };
                return View("FilterBeers", viewModel);
            }
            else if (id == 2)
            {
                var beers = context.Beers.Where(b => b.EBC > 4 && b.EBC <= 6).ToList();
                var userId = User.Identity.GetUserId();

                var viewModel = new BeersViewModel()
                {
                    AllBeers = beers,
                    FavBeers = context.FavBeer.Where(fb => fb.UserThatFollows == userId).ToLookup(b => b.BeerToBeFollowed)
                };
                return View("FilterBeers", viewModel);
            }
            else if (id == 3)
            {
                var beers = context.Beers.Where(b => b.EBC > 6 && b.EBC <= 8).ToList();
                var userId = User.Identity.GetUserId();

                var viewModel = new BeersViewModel()
                {
                    AllBeers = beers,
                    FavBeers = context.FavBeer.Where(fb => fb.UserThatFollows == userId).ToLookup(b => b.BeerToBeFollowed)
                };
                return View("FilterBeers", viewModel);
            }
            else if (id == 4)
            {
                var beers = context.Beers.Where(b => b.EBC > 8 && b.EBC <= 12).ToList();
                var userId = User.Identity.GetUserId();

                var viewModel = new BeersViewModel()
                {
                    AllBeers = beers,
                    FavBeers = context.FavBeer.Where(fb => fb.UserThatFollows == userId).ToLookup(b => b.BeerToBeFollowed)
                };
                return View("FilterBeers", viewModel);
            }
            else if (id == 5)
            {
                var beers = context.Beers.Where(b => b.EBC > 12 && b.EBC <= 16).ToList();
                var userId = User.Identity.GetUserId();

                var viewModel = new BeersViewModel()
                {
                    AllBeers = beers,
                    FavBeers = context.FavBeer.Where(fb => fb.UserThatFollows == userId).ToLookup(b => b.BeerToBeFollowed)
                };
                return View("FilterBeers", viewModel);
            }
            else if (id == 6)
            {
                var beers = context.Beers.Where(b => b.EBC > 16 && b.EBC <= 20).ToList();
                var userId = User.Identity.GetUserId();

                var viewModel = new BeersViewModel()
                {
                    AllBeers = beers,
                    FavBeers = context.FavBeer.Where(fb => fb.UserThatFollows == userId).ToLookup(b => b.BeerToBeFollowed)
                };
                return View("FilterBeers", viewModel);
            }
            else if (id == 7)
            {
                var beers = context.Beers.Where(b => b.EBC > 20 && b.EBC <= 26).ToList();
                var userId = User.Identity.GetUserId();

                var viewModel = new BeersViewModel()
                {
                    AllBeers = beers,
                    FavBeers = context.FavBeer.Where(fb => fb.UserThatFollows == userId).ToLookup(b => b.BeerToBeFollowed)
                };
                return View("FilterBeers", viewModel);
            }
            else if (id == 8)
            {
                var beers = context.Beers.Where(b => b.EBC > 26 && b.EBC <= 33).ToList();
                var userId = User.Identity.GetUserId();

                var viewModel = new BeersViewModel()
                {
                    AllBeers = beers,
                    FavBeers = context.FavBeer.Where(fb => fb.UserThatFollows == userId).ToLookup(b => b.BeerToBeFollowed)
                };
                return View("FilterBeers", viewModel);
            }
            else if (id == 9)
            {
                var beers = context.Beers.Where(b => b.EBC > 33 && b.EBC <= 39).ToList();
                var userId = User.Identity.GetUserId();

                var viewModel = new BeersViewModel()
                {
                    AllBeers = beers,
                    FavBeers = context.FavBeer.Where(fb => fb.UserThatFollows == userId).ToLookup(b => b.BeerToBeFollowed)
                };
                return View("FilterBeers", viewModel);
            }
            else if (id == 10)
            {
                var beers = context.Beers.Where(b => b.EBC > 39 && b.EBC <= 47).ToList();
                var userId = User.Identity.GetUserId();

                var viewModel = new BeersViewModel()
                {
                    AllBeers = beers,
                    FavBeers = context.FavBeer.Where(fb => fb.UserThatFollows == userId).ToLookup(b => b.BeerToBeFollowed)
                };
                return View("FilterBeers", viewModel);
            }
            else if (id == 11)
            {
                var beers = context.Beers.Where(b => b.EBC > 47 && b.EBC <= 57).ToList();
                var userId = User.Identity.GetUserId();

                var viewModel = new BeersViewModel()
                {
                    AllBeers = beers,
                    FavBeers = context.FavBeer.Where(fb => fb.UserThatFollows == userId).ToLookup(b => b.BeerToBeFollowed)
                };
                return View("FilterBeers", viewModel);
            }
            else if (id == 12)
            {
                var beers = context.Beers.Where(b => b.EBC > 57 && b.EBC <= 69).ToList();
                var userId = User.Identity.GetUserId();

                var viewModel = new BeersViewModel()
                {
                    AllBeers = beers,
                    FavBeers = context.FavBeer.Where(fb => fb.UserThatFollows == userId).ToLookup(b => b.BeerToBeFollowed)
                };
                return View("FilterBeers", viewModel);
            }
            else if (id == 13)
            {
                var beers = context.Beers.Where(b => b.EBC > 69).ToList();
                var userId = User.Identity.GetUserId();

                var viewModel = new BeersViewModel()
                {
                    AllBeers = beers,
                    FavBeers = context.FavBeer.Where(fb => fb.UserThatFollows == userId).ToLookup(b => b.BeerToBeFollowed)
                };
                return View("FilterBeers", viewModel);
            }
            else
            {
                var beers = context.Beers.Where(b => b.EBC > 0).ToList();
                var userId = User.Identity.GetUserId();

                var viewModel = new BeersViewModel()
                {
                    AllBeers = beers,
                    FavBeers = context.FavBeer.Where(fb => fb.UserThatFollows == userId).ToLookup(b => b.BeerToBeFollowed)
                };
                return View("FilterBeers", viewModel);
            }
        }

        [Authorize(Roles = RoleNames.Admin)]
        public ActionResult Edit(int id)
        {
            var beer = context.Beers.SingleOrDefault(b => b.Id == id);
            var viewModel = new BeerFormViewModel
            {
                Heading = "Update beer information.",
                Id = beer.Id,
                Name = beer.Name,
                EBC = beer.EBC,
                ABV = beer.ABV,
                IBU = beer.IBU,
                Description = beer.Description
            };

            if (viewModel == null)
                return HttpNotFound();

            return View("BeerForm", viewModel);
        }

        [Authorize(Roles = RoleNames.Admin)]
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
        [Authorize(Roles = RoleNames.Admin)]
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

        [Authorize(Roles = RoleNames.Admin)]
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

        [Authorize(Roles = RoleNames.Admin)]
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