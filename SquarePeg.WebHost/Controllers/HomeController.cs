using System;

namespace SquarePeg.WebHost.Controllers
{
    using System.Web.Mvc;
    using ServiceStack.Mvc;

    /// <summary>
    /// Controller for the default routes.
    /// </summary>
    public class HomeController : ServiceStackController
    {
        /// <summary>
        /// Default view.
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Throws an exception.
        /// </summary>
        /// <returns></returns>
        public ActionResult ThrowException()
        {
            throw new Exception("Oops.");
        }
    }
}
