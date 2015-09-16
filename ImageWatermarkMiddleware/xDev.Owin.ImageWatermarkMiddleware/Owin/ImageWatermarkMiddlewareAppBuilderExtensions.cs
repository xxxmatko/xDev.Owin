using Owin;

namespace xDev.Owin
{
    /// <summary>
    /// Extension methods for the <see cref="T:Owin.IAppBuilder"/> interface.
    /// </summary>
    public static class ImageWatermarkMiddlewareAppBuilderExtensions
    {
        #region [ Methods : Public ]

        /// <summary>
        /// Inserts <see cref="T:xDev.Owin.ImageWatermarkMiddleware"/> middleware into the OWIN pipeline.
        /// </summary>
        /// <param name="app">AppBuilder.</param>
        /// <param name="options">Options for the middleware.</param>
        public static void UseImageWatermark(this IAppBuilder app, ImageWatermarkMiddlewareOptions options = null)
        {
            app.Use<ImageWatermarkMiddleware>(options ?? new ImageWatermarkMiddlewareOptions());
        }

        #endregion
    }
}
