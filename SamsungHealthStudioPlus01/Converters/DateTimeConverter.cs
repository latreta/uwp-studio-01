using System;
using Windows.UI.Xaml.Data;

namespace SamsungHealthStudioPlus01.Converters
{
    public class DateTimeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return string.Format((string)parameter, (DateTime)value);
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            if (DateTime.TryParse((string)value, out DateTime result))
            {
                return result;
            }
            return DateTime.Now;
        }
    }
}
