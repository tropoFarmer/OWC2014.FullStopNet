using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using umbraco.cms.businesslogic.media;
using umbraco.NodeFactory;
using umbraco;
using FullStopNet.Web.Extensions;
using System.Text;

namespace FullStopNet.Web.Utilities
{
    public class UmbracoImage
    {
        public string Url { get; set; }
        public string Alt { get; set; }
        public string Id { get; set; }

        /* ----------- Sizes --------------*/
        public string Base { get; set; }
        public string Small { get; set; }
        public string Medium { get; set; }
        public string Large { get; set; }
        public string Huge { get; set; }

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

                this.Url = this._desktop.GetImageUrl();

                this.Base = this._mobile != null ? this._mobile.GetImageUrl() : this.Url;
                this.Small = this._mobile != null ? this._mobile.GetImageUrl() : this.Url;
                this.Medium = this._tablet != null ? this._tablet.GetImageUrl() : this.Url;
                this.Large = this._desktop != null ? this._desktop.GetImageUrl() : this.Url;
                this.Huge = this._desktop != null ? this._desktop.GetImageUrl() : this.Url;
            }
        }

        /// <summary>
        /// Renders Adaptive Image attributes to a string to be used in markup.
        /// Any provided sizes are parsed by comma delimited width height (ex. 100,40)
        /// is 100 pixels wide and 40 tall. 
        /// </summary>
        /// <param name="all">Ensure all sizes inherit this size</param>
        /// <param name="baseUrl">Size contraints for base size</param>
        /// <param name="small">Size contraints for small size</param>
        /// <param name="medium">Size contraints for medium size</param>
        /// <param name="large">Size contraints for large size</param>
        /// <param name="huge">Size contraints for huge size</param>
        /// <returns></returns>
        private string RenderAdaptiveAttributes(string all = "", string baseSize = "", string small = "", string medium = "", string large = "", string huge = "")
        {
            var imageAttributes = new StringBuilder();

            imageAttributes.Append("data-controller=\"controllers/AdaptiveImage\"");
            imageAttributes.AppendFormat("data-src-base=\"{0}\" ", this.FetchSizePath(this.Base, baseSize, all));
            imageAttributes.AppendFormat("data-src-small=\"{0}\" ", this.FetchSizePath(this.Small, small, all));
            imageAttributes.AppendFormat("data-src-medium=\"{0}\" ", this.FetchSizePath(this.Medium, medium, all));
            imageAttributes.AppendFormat("data-src-large=\"{0}\" ", this.FetchSizePath(this.Large, large, all));
            imageAttributes.AppendFormat("data-src-huge=\"{0}\" ", this.FetchSizePath(this.Large, huge, all));

            return imageAttributes.ToString();
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

        private string FetchSizePath(string path, string size, string defaultSize)
        {
            return path.EnsurePostfix("/") + (size.IsSet() ? size : defaultSize).Replace(',', '/');
        }
    }
}