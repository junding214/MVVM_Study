using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CrazyElephant_Client.Models;
using Microsoft.Practices.Prism.ViewModel;

namespace CrazyElephant_Client.ViewModels
{
    class DishMenuItemViewModel : NotificationObject
    {
        public Dish Dish { get; set; }

        private bool isSelected;

        public bool IsSelected
        {
            get { return isSelected; }
            set
            {
                isSelected = value;
                RaisePropertyChanged("IsSelected");
            }
        }
    }
}
