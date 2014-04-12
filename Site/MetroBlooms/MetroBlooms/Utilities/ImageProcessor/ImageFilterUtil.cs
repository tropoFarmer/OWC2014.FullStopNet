using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Web;

namespace MetroBlooms.Utilities.ImageProcessor
{
    public static class ImageFilterUtil
    {
        public static Image Crop(this Image imgPhoto, int Width,
                        int Height, AnchorPosition Anchor)
        {
            int sourceWidth = imgPhoto.Width;
            int sourceHeight = imgPhoto.Height;

            Width = Width == 0 ? sourceWidth : Width;
            Height = Height == 0 ? sourceHeight : Height;

            int sourceX = 0;
            int sourceY = 0;
            int destX = 0;
            int destY = 0;

            float nPercent = 0;
            float nPercentW = 0;
            float nPercentH = 0;

            nPercentW = ((float)Width / (float)sourceWidth);
            nPercentH = ((float)Height / (float)sourceHeight);

            if (nPercentH < nPercentW)
            {
                nPercent = nPercentW;
                switch (Anchor)
                {
                    case AnchorPosition.Top: destY = 0; break;
                    case AnchorPosition.Bottom: destY = (int)(Height - (sourceHeight * nPercent)); break;
                    default: destY = (int)((Height - (sourceHeight * nPercent)) / 2); break;
                }
            }
            else
            {
                nPercent = nPercentH;
                switch (Anchor)
                {
                    case AnchorPosition.Left: destX = 0; break;
                    case AnchorPosition.Right: destX = (int)(Width - (sourceWidth * nPercent)); break;
                    default: destX = (int)((Width - (sourceWidth * nPercent)) / 2); break;
                }
            }

            int destWidth = (int)(sourceWidth * nPercent);
            int destHeight = (int)(sourceHeight * nPercent);

            Bitmap bmPhoto = new Bitmap(Width, Height, PixelFormat.Format24bppRgb);
            bmPhoto.SetResolution(imgPhoto.HorizontalResolution, imgPhoto.VerticalResolution);

            using (Graphics g = Graphics.FromImage(bmPhoto))
            {
                g.CompositingQuality = CompositingQuality.HighQuality;
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.SmoothingMode = SmoothingMode.AntiAlias;

                g.DrawImage(imgPhoto,
                    new Rectangle(destX, destY, destWidth, destHeight),
                    new Rectangle(sourceX, sourceY, sourceWidth, sourceHeight),
                    GraphicsUnit.Pixel);

                return bmPhoto;
            }
        }

        public enum AnchorPosition : int
        {
            Top = 1,
            Bottom = 2,
            Left = 3,
            Right = 4,
            Center = 5
        }
    }
}