namespace SquarePeg.WebHost
{
    using System;
    using System.Net;
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Optimization;
    using System.Web.Routing;
    using ServiceStack.MiniProfiler;

    /// <summary>
    /// HttpApplication class that handles events.
    /// </summary>
    public class MvcApplication : System.Web.HttpApplication
    {
        /// <summary>
        /// Handles the Start event of the Application control.
        /// </summary>
        protected void Application_Start()
        {
            new AppHost().Init();

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        /// <summary>
        /// Handles the Error event of the Application control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        protected void Application_Error(object sender, EventArgs e)
        {
            var error = Server.GetLastError();
            var code = (error is HttpException) ? (error as HttpException).GetHttpCode() : 500;

            Response.Clear();
            Server.ClearError();
            Response.TrySkipIisCustomErrors = true;
            Context.Server.TransferRequest(code != 404 ? "~/Error/Http500" : "~/Error/Http404");
        }

        /// <summary>
        /// Handles the BeginRequest event of the Application control.
        /// </summary>
        /// <param name="src">The source of the event.</param>
        /// <param name="args">The <see cref="EventArgs" /> instance containing the event data.</param>
        protected void Application_BeginRequest(object src, EventArgs args)
        {
            if (Request.IsLocal)
            {
                Profiler.Start();
            }
        }

        /// <summary>
        /// Handles the EndRequest event of the Application control.
        /// </summary>
        /// <param name="src">The source of the event.</param>
        /// <param name="args">The <see cref="EventArgs" /> instance containing the event data.</param>
        protected void Application_EndRequest(object src, EventArgs args)
        {
            Profiler.Stop();
        }
    }
}