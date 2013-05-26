namespace SquarePeg.ServiceHost
{
    using System;

    using PostSharp.Extensibility;


    /// <summary>
    /// Global application class.
    /// </summary>
 
    public class Global : System.Web.HttpApplication
    {
        /// <summary>
        /// Handles the Start event of the Application control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void Application_Start(object sender, EventArgs e)
        {
          
            new AppHost().Init();
        }
    }
}