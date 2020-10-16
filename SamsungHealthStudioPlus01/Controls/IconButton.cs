using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace SamsungHealthStudioPlus01.Controls
{
    public sealed class IconButton : RadioButton
    {
        public IconButton()
        {
            this.DefaultStyleKey = typeof(IconButton);
        }

        public IconElement Icon
        {
            get { return (IconElement)GetValue(IconProperty); }
            set { SetValue(IconProperty, value); }
        }

        public static readonly DependencyProperty IconProperty =
            DependencyProperty.Register("Icon", typeof(IconElement), typeof(IconButton), new PropertyMetadata(null));


        public IconElement OnHoverIcon
        {
            get { return (IconElement)GetValue(OnHoverIconProperty); }
            set { SetValue(OnHoverIconProperty, value); }
        }

        public static readonly DependencyProperty OnHoverIconProperty =
            DependencyProperty.Register("OnHoverIcon", typeof(IconElement), typeof(IconButton), new PropertyMetadata(null));
    }
}
