using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace XBMCRemoteWP.Converters
{
    public class ListToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            List<string> inputList = (List<String>)value;
            string toReturn = string.Empty;
            foreach(string s in inputList)
            {
                toReturn = toReturn + s + ", ";
            }
            char[] trim = {',', ' '};
            toReturn = toReturn.TrimEnd(trim);
            return toReturn;
            //throw new NotImplementedException();
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
