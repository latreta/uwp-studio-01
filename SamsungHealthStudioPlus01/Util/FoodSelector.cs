using SamsungHealthStudioPlus01.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace SamsungHealthStudioPlus01.Util
{
    public class FoodSelector: DataTemplateSelector
    {
        protected override DataTemplate SelectTemplateCore(object item, DependencyObject container)
        {
            FrameworkElement element = container as FrameworkElement;
            if (item is Food)
            {
                var food = item as Food;
                if(food.Image != null)
                {
                    return element.FindName("FoodTemplate") as DataTemplate;
                }
                return element.FindName("AddImageTemplate") as DataTemplate;
            }
            return null;
        }
    }
}
