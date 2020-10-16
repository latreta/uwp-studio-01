using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace SamsungHealthStudioPlus01.Controls
{
    public sealed class ImageButton : Button
    {
        public ImageButton()
        {
            this.DefaultStyleKey = typeof(ImageButton);
        }

        public Image Image
        {
            get { return (Image)GetValue(ImageProperty); }
            set { SetValue(ImageProperty, value); }
        }

        public static readonly DependencyProperty ImageProperty =
            DependencyProperty.Register("Image", typeof(Image), typeof(ImageButton), new PropertyMetadata(null));

        public Image OnHoverImage
        {
            get { return (Image)GetValue(OnHoverImageProperty); }
            set { SetValue(OnHoverImageProperty, value); }
        }

        // Using a DependencyProperty as the backing store for OnHover.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty OnHoverImageProperty =
            DependencyProperty.Register("OnHoverImage", typeof(Image), typeof(ImageButton), new PropertyMetadata(0));

        public Image OnSelectImage
        {
            get { return (Image)GetValue(OnSelectImageProperty); }
            set { SetValue(OnSelectImageProperty, value); }
        }

        // Using a DependencyProperty as the backing store for OnSelect.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty OnSelectImageProperty =
            DependencyProperty.Register("OnSelectImage", typeof(Image), typeof(ImageButton), new PropertyMetadata(0));
    }
}
