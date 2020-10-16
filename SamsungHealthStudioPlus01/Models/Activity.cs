using Prism.Mvvm;
using System;
using System.ComponentModel;

namespace SamsungHealthStudioPlus01.Models
{
    public class Activity : BindableBase
    {
        public string Id { get; set; }
        public ActivityType Type { get; set; }
        public DateTime DateTime { get; set; }
        public int Duration { get; set; }
        private bool done = false;
        public bool Done
        {
            get { return done; }
            set { SetProperty(ref done, value); }
        }
    }

    public enum ActivityType
    {
        [Description("Swimming")]
        Swimming,
        [Description("Cycling")]
        Cycling,
        [Description("Aerobics")]
        Aerobics,
        [Description("Stretching")]
        Stretching,
        [Description("Handball")]
        Handball,
        [Description("Running")]
        Running,
        [Description("Circuit Training")]
        Circuit_Training,
    }
}
