using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace MyFirstMVVM.Models
{
    public class BreweryDTO
    {
        public BreweryDTO()
        {
            Images = new ImageDTO();
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public string NameShortDisplay { get; set; }
        public string Description { get; set; }
        public string Website { get; set; }
        public int Established { get; set; }
        public string MailingListUrl { get; set; }
        public string SsOrganic { get; set; }
        public string Status { get; set; }
        public string StatusDisplay { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public string IsMassOwned { get; set; }
        public string BrandClassification { get; set; }
        public ImageDTO Images { get; set; }
    }

    public static class BreweryDTOExtensions
    {
        private static string defaultUrl = "http://6dollarshirts.com/image/cache//data/designs/6ds-replacement-thumbnails/allthisbeer-t-shirt-tn-400x400.jpg";
        public static void SetDefaultImageIfNotExists(this IEnumerable<BreweryDTO> items)
        {
            foreach (var brewery in items)
            {
                if (string.IsNullOrEmpty(brewery.Images.Medium))
                {
                    brewery.Images.Icon = defaultUrl;
                    brewery.Images.Medium = defaultUrl;
                    brewery.Images.Large = defaultUrl;
                    brewery.Images.SquareMedium = defaultUrl;
                    brewery.Images.SquareLarge = defaultUrl;
                }
                brewery.Images.DefaultImage = new UriImageSource
                {
                    Uri = new Uri(brewery.Images.Icon),
                    CachingEnabled = true,
                    CacheValidity = new TimeSpan(7, 0, 0, 0)
                };
            }
        }
    }
}
