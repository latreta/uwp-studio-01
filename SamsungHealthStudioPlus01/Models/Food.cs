using Prism.Events;
using Prism.Mvvm;
using SamsungHealthStudioPlus01.Events;
using SamsungHealthStudioPlus01.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Storage.Streams;
using Windows.UI.Xaml.Controls;

namespace SamsungHealthStudioPlus01.Models
{
    public class Food : BindableBase
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public IStorageFile Image { get; set; }
        private bool visible;

        private readonly IFoodService foodService;
        private readonly IEventAggregator eventAggregator;

        public bool Visible
        {
            get { return visible; }
            set { SetProperty(ref visible, value); }
        }

        public Food(IStorageFile image, DateTime date, IFoodService foodService, IEventAggregator eventAggregator)
        {
            this.Id = Guid.NewGuid().ToString();
            this.Image = image;
            if(image != null)
            {
                this.Name = image.Name;
            }
            this.Date = date;
            this.foodService = foodService;
            this.eventAggregator = eventAggregator;
        }

        public void onVisible() {
            Visible = true;
        }

        public void onCollapse()
        {
            Visible = false;
        }

        public void removeFood() {
            eventAggregator.GetEvent<FoodDeletedEvent>().Publish(this);
        }

        public void AddImage()
        {
            eventAggregator.GetEvent<FoodAddEvent>().Publish();
        }
    }
}
