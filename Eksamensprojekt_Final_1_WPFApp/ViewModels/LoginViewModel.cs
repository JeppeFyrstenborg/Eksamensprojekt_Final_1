using BLL.Controllers;
using BLL.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DAL.Repositories;
using DTO.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Eksamensprojekt_Final_1_WPFApp.ViewModels
{
    public class LoginViewModel : INotifyPropertyChanged
    {

        private RelayCommand _successfulLoginCommand;
        public RelayCommand SuccessfulLoginCommand
        {
            get
            {
                if (_successfulLoginCommand == null)
                {
                    _successfulLoginCommand = new RelayCommand(OnClickLogin, CanTryLogin);
                }
                return _successfulLoginCommand;
            }
        }

        private string _email;

        public string Email
        {
            get { return _email; }
            set 
            {
                _email = value;
                OnPropertyChanged("Email");
                SuccessfulLoginCommand.NotifyCanExecuteChanged();
            }
        }

        private SecureString _password;

        public SecureString Password
        {
            get { return _password; }
            set 
            { 
                _password = value;
                OnPropertyChanged("Password");
                SuccessfulLoginCommand.NotifyCanExecuteChanged();
            }
        }

        private UserAuthRepository _userAuthRepository;
        private UserRepository _userRepository;
        private UserController _userController;
        private Security _security;

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public LoginViewModel()
        {
            //Email = string.Empty;
            Email = "bob@email.com";
            Password = new SecureString();

            _userAuthRepository = new UserAuthRepository();
            _userRepository = new UserRepository();
            _userController = new UserController(_userRepository);
            _security = new Security(_userAuthRepository, _userRepository);
        }

        private bool CanTryLogin()
            => !Email.Equals("") && Password.Length != 0;

        private void OnClickLogin()
        {
            if (_security.VerifyPassword(_password, _email))
            {
                App.HomeViewModel.User = _userController.GetUserFromEmail(_email);
                App.MainViewModel.CurrentViewModel = App.HomeViewModel;
            }
        }
    }
}
