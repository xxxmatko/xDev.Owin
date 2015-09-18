using System.Drawing;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using System.Web.Hosting;

using Microsoft.Owin;

using ImageProcessor;
using ImageProcessor.Imaging;
using ImageProcessor.Imaging.Formats;

namespace xDev.Owin
{
    /// <summary>
    /// OWIN middleware which applies watermark to all requested images.
    /// </summary>
    public class ImageWatermarkMiddleware : OwinMiddleware
    {
        #region [ Fields ]

        private readonly ImageWatermarkMiddlewareOptions _options;

        #endregion


        #region [ Constructors ]

        /// <summary>
        /// Instantiates the middleware.
        /// </summary>
        /// <param name="next">Pointer to the next component.</param>
        /// <param name="options">Options for the middleware.</param>
        public ImageWatermarkMiddleware(OwinMiddleware next, ImageWatermarkMiddlewareOptions options) 
            : base(next)
        {
            this._options = options;
        }

        #endregion


        #region [ Methods : Public ]

        /// <summary>
        /// Process an individual request.
        /// </summary>
        /// <param name="context">OWIN context.</param>
        /// <returns>Returns next middleware.</returns>
        public async override Task Invoke(IOwinContext context)
        {
            string imageFilePath = HostingEnvironment.MapPath("~" + context.Request.Path.Value);

            // Check for the correct folder and image existance
            if (!context.Request.Path.StartsWithSegments(this._options.Folder) 
                || string.IsNullOrEmpty(imageFilePath) 
                || !File.Exists(imageFilePath))
            {
                await this.Next.Invoke(context);
                return;
            }

            // Check for the watermark image existance
            string watermarkFilePath = HostingEnvironment.MapPath("~" + this._options.Watermark.Value);
            if (string.IsNullOrEmpty(watermarkFilePath) || !File.Exists(watermarkFilePath))
            {
                throw new FileNotFoundException("Watermark image was not found.", this._options.Watermark.Value);
            }
            
            // Read a file and resize it.
            using (var imageStream = new MemoryStream(File.ReadAllBytes(imageFilePath)))
            {
                using (var waterMarkImage = Image.FromFile(watermarkFilePath))
                {
                    using (var outStream = new MemoryStream())
                    {
                        using (var factory = new ImageFactory())
                        {
                            // Load, resize, set the format and quality and save an image.
                            factory.Load(imageStream)
                                //.Resize(new Size(150, 0))
                                .Format(new JpegFormat())
                                .Quality(100)
                                .Overlay(new ImageLayer()
                                         {
                                             Image = waterMarkImage,
                                             Opacity = this._options.Opacity
                                         })
                                .Save(outStream);
                        }
                        context.Response.Write(outStream.ToArray());
                    }
                }
            }
            
            context.Response.StatusCode = (int)HttpStatusCode.OK;
            context.Response.ContentType = "image/jpg";
        }

        #endregion
    }
}
