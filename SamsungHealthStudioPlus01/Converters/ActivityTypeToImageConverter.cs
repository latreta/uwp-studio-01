using SamsungHealthStudioPlus01.Models;
using System;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media.Imaging;

namespace SamsungHealthStudioPlus01.Converters
{
    public class ActivityTypeToImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return new BitmapImage(new Uri($"ms-appx:///Assets/Images/shealth_ic_activity_{((ActivityType)value).ToString().ToLower()}.png"));
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return ((BitmapImage) value).UriSource.AbsolutePath;
        }
    }
}
