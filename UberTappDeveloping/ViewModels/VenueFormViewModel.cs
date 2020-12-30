using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using UberTappDeveloping.Controllers;
using UberTappDeveloping.Models;

namespace UberTappDeveloping.ViewModels
{
    public class VenueFormViewModel
    {
        public Venue Venue { get; set; }

        public IEnumerable<Location> Locations { get; set; }

        public string ManagerName { get; set; }
        
        public string ActionName
        {
            get
            {
                Expression<Func<VenueController, ActionResult>> Update = vc => vc.Update(new Venue());
                Expression<Func<VenueController,ActionResult>> New = vc => vc.New();

                var action = Venue.Id == 0 ? New : Update;
                var actionName = (action.Body as MethodCallExpression).Method.Name;

                return actionName;
            }
        }
    }
}