using SamsungHealthStudioPlus01.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SamsungHealthStudioPlus01.Services
{
    public class ActivityService : IActivityService
    {
        private readonly List<Schedule> Schedules = new List<Schedule>();
        private readonly string[] Weathers = { "Rain", "Sunny", "Cloudly", "Predominant Sun" };
        public Schedule GetSchedule(DateTime dateTime)
        {
            var schedule = Schedules.FirstOrDefault(a => a.DateTime.Date == dateTime.Date);
            if (schedule == null)
            {
                schedule = GenerateNewSchedule(dateTime);
            }
            return schedule;
        }

        private Schedule GenerateNewSchedule(DateTime dateTime)
        {
            var random = new Random();
            var result = new Schedule
            {
                DateTime = dateTime.Date,
                Temperature = random.Next(-5, 32),
                Weather = Weathers[random.Next(0, Weathers.Count() - 1)],
                Activities = GenerateRandomActivities(dateTime)
            };
            Schedules.Add(result);
            return result;
        }

        private List<Activity> GenerateRandomActivities(DateTime dateTime)
        {
            var result = new List<Activity>();
            var random = new Random();
            var count = random.Next(3, 4);
            var enumValues = Enum.GetValues(typeof(ActivityType));
            for (int i = 0; i < count; i++)
            {
                var randomHour = random.Next(8, 18);
                var referenceDate = dateTime.Date.AddHours(randomHour);
                var typeValue = (ActivityType)enumValues.GetValue(random.Next(0, enumValues.Length));
                if (!result.Any(a => a.Type == typeValue))
                    result.Add(new Activity
                    {
                        DateTime = referenceDate,
                        Done = false,
                        Duration = random.Next(5, 155),
                        Type = typeValue,
                        Id = Guid.NewGuid().ToString()
                    });
            }
            return result;
        }
    }
}
