using SamsungHealthStudioPlus01.Models;
using System;
using System.Collections.Generic;
using Windows.Storage;

namespace SamsungHealthStudioPlus01.Services
{
    public interface IFoodService
    {
        List<Food> GetFoods();
        void AddFood(IStorageFile image, DateTime date);
        void RemoveFood(string id);
    }
}
