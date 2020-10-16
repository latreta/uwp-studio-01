using Prism.Mvvm;
using System;
using System.Collections.Generic;

namespace SamsungHealthStudioPlus01.Models
{
    public class Schedule: BindableBase
    {
        public DateTime DateTime { get; set; }
        private List<Activity> _activitites;
        public int Temperature { get; set; }
        public string Weather {get; set;}
        public List<Activity> Activities
        {
            get { return _activitites; }
            set { SetProperty(ref _activitites, value); }
        }
    }
}
