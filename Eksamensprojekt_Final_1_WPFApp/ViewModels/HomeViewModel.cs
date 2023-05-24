using BLL.Controllers;
using CommunityToolkit.Mvvm.ComponentModel;
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


        private User _user;

        public User User
        {
            get { return _user; }
            set 
            { 
                _user = value;
                OnPropertyChanged("User");
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

        private void GetChatsFromDbForUser()
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

        public void GoToCreateChat()
        {
            App.MainViewModel.CurrentViewModel = App.CreateChatViewModel;
            App.CreateChatViewModel.UpdateAllUsers();
        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
