using System.Web.Mvc;
using System.Web.Routing;

namespace xDev.Owin.ImageWatermarkMiddlewareDemo
{
    /// <summary>
    /// Application class.
    /// </summary>
    public class MvcApplication : System.Web.HttpApplication
    {
        #region [ Methods : Protected ]

        /// <summary>
        /// Configures application at its start.
        /// </summary>
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }

        #endregion
    }
}
