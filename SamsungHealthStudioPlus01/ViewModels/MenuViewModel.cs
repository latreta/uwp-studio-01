using Prism.Windows.Mvvm;
using Prism.Windows.Navigation;
using SamsungHealthStudioPlus01.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamsungHealthStudioPlus01.ViewModels
{
    public class MenuViewModel : ViewModelBase
    {
        private readonly INavigationService navigationService;

        public MenuViewModel(INavigationService navigationService)
        {
            this.navigationService = navigationService;
        }
        public void NavigateHome()
        {
            navigationService.Navigate(PageTokens.DASHBOARD, null);
        }

        public void NavigateFoodCalendar()
        {
            navigationService.Navigate(PageTokens.FOODCALENDAR, null);
        }

    }
}
