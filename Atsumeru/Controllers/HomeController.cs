using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Atsumeru.Models;
using Atsumeru.Models.Figures;
using Raven.Client.Document;

namespace Atsumeru.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Collection/

        public ActionResult Index()
        {
            return View("Index");
        }
    }
}