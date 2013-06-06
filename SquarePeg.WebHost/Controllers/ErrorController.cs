using System.Net;
using System.Web.Mvc;

namespace SquarePeg.WebHost.Controllers
{
    public class ErrorController : Controller
    {
        public ActionResult Http404()
        {
            Response.StatusCode = (int)HttpStatusCode.NotFound;
            return View();
        }

        public ActionResult Http500()
        {
            Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            return this.View();
        }

    }
}
