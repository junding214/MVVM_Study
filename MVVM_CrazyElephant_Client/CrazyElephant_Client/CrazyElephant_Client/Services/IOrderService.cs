using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CrazyElephant_Client.Services
{
    interface IOrderService
    {
        void PlaceOrder(List<string> dishes);
    }
}
