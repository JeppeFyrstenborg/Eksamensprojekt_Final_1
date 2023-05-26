using BLL.Controllers;
using CommunityToolkit.Mvvm.Input;
using DAL.Repositories;
using DTO.Models;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

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
            _userController = new UserController(new UserRepository(), new UserAuthRepository());
        }

        private User _selectedUser;

        public User SelectedUser
        {
            get { return _selectedUser; }
            set
            {
                _selectedUser = value;
                OnPropertyChanged("SelectedUser");
                CreateNewChatCommand.NotifyCanExecuteChanged();

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
                CreateNewChatCommand.NotifyCanExecuteChanged();
            }
        }

        private List<User> _allUsersWithoutLoggedInUser;

        public List<User> AllUsersWithoutLoggedInUser
        {
            get { return _allUsersWithoutLoggedInUser; }
            set
            {
                _allUsersWithoutLoggedInUser = value;
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

        private IRelayCommand _goBackToHomeCommand;
        public IRelayCommand GoBackToHomeCommand
        {
            get
            {
                if (_goBackToHomeCommand == null)
                {
                    _goBackToHomeCommand = new RelayCommand(GoToHomeView);
                }
                return _goBackToHomeCommand;
            }
        }

        public void GoToHomeView()
        {
            App.MainViewModel.CurrentViewModel = App.HomeViewModel;
            App.HomeViewModel.GetChatsFromDbForUser();
        }

        public void UpdateAllUsers()
        {
            AllUsersWithoutLoggedInUser = _userController.GetAllUsers()
                .Where(u => u.UserId != App.HomeViewModel.User.UserId)
                .ToList();
        }

        private bool CanCreateNewChat()
        => SelectedUser != null && NewChatName.Length != 0;

        public void CreateNewChat()
        {
            _chatController
                .CreateNewChatWithNameAndUserIds(NewChatName, SelectedUser.UserId, App.HomeViewModel.User.UserId);
            SelectedUser = null;
            NewChatName = string.Empty;
        }

    }
}
