using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

using MetroBlooms.Extensions;

using umbraco;
using umbraco.cms.businesslogic.media;
using umbraco.NodeFactory;

namespace MetroBlooms.Utilities
{
    public class UmbracoImage
    {
        public const string ImageProcessorFormat = "/umbraco/surface/content/HandleImage?file={0}&width={1}&height={2}&anchor={3}";

        public string Url { get; set; }
        public string Alt { get; set; }
        public string Id { get; set; }
        public string Anchor { get; set; }

        /* ----------- Sizes --------------*/
        private Media _desktop { get; set; }
        private Media _tablet { get; set; }
        private Media _mobile { get; set; }

        /* ---------- Constructors -----------*/
        public UmbracoImage() { }
        public UmbracoImage(string imageAlias, Node node)
        {
            if (!imageAlias.IsSet() || node == null) return;
            Bind(node.GetProperty<string>(imageAlias));
        }

        public UmbracoImage(string mediaId) { Bind(mediaId); }

        /// <summary>
        /// Main binding method that sets up the sizes and urls based
        /// on the provided media id
        /// </summary>
        /// <param name="mediaId">id of the media to read properties from</param>
        public void Bind(string mediaId)
        {
            this.Id = mediaId;

            this._desktop = UmbracoImage.GetMedia(this.Id);


            if (this._desktop != null)
            {
                this._mobile = UmbracoImage.GetMedia(_desktop.GetProperty<int>("mobileMediaItem"));
                this._tablet = UmbracoImage.GetMedia(_desktop.GetProperty<int>("tabletMediaItem"));
                this.Anchor = this.FetchCropAnchor();
                this.Url = this._desktop.GetImageUrl();
            }
        }


        /// <summary>
        /// Static wrapper for Umbraco Media items. Umbraco currently has to hit the DB
        /// 2 times to get a media object. We grab media objects to reference image urls.
        /// This caches the media object for a configured time.
        /// </summary>
        /// <param name="id">Id of media object</param>
        /// <returns>Media object</returns>
        public static Media GetMedia(string id)
        {
            var cacheKey = "UmbracoImage_Media-" + id;
            var cache = HttpContext.Current.Cache;
            var media = cache.Get(cacheKey) as Media;
            if (media == null)
            {
                media = uQuery.GetMedia(id);
                if (media == null) return null;
                cache.Insert(cacheKey, media, null, DateTime.Now.AddSeconds(Config.UmbracoImageCache), System.Web.Caching.Cache.NoSlidingExpiration);
            }
            return media;
        }

        public static Media GetMedia(int id) { return UmbracoImage.GetMedia(id.ToString()); }


        public string UrlWithConstraints(int width = 0, int height = 0)
        {
            return string.Format(ImageProcessorFormat, this.Url, width, height, this.Anchor);
        }

        private string FetchSizePath(string path, string size, string defaultSize)
        {
            return path.EnsurePostfix("/") + (size.IsSet() ? size : defaultSize).Replace(',', '/');
        }

        private string FetchCropAnchor()
        {
            var anchor = _desktop.GetProperty<string>("cropAnchor");
            if (!string.IsNullOrEmpty(anchor))
            {
                int cropSettingInt = 0;
                var success = Int32.TryParse(anchor, out cropSettingInt);
                anchor = success ? umbraco.library.GetPreValueAsString(cropSettingInt) : anchor;
            }
            return anchor;
        }
    }
}