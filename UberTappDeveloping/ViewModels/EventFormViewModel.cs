using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using UberTappDeveloping.Controllers;
using UberTappDeveloping.DAL;
using UberTappDeveloping.Models;

namespace UberTappDeveloping.ViewModels
{
    public class EventFormViewModel
    {
        private ApplicationDbContext context = new ApplicationDbContext();

        public Event Event { get; set; }
        public IEnumerable<Venue> Venues { get; set; }

        public string ActionName
        {
            get
            {
                Expression<Func<VenueController, ActionResult>> Update = vc => vc.Update(new Venue());
                Expression<Func<VenueController, ActionResult>> New = vc => vc.New();

                var action = Event.Id == 0 ? New : Update;
                var actionName = (action.Body as MethodCallExpression).Method.Name;

                return actionName;
            }
        }

        public EventFormViewModel(string userId, Event evt)
        {
            Event = evt;
            Venues = context.Venues.Where(v => v.OwnerId == userId);
        }

        public EventFormViewModel()
        {

        }
    }
}