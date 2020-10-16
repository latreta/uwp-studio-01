using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamsungHealthStudioPlus01.Services
{
    public interface IEventTokenService
    {
        SubscriptionToken GetFoodAddEventToken();
        void SetFoodAddEventToken(SubscriptionToken token);
    }
}
