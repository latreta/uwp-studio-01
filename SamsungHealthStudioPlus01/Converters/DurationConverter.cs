using System;
using System.Text.RegularExpressions;
using Windows.UI.Xaml.Data;

namespace SamsungHealthStudioPlus01.Converters
{
    public class DurationConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            const int MINUTES_IN_HOUR = 60;
            var duration = (int)value;

            if (duration > MINUTES_IN_HOUR)
            {
                var hours = duration / MINUTES_IN_HOUR;
                var minutes = duration % MINUTES_IN_HOUR;
                return $"{hours}h {minutes}min";
            }
            else
            {
                return $"{duration}min";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            var stringValue = value.ToString();
            var regex = new Regex("^\\d+");
            stringValue = regex.Replace(stringValue, "");
            if (int.TryParse(stringValue, out int result))
            {
                return result;
            }
            return 0;
        }
    }
}
