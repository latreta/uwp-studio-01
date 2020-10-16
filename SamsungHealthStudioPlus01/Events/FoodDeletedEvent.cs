using Prism.Events;
using SamsungHealthStudioPlus01.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamsungHealthStudioPlus01.Events
{
    class FoodDeletedEvent: PubSubEvent<Food>
    {
    }
}
