using SamsungHealthStudioPlus01.ViewModels;
using Windows.UI.Xaml.Controls;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace SamsungHealthStudioPlus01.Views
{
    public sealed partial class ActivityCardView : UserControl
    {
        public ActivityCardViewModel ViewModel => (ActivityCardViewModel) DataContext;
        public ActivityCardView()
        {
            this.InitializeComponent();
        }
    }
}
