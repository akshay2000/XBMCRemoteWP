using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using XBMCRemoteWP.Models.Video;

namespace XBMCRemoteWP.Converters
{
    public class ListTrimmer : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            int resultCount = 6;
            List<Cast> castList = (value == null) ? new List<Cast>() : (List<Cast>)value;
            if (castList.Count > resultCount)
            {
                int countToRemove = castList.Count - resultCount;
                castList.RemoveRange(resultCount, countToRemove);
            }
            return castList;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
