using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;
using SimpleMVVM.Commands;


namespace SimpleMVVM.ViewModels
{
    class MainWindowViewModel:NotificationObject
    {
  

        private double _input1;

        public double Input1
        {
            get { return _input1; }
            set
            {
                _input1 = value;
                RaisePropertyChanged("Input1");
            }
        }

        private double _input2;

        public double Input2
        {
            get { return _input2; }
            set
            {
                _input2 = value;
                RaisePropertyChanged("Input2");
            }
        }

        private double _result;

        public double Result
        {
            get { return _result; }
            set
            {
                _result = value;
                RaisePropertyChanged("Result");
            }
        }

        public DelegateCommand AddCommand { get; set; }

        private void Add(object parameter)
        {
            Result = _input1 + _input2;
        }

        public DelegateCommand SaveCommand { get; set; }

        private void Save(object parameter)
        {
            SaveFileDialog d = new SaveFileDialog();
            d.ShowDialog();
        }

        public MainWindowViewModel()
        {
            AddCommand = new DelegateCommand();
            AddCommand.ExecuteAction = new Action<object>(Add);

            SaveCommand = new DelegateCommand();
            SaveCommand.ExecuteAction = new Action<object>(Save);
        }
    }
}
