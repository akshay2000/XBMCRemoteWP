using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace XBMCRemoteWP.Converters
{
    public class ImagePathConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string imagePath = (string)value;
            string imageURL = string.Empty;
            if (imagePath.Length > 8)
            {
                string uri = imagePath.Substring(8);
                var encodedUri = HttpUtility.UrlEncode(uri);
                imageURL = "http://192.168.1.3:8080/image/image://" + encodedUri;
            }
            else
            {
                imageURL = "/Assets/DesignTime/AlbumArt.jpg";
            }
            Uri imageURI = new Uri(imageURL, UriKind.RelativeOrAbsolute);
            return imageURI;
        }
        

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}