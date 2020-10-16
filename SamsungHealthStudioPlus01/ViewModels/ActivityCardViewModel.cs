using Prism.Windows.Mvvm;
using SamsungHealthStudioPlus01.Models;
using SamsungHealthStudioPlus01.Services;
using System;

namespace SamsungHealthStudioPlus01.ViewModels
{
    public class ActivityCardViewModel : ViewModelBase
    {
        private readonly IActivityService activityService;
        public ActivityCardViewModel(IActivityService activityService)
        {
            this.activityService = activityService;
            Date = DateTime.Now;
            GetSchedule();
        }

        private Schedule currentSchedule;
        public Schedule CurrentSchedule
        {
            get { return currentSchedule; }
            set { SetProperty(ref currentSchedule, value); }
        }

        private DateTime _date = default(DateTime);
        public DateTime Date
        {
            get { return _date; }
            set { SetProperty(ref _date, value); }
        }

        public void GetSchedule()
        {
            CurrentSchedule = activityService.GetSchedule(Date);
        }

        public void Next()
        {
            Date = Date.AddDays(1);
            GetSchedule();
        }

        public void Prior()
        {
            Date = Date.AddDays(-1);
            GetSchedule();
        }
    }
}
