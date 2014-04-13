using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MetroBlooms.Extensions;
using System.Drawing;
using System.Drawing.Imaging;

namespace MetroBlooms.Utilities.ImageProcessor
{
    public class ImageResult : ActionResult
    {
        public string FileName { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public ImageFilterUtil.AnchorPosition Anchor { get; set; }

        public ImageResult(string fileName, int width, int height, string anchor)
        {
            this.FileName = fileName;
            this.Width = width;
            this.Height = height;
            this.Anchor = this.AnchorFromString(anchor);
        }

        public override void ExecuteResult(ControllerContext controllerContext)
        {
            var context = controllerContext.HttpContext;
            var res = context.Response;
            res.Clear();

            var relativeCachedFile = string.Format("cached\\{0}{1}{2}.png", this.Width, this.Height, this.Anchor);

            if (this.FileName.IsSet())
            {
                
                var filePath = context.Server.MapPath(this.FileName);
                var fileInfo = new FileInfo(filePath);
                var directory = fileInfo.DirectoryName;

                var cachedFile = Path.Combine(directory, relativeCachedFile);

                if (File.Exists(cachedFile))
                {
                    this.WriteImageToResponse(context, cachedFile);
                }
                else
                {
                    using (var stream = File.OpenRead(filePath))
                    {

                        if (stream != null)
                        {
                            using (var image = Image.FromStream(stream))
                            {
                                var newImage = image;
                                newImage = ImageFilterUtil.Crop(newImage, this.Width, this.Height, this.Anchor);

                                using (var ms = new MemoryStream())
                                {
                                    if (!Directory.Exists(directory + "\\cached"))
                                    {
                                        Directory.CreateDirectory(directory + "\\cached");
                                    }

                                    newImage.Save(cachedFile, ImageFormat.Png);
                                    WriteImageToResponse(context, cachedFile);
                                }

                                newImage.Dispose();
                            }
                        }
                    }
                }
            }

        }

        private void WriteImageToResponse(HttpContextBase context, string imageFilePath)
        {
            DateTime contentModified = System.IO.File.GetLastWriteTime(imageFilePath);

            if (!String.IsNullOrEmpty(context.Request.Headers["If-Modified-Since"]))
            {
                System.Globalization.CultureInfo provider = System.Globalization.CultureInfo.InvariantCulture;
                var lastMod = System.DateTime.ParseExact(context.Request.Headers["If-Modified-Since"], "r", provider).ToLocalTime();
                var modifyDiff = contentModified - lastMod;
                if (modifyDiff < TimeSpan.FromSeconds(1))
                {
                    context.Response.StatusCode = (int)System.Net.HttpStatusCode.NotModified;
                    context.Response.StatusDescription = "Not Modified";
                    context.Response.AddHeader("Content-Length", "0");
                    return;
                }
            }
            context.Response.Cache.SetAllowResponseInBrowserHistory(true);
            context.Response.Cache.SetCacheability(HttpCacheability.ServerAndPrivate);
            if (contentModified <= DateTime.Now)
                context.Response.Cache.SetLastModified(contentModified);

            context.Response.ContentType = "image/png";
            context.Response.WriteFile(imageFilePath);
        }

        private ImageFilterUtil.AnchorPosition AnchorFromString(string anchorText)
        {
            switch (anchorText.ToLower())
            {
                case "left": return ImageFilterUtil.AnchorPosition.Left;
                case "right": return ImageFilterUtil.AnchorPosition.Right;
                case "top": return ImageFilterUtil.AnchorPosition.Top;
                case "bottom": return ImageFilterUtil.AnchorPosition.Bottom;
                default: return ImageFilterUtil.AnchorPosition.Center;
            }
        }


    }
}