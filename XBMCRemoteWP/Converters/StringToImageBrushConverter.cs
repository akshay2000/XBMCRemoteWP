using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using XBMCRemoteWP.Helpers;

namespace XBMCRemoteWP.Converters
{
    public class StringToImageBrushConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string imagePath = (string)value;
            string imageURL = string.Empty;
            if (imagePath.Length > 8)
            {
                string uri = imagePath.Substring(8);
                if (uri.StartsWith("http"))
                {
                    imageURL = HttpUtility.UrlDecode(uri).TrimEnd('/');
                }
                else
                {
                    var encodedUri = HttpUtility.UrlEncode(uri);
                    string baseUrlString = "http://" + ConnectionManager.CurrentConnection.IpAddress + ":" + ConnectionManager.CurrentConnection.Port.ToString() + "/image/image://";
                    imageURL = baseUrlString + encodedUri;
                }
            }
            else
            {
                imageURL = "/Assets/DesignTime/AlbumArt.jpg";
            }

            ImageBrush imageBrush = new ImageBrush();
            imageBrush.Stretch = Stretch.UniformToFill;
            imageBrush.Opacity = 0.6;
            imageBrush.ImageSource = new BitmapImage(new Uri(imageURL, UriKind.RelativeOrAbsolute));
            return imageBrush;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
