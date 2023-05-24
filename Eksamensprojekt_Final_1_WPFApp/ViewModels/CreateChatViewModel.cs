using BLL.Controllers;
using CommunityToolkit.Mvvm.Input;
using DAL.Repositories;
using DTO.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eksamensprojekt_Final_1_WPFApp.ViewModels
{
    public class CreateChatViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private ChatController _chatController;
        private UserController _userController;

        public CreateChatViewModel()
        {
            SelectedUser = null;
            NewChatName = string.Empty;
            _chatController = new ChatController(new ChatRepository());
            _userController = new UserController(new UserRepository());
            UpdateAllUsers();
        }

        private User _selectedUser;

        public User SelectedUser
        {
            get { return _selectedUser; }
            set
            {
                _selectedUser = value;
                OnPropertyChanged("SelectedUser");
            }
        }
        private string _newChatName;

        public string NewChatName
        {
            get { return _newChatName; }
            set
            {
                _newChatName = value;
                OnPropertyChanged("NewChatName");
            }
        }

        private List<User> _allUsers;

        public List<User> AllUsers
        {
            get { return _allUsers; }
            set
            {
                _allUsers = value;
                OnPropertyChanged("AllUsers");
            }
        }


        private IRelayCommand _createNewChatCommand;

        public IRelayCommand CreateNewChatCommand
        {
            get
            {
                if (_createNewChatCommand == null)
                {
                    _createNewChatCommand = new RelayCommand(CreateNewChat, CanCreateNewChat);
                }
                return _createNewChatCommand;
            }
        }

        public void UpdateAllUsers()
        {
            AllUsers = _userController.GetAllUsers();
        }

        private bool CanCreateNewChat()
        => SelectedUser != null;

        public void CreateNewChat()
        {
            _chatController.CreateNewChatWithNameAndUserIds(NewChatName, SelectedUser.UserId, App.HomeViewModel.User.UserId);
        }

    }
}
