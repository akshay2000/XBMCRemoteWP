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
            string toReturn = "not available";
            if (inputList.Count > 0 && inputList[0]!="")
            {
                toReturn = string.Empty;
                int index = 0;
                foreach (string s in inputList)
                {
                    index++;
                    if (index > 5)
                    {
                        toReturn = toReturn + "etc.,";
                        break;
                    }
                    toReturn = toReturn + s + ", ";
                }
                char[] trim = { ',', ' ' };
                toReturn = toReturn.TrimEnd(trim);
            }
            return toReturn;
            //throw new NotImplementedException();
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
