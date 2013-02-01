using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CrazyElephant_Client.Models;

namespace CrazyElephant_Client.Services
{
    interface IDataService
    {
        List<Dish> GetAllDishes();
    }
}
