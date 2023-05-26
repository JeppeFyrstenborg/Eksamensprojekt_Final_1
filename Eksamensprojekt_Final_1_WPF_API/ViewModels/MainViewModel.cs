using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eksamensprojekt_Final_1_WPF_API.ViewModels
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

        private IRelayCommand _goToHomeCommand;

        public IRelayCommand GoToHomeCommand
        {
            get
            {
                if (_goToHomeCommand == null)
                {
                    _goToHomeCommand = new RelayCommand(
                        ()=> App.MainViewModel.CurrentViewModel = App.HomeViewModel);
                }
                return _goToHomeCommand;
            }
        }

        private IRelayCommand _goToUsersCommand;

        public IRelayCommand GoToUsersCommand
        {
            get
            {
                if (_goToUsersCommand == null)
                {
                    _goToUsersCommand = new RelayCommand(
                        () => App.MainViewModel.CurrentViewModel = App.UsersViewModel);
                }
                return _goToUsersCommand;
            }
        }

        private IRelayCommand _goToMessagesCommand;

        public IRelayCommand GoToMessagesCommand
        {
            get
            {
                if (_goToMessagesCommand == null)
                {
                    _goToMessagesCommand = new RelayCommand(
                        () => App.MainViewModel.CurrentViewModel = App.MessagesViewModel);
                }
                return _goToMessagesCommand;
            }
        }
    }
}
