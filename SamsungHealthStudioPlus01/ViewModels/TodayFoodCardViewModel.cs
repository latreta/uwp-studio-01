using Prism.Events;
using Prism.Windows.Mvvm;
using Prism.Windows.Navigation;
using SamsungHealthStudioPlus01.Events;
using SamsungHealthStudioPlus01.Models;
using SamsungHealthStudioPlus01.Services;
using SamsungHealthStudioPlus01.Util;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.UI.Xaml.Controls;

namespace SamsungHealthStudioPlus01.ViewModels
{
    public class TodayFoodCardViewModel : ViewModelBase
    {
        private readonly IFoodService foodService;
        private readonly INavigationService navigationService;
        private readonly IEventAggregator eventAggregator;
        private readonly IEventTokenService tokenService;

        public ObservableCollection<Food> Foods { get; } = new ObservableCollection<Food>();

        private DateTime dateUpdate = DateTime.Now;
        public DateTime DateUpdate
        {
            get { return dateUpdate; }
            set { SetProperty(ref dateUpdate, value); }
        }
        public TodayFoodCardViewModel(IFoodService foodService, INavigationService navigationService, IEventAggregator eventAggregator, IEventTokenService tokenService)
        {
            this.foodService = foodService;
            this.navigationService = navigationService;
            this.eventAggregator = eventAggregator;
            this.tokenService = tokenService;
            var foodAddEvent = eventAggregator.GetEvent<FoodAddEvent>();
            if(tokenService.GetFoodAddEventToken() == null)
            {
                SubscribeEvent(foodAddEvent, tokenService);
            }
            else
            {
                UnsubscribeEvent(foodAddEvent, tokenService);
                SubscribeEvent(foodAddEvent, tokenService);
            }

            GetFoods();
        }

        public void SubscribeEvent(FoodAddEvent evento, IEventTokenService service){
            var token = evento.Subscribe(AddImage);
            tokenService.SetFoodAddEventToken(token);
        }

        public void UnsubscribeEvent(FoodAddEvent evento, IEventTokenService service)
        {
            var token = service.GetFoodAddEventToken();
            evento.Unsubscribe(token);
        }

        public async void AddImage()
        {
           await OnOpenFile();
        }

        public void NavigateFood()
        {
            this.navigationService.Navigate(PageTokens.FOODCALENDAR, null);
        }

        public void GetFoods()
        {
            Foods.Clear();
            foodService.GetFoods().Where(p => p.Date.Date.Equals(DateUpdate.Date)).ToList().ForEach(a => Foods.Add(a));
            Foods.Add(new Food(null, DateTime.Now, foodService, eventAggregator));
        }

        public async Task OnOpenFile()
        {
            FileOpenPicker openPicker = new FileOpenPicker();
            openPicker.ViewMode = PickerViewMode.Thumbnail;
            openPicker.SuggestedStartLocation = PickerLocationId.PicturesLibrary;
            openPicker.FileTypeFilter.Add(".jpg");
            openPicker.FileTypeFilter.Add(".jpeg");
            openPicker.FileTypeFilter.Add(".png");

            StorageFile file = await openPicker.PickSingleFileAsync();
            if (file != null)
            {
                var localFolder = ApplicationData.Current.LocalFolder;
                var newFile = await file.CopyAsync(localFolder, file.Name, NameCollisionOption.GenerateUniqueName);
                foodService.AddFood(newFile, dateUpdate);
                GetFoods();
            }
        }

    }
}
