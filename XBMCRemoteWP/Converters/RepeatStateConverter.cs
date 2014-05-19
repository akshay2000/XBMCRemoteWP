using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace XBMCRemoteWP.Converters
{
    public class RepeatStateConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string repeat = value == null ? "off" : (string)value;
            ImageBrush repeatAllBrush = new ImageBrush { ImageSource = new BitmapImage(new Uri("/Assets/Glyphs/transport.repeat.png", UriKind.Relative)), Stretch = Stretch.Uniform };
            ImageBrush repeatOneBrush = new ImageBrush { ImageSource = new BitmapImage(new Uri("/Assets/Glyphs/transport.repeatone.png", UriKind.Relative)), Stretch = Stretch.Uniform };
            ImageBrush repeatOffBrush = new ImageBrush { ImageSource = new BitmapImage(new Uri("/Assets/Glyphs/transport.repeat.png", UriKind.Relative)), Stretch = Stretch.Uniform, Opacity = 0.5 };
            switch (repeat)
            {
                case "all":
                    return repeatAllBrush;
                case "one":
                    return repeatOneBrush;
                case "off":
                default:
                    return repeatOffBrush;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
