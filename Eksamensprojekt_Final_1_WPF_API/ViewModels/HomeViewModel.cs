using CommunityToolkit.Mvvm.Input;
using Eksamensprojekt_Final_1_WPF_API.Controllers;
using Eksamensprojekt_Final_1_WPF_API.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eksamensprojekt_Final_1_WPF_API.ViewModels
{
    public class HomeViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private ChatController ChatController { get; }

        public HomeViewModel()
        {
            this.ChatController = new ChatController();
            UpdateChats();
        }

        private IRelayCommand _updateChatCommand;

        public IRelayCommand UpdateChatCommand
        {
            get
            {
                if (_updateChatCommand == null)
                {
                    _updateChatCommand = new RelayCommand(UpdateChat, CanUpdateChat);
                }
                return _updateChatCommand;
            }
        }

        private IRelayCommand _deleteChatCommand;

        public IRelayCommand DeleteChatCommand
        {
            get
            {
                if (_deleteChatCommand == null)
                {
                    _deleteChatCommand = new RelayCommand(DeleteChat, CanDeleteChat);
                }
                return _deleteChatCommand;
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
                UpdateChatCommand.NotifyCanExecuteChanged();
                DeleteChatCommand.NotifyCanExecuteChanged();
            }
        }

        private string _statusMessage;

        public string StatusMessage
        {
            get { return _statusMessage; }
            set
            {
                _statusMessage = value;
                OnPropertyChanged("StatusMessage");
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
        public void UpdateChats()
        {
            Chats = this.ChatController.FetchAllChats();
        }

        private bool CanUpdateChat()
            => SelectedChat != null;

        public void UpdateChat()
        {
            StatusMessage = this.ChatController.UpdateChat(SelectedChat);
            UpdateChats();
            SelectedChat = null;
        }

        private bool CanDeleteChat()
            => SelectedChat != null;

        public void DeleteChat()
        {
            StatusMessage = this.ChatController.DeleteChat(SelectedChat.ChatId);
            UpdateChats();
            SelectedChat = null;
        }

    }
}
