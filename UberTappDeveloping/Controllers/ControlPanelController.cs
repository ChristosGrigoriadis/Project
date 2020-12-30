using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UberTappDeveloping.Controllers
{
    public class ControlPanelController : Controller
    {
        // GET: ControlCenter
        public ActionResult Index()
        {
            return View();
        }
    }
}