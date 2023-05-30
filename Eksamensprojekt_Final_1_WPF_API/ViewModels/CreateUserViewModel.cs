using CommunityToolkit.Mvvm.Input;
using Eksamensprojekt_Final_1_WPF_API.Controllers;
using Eksamensprojekt_Final_1_WPF_API.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace Eksamensprojekt_Final_1_WPF_API.ViewModels
{
    public class CreateUserViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public UserController UserController { get; }

        private Security Security;

        public CreateUserViewModel()
        {
            this.UserController = new UserController();
            this.Security = new Security();

            Username = string.Empty;
            Email = string.Empty;
            Password = new SecureString();
            Password2 = new SecureString();
            Birthday = DateTime.Now.Date.AddYears(-18);
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

        private DateTime _birthday;

        public DateTime Birthday
        {
            get { return _birthday; }
            set
            {
                _birthday = value; 
                OnPropertyChanged("Birthday");
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

        private string _statusCode;

        public string StatusCode
        {
            get { return _statusCode; }
            set
            {
                _statusCode = value;
                OnPropertyChanged("StatusCode");
            }
        }

        private bool CanCreateNewUser()
            => Password.Length != 0
            && Password2.Length != 0
            && this.Security.AreSecureStringsEqual(Password, Password2)
            && Username.Length != 0
            && Email.Length != 0
            && Birthday.Date <= DateTime.Now.Date.AddYears(-18);


        public void CreateNewUser()
        {
            this.UserController.CreateUser(Username, Email, Password, Birthday);

            Username = string.Empty;
            Email = string.Empty;
            Password = new SecureString();
            Password2 = new SecureString();
            Birthday = DateTime.Now.Date.AddYears(-18);

            App.MainViewModel.CurrentViewModel = App.UsersViewModel;
            App.UsersViewModel.UpdateUsers();
        }

    }
}
