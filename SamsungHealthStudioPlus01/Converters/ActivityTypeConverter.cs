using SamsungHealthStudioPlus01.Models;
using SamsungHealthStudioPlus01.Util;
using System;
using Windows.UI.Xaml.Data;

namespace SamsungHealthStudioPlus01.Converters
{
    public class ActivityTypeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return ((ActivityType)value).GetEnumDescription();
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return Enum.Parse(typeof(ActivityType),(string)value);
        }
    }
}
