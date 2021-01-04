using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UberTappDeveloping.Models;

namespace UberTappDeveloping.ViewModels
{
    public class EventsViewModel
    {
        public IEnumerable<Event> Events { get; set; }
        public bool IsIndexAction { get; set; }


    }
}