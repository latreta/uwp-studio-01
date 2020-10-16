using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamsungHealthStudioPlus01.Services
{
    public class EventTokenService : IEventTokenService
    {
        public SubscriptionToken foodAddEventToken;

        public EventTokenService()
        {
            foodAddEventToken = null;
        }

        public SubscriptionToken GetFoodAddEventToken()
        {
            return foodAddEventToken;
        }

        public void SetFoodAddEventToken(SubscriptionToken token)
        {
            foodAddEventToken = token;
        }
    }
}
