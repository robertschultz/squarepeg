using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SquarePeg.WebHost.Controllers
{
    public class ErrorController : Controller
    {
        //
        // GET: /Error/

        public ActionResult Http404()
        {
            return View();
        }

        public ActionResult Http500()
        {
            return this.View();
        }

    }
}
