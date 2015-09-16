using System.Web.Mvc;
using System.Web.Routing;

namespace xDev.Owin.ImageWatermarkMiddlewareDemo
{
    /// <summary>
    /// Routes configuration.
    /// </summary>
    public class RouteConfig
    {
        #region [ Methods : Public ]

        /// <summary>
        /// Configures application routes.
        /// </summary>
        /// <param name="routes">Collection of routes for ASP.NET routing.</param>
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new
                {
                    controller = "Home",
                    action = "Index",
                    id = UrlParameter.Optional
                }
            );
        }

        #endregion
    }
}

