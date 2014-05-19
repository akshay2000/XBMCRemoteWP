﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace XBMCRemoteWP.Converters
{
    public class SpeedToImgSrcConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            int speed = value == null ? 1 : (int)value;
            Uri playButtonUri = new Uri("/Assets/Glyphs/appbar.transport.play.rest.png", UriKind.Relative);
            Uri pauseButtonUri = new Uri("/Assets/Glyphs/appbar.transport.pause.rest.png", UriKind.Relative);

            return speed == 1 ? pauseButtonUri : playButtonUri;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
