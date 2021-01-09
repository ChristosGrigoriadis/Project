using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using UberTappDeveloping.Controllers;
using UberTappDeveloping.Models;

namespace UberTappDeveloping.ViewModels
{
    public class BeerFormViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public int? EBC { get; set; } // European Brewery Convention -Colour-
        public double? ABV { get; set; } // Alcohol By Volume 3% - 13% for beers
        public int? IBU { get; set; } // International Bitterness Units
        public string Description { get; set; }

        public string Heading { get; set; }

        public string Action
        {
            get
            {
                Expression<Func<BeerController, ActionResult>> update = (c => c.Update(this));
                Expression<Func<BeerController, ActionResult>> create = (c => c.Create(this));

                var action = (Id != 0) ? update : create;
                var actionName = (action.Body as MethodCallExpression).Method.Name;

                return actionName;
            }
        }

    }
}