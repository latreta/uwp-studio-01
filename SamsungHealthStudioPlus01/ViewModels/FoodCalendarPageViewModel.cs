using Prism.Events;
using Prism.Windows.Mvvm;
using Prism.Windows.Navigation;
using SamsungHealthStudioPlus01.Events;
using SamsungHealthStudioPlus01.Models;
using SamsungHealthStudioPlus01.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.DataTransfer;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace SamsungHealthStudioPlus01.ViewModels
{
    public class FoodCalendarPageViewModel : ViewModelBase
    {
        private readonly IFoodService foodService;
        private readonly IEventAggregator eventAggregator;

        public ObservableCollection<Food> Foods { get; } = new ObservableCollection<Food>();

        private DateTime dateUpdate = default(DateTime);
        public DateTime DateUpdate
        {
            get { return dateUpdate; }
            set { 
                SetProperty(ref dateUpdate, value);
                FormattedDate = $"{DateUpdate:MMMM} {DateUpdate.Day}, {DateUpdate.Year}";
                DayOfWeek = DateUpdate.DayOfWeek.ToString().ToUpper();
            }
        }

        private string _formattedDate = default(string);
        public string FormattedDate
        {
            get { return _formattedDate; }
            set { SetProperty(ref _formattedDate, value); }
        }

        private string dayOfWeek = default(string);
        public string DayOfWeek
        {
            get { return dayOfWeek; }
            set { SetProperty(ref dayOfWeek, value); }
        }

        public FoodCalendarPageViewModel(IFoodService foodService, IEventAggregator eventAggregator)
        {
            this.foodService = foodService;
            this.eventAggregator = eventAggregator;
            DateUpdate = DateTime.Now;
            GetFoods();
        }

        public override void OnNavigatedTo(NavigatedToEventArgs e, Dictionary<string, object> viewModelState)
        {
            base.OnNavigatedTo(e, viewModelState);
            eventAggregator.GetEvent<FoodDeletedEvent>().Subscribe(Deletar);
        }

        public override void OnNavigatingFrom(NavigatingFromEventArgs e, Dictionary<string, object> viewModelState, bool suspending)
        {
            base.OnNavigatingFrom(e, viewModelState, suspending);
            eventAggregator.GetEvent<FoodDeletedEvent>().Unsubscribe(Deletar);
        }

        private void Deletar(Food f)
        {
            foodService.RemoveFood(f.Id);
            GetFoods();
        }

        public void GetFoods()
        {
            Foods.Clear();
            foodService.GetFoods().Where(p => p.Date.Date.Equals(DateUpdate.Date)).ToList().ForEach(a => Foods.Add(a));
        }

        public void NextFood()
        {
            DateUpdate = DateUpdate.AddDays(1);
            GetFoods();
        }

        public void PriorFood()
        {
            DateUpdate = DateUpdate.AddDays(-1);
            GetFoods();
        }
                
        public async void OnOpenFile()
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
                foodService.AddFood(newFile, DateUpdate);
                GetFoods();
            }
        }

    }
}
