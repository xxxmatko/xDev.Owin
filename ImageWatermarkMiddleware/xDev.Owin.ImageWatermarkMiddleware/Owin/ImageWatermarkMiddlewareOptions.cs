using Microsoft.Owin;

namespace xDev.Owin
{
    /// <summary>
    /// Options for the <see cref="T:xDev.Owin.ImageWatermarkMiddleware"/> middleware.
    /// </summary>
    public class ImageWatermarkMiddlewareOptions
    {
        #region [ Fields ]

        private PathString _folder;
        private PathString _watermark;
        private int _opacity;

        #endregion


        #region [ Constructors ]

        /// <summary>
        /// Basic constructor.
        /// </summary>
        /// <param name="folder">Path for the folder containing images.</param>
        /// <param name="watermark">Path for the watermark image.</param>
        /// <param name="opacity">Watermark opacity.</param>
        public ImageWatermarkMiddlewareOptions(string folder = null, string watermark = null, int opacity = 1)
        {
            this._folder = new PathString(folder ?? "/Images");
            this._watermark = new PathString(watermark ?? "/logo.png");
            this._opacity = opacity;
        }

        #endregion


        #region [ Properties ]

        /// <summary>
        /// Gets or sets path for the folder containing images.
        /// </summary>
        public PathString Folder
        {
            get
            {
                return this._folder;
            }
            set
            {
                this._folder = value;
            }
        }


        /// <summary>
        /// Gets or sets path for the watermark image.
        /// </summary>
        public PathString Watermark
        {
            get
            {
                return this._watermark;
            }
            set
            {
                this._watermark = value;
            }
        }


        /// <summary>
        /// Gets or sets the watermark opacity.
        /// </summary>
        public int Opacity
        {
            get
            {
                return this._opacity;
            }
            set
            {
                this._opacity = value;
            }
        }

        #endregion
    }
}
