using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Atsumeru.Models;
using Atsumeru.Models.Administration;
using Atsumeru.Models.Figures;

namespace Atsumeru.Controllers
{
    public class AdministrationController : Controller
    {
        //
        // GET: /Administration/

        public ActionResult Index()
        {
            var session = DataDocumentStore.Initialize().OpenSession();

            var hepplo = session.Query<CollectionType>().ToList();
            var apa = session.Query<Beast>().ToList();

            var m = new AdministrationModel
                {
                    CollectionTypes = hepplo,
                    CollectionItems = apa
                };

            return View("Index", m);
        }

    }
}
