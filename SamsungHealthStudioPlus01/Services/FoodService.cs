using Prism.Events;
using SamsungHealthStudioPlus01.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.UI.Xaml.Controls;

namespace SamsungHealthStudioPlus01.Services
{
    public class FoodService : IFoodService
    {
        private List<Food> _foods;
        private readonly IEventAggregator eventAggregator;

        public FoodService(IEventAggregator eventAggregator)
        {
            this._foods = new List<Food>();
            this.eventAggregator = eventAggregator;
        }

        public List<Food> GetFoods()
        {
            return _foods;
        }

        public async void AddFood(IStorageFile file, DateTime date)
        {
            Food food = new Food(file, date, this, eventAggregator);
            _foods.Add(food);
            
        }

        public void RemoveFood(string id)
        {
            _foods.Remove(_foods.Find(p => p.Id == id));
        }
    }
}
