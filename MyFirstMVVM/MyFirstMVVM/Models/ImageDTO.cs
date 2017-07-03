using Xamarin.Forms;

namespace MyFirstMVVM.Models
{
    public class ImageDTO
    {
        public string Icon { get; set; }
        public string Medium { get; set; }
        public string Large { get; set; }
        public string SquareMedium { get; set; }
        public string SquareLarge { get; set; }
        public UriImageSource DefaultImage { get; set; }
    }
}

