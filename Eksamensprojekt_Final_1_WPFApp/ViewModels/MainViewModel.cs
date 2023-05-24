using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eksamensprojekt_Final_1_WPFApp.ViewModels
{
        public class MainViewModel : INotifyPropertyChanged
        {
            private object _currentViewModel;
            public object CurrentViewModel
            {
                get { return _currentViewModel; }
                set
                {
                    _currentViewModel = value;
                    OnPropertyChanged("CurrentViewModel");
                }
            }

        public MainViewModel()
        {
        }


            public event PropertyChangedEventHandler PropertyChanged;
            protected void OnPropertyChanged(string propertyName)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
}
