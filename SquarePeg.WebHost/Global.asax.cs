namespace SquarePeg.WebHost
{
    using System;
    using System.Net;
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Optimization;
    using System.Web.Routing;

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            new AppHost().Init();

            AreaRegistration.RegisterAllAreas();

            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            

            var error = Server.GetLastError();
            var code = (error is HttpException) ? (error as HttpException).GetHttpCode() : 500;

            this.Response.Clear();
            this.Server.ClearError();

            this.Response.TrySkipIisCustomErrors = true; 

            if (code != 404)
            {
                this.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                this.Context.Server.TransferRequest("/Error/Http500");
            }
            else
            {
                this.Response.StatusCode = (int)HttpStatusCode.NotFound;
                this.Context.Server.TransferRequest("~/Error/Http404", true);
            }
        }
    }
}