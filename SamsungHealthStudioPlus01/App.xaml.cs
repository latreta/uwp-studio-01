using Prism.Unity.Windows;
using SamsungHealthStudioPlus01.Services;
using SamsungHealthStudioPlus01.Util;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace SamsungHealthStudioPlus01
{
    sealed partial class App : PrismUnityApplication
    {
        public App()
        {
            this.InitializeComponent();
        }

        protected override Task OnLaunchApplicationAsync(LaunchActivatedEventArgs args)
        {
            NavigationService.Navigate(PageTokens.DASHBOARD, null);
            return Task.CompletedTask;
        }

        protected override UIElement CreateShell(Frame rootFrame)
        {
            var shell = new AppShell();
            shell.SetFrame(rootFrame);
            return shell;
        }

        protected override void ConfigureContainer()
        {
            base.ConfigureContainer();
            RegisterTypeIfMissing(typeof(IFoodService), typeof(FoodService), true);
            RegisterTypeIfMissing(typeof(IActivityService), typeof(ActivityService), true);
            RegisterTypeIfMissing(typeof(IEventTokenService), typeof(EventTokenService), true);
        }
    }
}
