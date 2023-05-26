using BLL.Controllers;
using BLL.Services;
using CommunityToolkit.Mvvm.Input;
using DAL.Repositories;
using System;
using System.ComponentModel;
using System.Security;

namespace Eksamensprojekt_Final_1_WPFApp.ViewModels
{
    public class CreateUserViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private UserController _userController;
        private MessageController _messageController;
        private Security _security;


        public CreateUserViewModel()
        {
            _userController = new UserController(new UserRepository(), new UserAuthRepository());
            _messageController = new MessageController(new MessageRepository());
            _security = new Security();

            Username = string.Empty;
            Email = string.Empty;
            Password = new SecureString();
            Password2 = new SecureString();
        }

        private string _username;

        public string Username
        {
            get { return _username; }
            set
            {
                _username = value;
                OnPropertyChanged("Username");
                CreateNewUserCommand.NotifyCanExecuteChanged();
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
                CreateNewUserCommand.NotifyCanExecuteChanged();
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
                CreateNewUserCommand.NotifyCanExecuteChanged();
            }
        }

        private SecureString _password2;

        public SecureString Password2
        {
            get { return _password2; }
            set
            {
                _password2 = value;
                OnPropertyChanged("Password2");
                CreateNewUserCommand.NotifyCanExecuteChanged();
            }
        }
        private IRelayCommand _createNewUserCommand;

        public IRelayCommand CreateNewUserCommand
        {
            get
            {
                if (_createNewUserCommand == null)
                {
                    _createNewUserCommand = new RelayCommand(CreateNewUser, CanCreateNewUser);
                }
                return _createNewUserCommand;
            }
        }

        private IRelayCommand _goToLoginCommand;
        public IRelayCommand GoToLoginCommand
        {
            get
            {
                if (_goToLoginCommand == null)
                {
                    _goToLoginCommand = new RelayCommand(
                        () => App.MainViewModel.CurrentViewModel = App.LoginViewModel);
                }
                return _goToLoginCommand;
            }
        }


        private bool CanCreateNewUser()
             => Password.Length != 0
                && Password2.Length != 0
                && _security.AreSecureStringsEqual(Password, Password2)
                && Username.Length != 0
                && Email.Length != 0;

        public void CreateNewUser()
        {
            if (_userController.GetUserFromEmail(Email) == null)
            {
                Tuple<string, string> userAuthPassAndSalt = _security.GetHashedPasswordAndSaltFrom(Password);

                _userController.CreateNewUser(Username, Email, userAuthPassAndSalt.Item1, userAuthPassAndSalt.Item2);

                GoToLoginCommand.Execute(null);
            }

        }
    }
}
