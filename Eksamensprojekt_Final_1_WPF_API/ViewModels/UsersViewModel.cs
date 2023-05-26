using CommunityToolkit.Mvvm.Input;
using Eksamensprojekt_Final_1_WPF_API.Controllers;
using Eksamensprojekt_Final_1_WPF_API.Models;
using Eksamensprojekt_Final_1_WPF_API.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace Eksamensprojekt_Final_1_WPF_API.ViewModels
{
    public class UsersViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private UserController UserController { get; }

        public UsersViewModel()
        {
            this.UserController = new UserController();
            
            UpdateUsers();
            
            this.StatusCode = "";
        }

        private IRelayCommand _deleteUserCommand;

        public IRelayCommand DeleteUserCommand
        {
            get
            {
                if (_deleteUserCommand == null)
                {
                    _deleteUserCommand = new RelayCommand(DeleteUser, CanDeleteUser);
                }
                return _deleteUserCommand;
            }
        }

        private IRelayCommand _goToCreateUser;

        public IRelayCommand GoToCreateUser
        {
            get
            {
                if (_goToCreateUser == null)
                {
                    _goToCreateUser = new RelayCommand(
                        () => App.MainViewModel.CurrentViewModel = App.CreateUserViewModel);
                }
                return _goToCreateUser;
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

        private User _selectedUser;

        public User SelectedUser
        {
            get { return _selectedUser; }
            set
            {
                _selectedUser = value;
                OnPropertyChanged("SelectedUser");
                DeleteUserCommand.NotifyCanExecuteChanged();
            }
        }


        private List<User> _users;

        public List<User> Users
        {
            get { return _users; }
            set
            {
                _users = value;
                OnPropertyChanged("Users");
            }
        }
        private bool CanDeleteUser()
            => _selectedUser != null;

        private void DeleteUser()
        {
            this.StatusCode = this.UserController.DeleteUser(this.SelectedUser.UserId) + "";
            UpdateUsers();
        }

        public void UpdateUsers()
        {
            Users = this.UserController.FetchAllUsers();
        }
    }
}
