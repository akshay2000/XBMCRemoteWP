﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using XBMCRemoteWP.Helpers;

namespace XBMCRemoteWP.Converters
{
    public class ImagePathConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string imagePath = (value == null) ? string.Empty : (string)value;
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
                imageURL = "/Assets/DefaultArt.jpg";
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