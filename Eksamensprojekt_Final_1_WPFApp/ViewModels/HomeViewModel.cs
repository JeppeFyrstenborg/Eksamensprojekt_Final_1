using BLL.Controllers;
using CommunityToolkit.Mvvm.Input;
using DAL.Repositories;
using DTO.Models;
using System.Collections.Generic;
using System.ComponentModel;

namespace Eksamensprojekt_Final_1_WPFApp.ViewModels
{
    public class HomeViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private ChatController _chatController;

        private IRelayCommand _getChatsForUserCommad;
        public IRelayCommand GetChatsForUserCommad
        {
            get
            {
                if (_getChatsForUserCommad == null)
                {
                    _getChatsForUserCommad = new RelayCommand(GetChatsFromDbForUser);
                }
                return _getChatsForUserCommad;
            }
        }

        private IRelayCommand _goToSelectedChatCommand;

        public IRelayCommand GoToSelectedChatCommand
        {
            get
            {
                if (_goToSelectedChatCommand == null)
                {
                    _goToSelectedChatCommand = new RelayCommand(GoToChat, CanGoToChat);
                }
                return _goToSelectedChatCommand;
            }
        }

        private IRelayCommand _goToCreateChatCommand;

        public IRelayCommand GoToCreateChatCommand
        {
            get
            {
                if (_goToCreateChatCommand == null)
                {
                    _goToCreateChatCommand = new RelayCommand(GoToCreateChat);
                }
                return _goToCreateChatCommand;
            }
        }

        private IRelayCommand _goToEditUserCommand;

        public IRelayCommand GoToEditUserCommand
        {
            get
            {
                if (_goToEditUserCommand == null)
                {
                    _goToEditUserCommand = new RelayCommand(GoToEditUser);
                }
                return _goToEditUserCommand;
            }
        }

        private IRelayCommand _logOutCommand;

        public IRelayCommand LogOutCommand
        {
            get
            {
                if (_logOutCommand == null)
                {
                    _logOutCommand = new RelayCommand(LogOut);
                }
                return _logOutCommand;
            }
        }

        private User _user;

        public User User
        {
            get { return _user; }
            set
            {
                _user = value;
                OnPropertyChanged("User");
                App.CreateChatViewModel.UpdateAllUsers();
                GetChatsFromDbForUser();
            }
        }

        private Chat _selectedChat;

        public Chat SelectedChat
        {
            get { return _selectedChat; }
            set
            {
                _selectedChat = value;
                OnPropertyChanged("SelectedChat");
                GoToSelectedChatCommand.NotifyCanExecuteChanged();
            }
        }


        private List<Chat> _chats;

        public List<Chat> Chats
        {
            get { return _chats; }
            set
            {
                _chats = value;
                OnPropertyChanged("Chats");
            }
        }

        public HomeViewModel()
        {
            _chatController = new ChatController(new ChatRepository());
        }

        public void GetChatsFromDbForUser()
        {
            if (User != null)
            {
                Chats = _chatController.GetChatsForUser(User.UserId);
            }
        }

        private bool CanGoToChat()
            => SelectedChat != null;

        public void GoToChat()
        {
            App.ChatViewModel.Chat = SelectedChat;
            App.MainViewModel.CurrentViewModel = App.ChatViewModel;
        }

        private bool CanGoToEditUser()
            => User != null;

        public void GoToEditUser()
        {
            App.MainViewModel.CurrentViewModel = new EditUserViewModel(User);
        }

        public void GoToCreateChat()
        {
            App.MainViewModel.CurrentViewModel = App.CreateChatViewModel;
            App.CreateChatViewModel.UpdateAllUsers();
        }

        public void LogOut()
        {
            App.LogOut();
        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
