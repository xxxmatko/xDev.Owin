using Owin;

namespace xDev.Owin.ImageWatermarkMiddlewareDemo
{
    /// <summary>
    /// OWIN Startup class for the development environment.
    /// </summary>
    public partial class Startup
    {
        #region [ Methods : Public ]

        /// <summary>
        /// Configures application.
        /// </summary>
        /// <param name="app">Object representing application.</param>
        public void Configuration(IAppBuilder app)
        {
            app.UseImageWatermark();
        }

        #endregion
    }
}
