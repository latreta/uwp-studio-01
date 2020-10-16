using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Documents;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;

// The Templated Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234235

namespace SamsungHealthStudioPlus01.Controls
{
    public sealed class ButtonCard : Button
    {
        public ButtonCard()
        {
            this.DefaultStyleKey = typeof(ButtonCard);
        }
        public SymbolIcon Icon
        {
            get { return (SymbolIcon)GetValue(IconProperty); }
            set { SetValue(IconProperty, value); }
        }

        public static readonly DependencyProperty IconProperty =
            DependencyProperty.Register("Icon", typeof(SymbolIcon), typeof(ButtonCard), new PropertyMetadata(null));
    }

}
