using SamsungHealthStudioPlus01.Models;
using System;

namespace SamsungHealthStudioPlus01.Services
{
    public interface IActivityService
    {
        Schedule GetSchedule(DateTime dateTime);
    }
}