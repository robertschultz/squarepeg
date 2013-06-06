using System;
using Microsoft.AspNet.SignalR.Client;

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

        public ActionResult Test(string input)
        {
            // Connect to the service
            var connection = new Connection("http://squarepegio.apphb.com/echo");

            // Print the message when it comes in
            connection.Received += data => Console.WriteLine(data);

            // Start the connection
            connection.Start().Wait();

            connection.Send(input).Wait();

            return null;
        }

        public ActionResult Profile()
        {
            return View();
        }
    }
}
