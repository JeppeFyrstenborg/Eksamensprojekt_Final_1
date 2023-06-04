using BLL.Controllers;
using CommunityToolkit.Mvvm.Input;
using DAL.Repositories;
using DTO.Models;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Eksamensprojekt_Final_1_WPFApp.ViewModels
{
    public class ChatViewModel : INotifyPropertyChanged
    {
        private readonly ChatController _chatController;

        private Chat _chat;

        public Chat Chat
        {
            get { return _chat; }
            set
            {
                _chat = value;
                OnPropertyChanged("Chat");
            }
        }

        private string _messageText;

        public string MessageText
        {
            get { return _messageText; }
            set
            {
                _messageText = value;
                OnPropertyChanged("MessageText");
            }
        }

        private List<Message> _sortedMessages;

        public List<Message> SortedMessages
        {
            get { return _sortedMessages; }
            set
            {
                _sortedMessages = value;
                OnPropertyChanged("SortedMessages");
            }
        }


        private IRelayCommand _goBackToHomeCommand;
        public IRelayCommand GoBackToHomeCommand
        {
            get
            {
                if (_goBackToHomeCommand == null)
                {
                    _goBackToHomeCommand = new RelayCommand(() => App.MainViewModel.CurrentViewModel =
                    App.HomeViewModel);
                }
                return _goBackToHomeCommand;
            }
        }

        private IRelayCommand _sendMessageCommand;
        public IRelayCommand SendMessageCommand
        {
            get
            {
                if (_sendMessageCommand == null)
                {
                    _sendMessageCommand = new RelayCommand(() => SendMessage());
                }
                return _sendMessageCommand;
            }
        }

        private IRelayCommand _updateChatCommand;
        public IRelayCommand UpdateChatCommand
        {
            get
            {
                if (_updateChatCommand == null)
                {
                    _updateChatCommand = new RelayCommand(() => UpdateChat());
                }
                return _updateChatCommand;
            }
        }

        public ChatViewModel()
        {
            _chatController = new ChatController(new ChatRepository());
            MessageText = string.Empty;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void UpdateMessages()
        {
            SortedMessages = _chatController.GetMessagesInChatWithUser(Chat.ChatId).OrderBy(x => x.CreatedTime).ToList();
        }

        public void UpdateChat()
        {
            Chat = _chatController.UpdateChatWithChat(Chat);
        }

        public void SendMessage()
        {
            if (!MessageText.Equals(""))
            {
                _chatController.AddMessageToChat(MessageText, App.HomeViewModel.User.UserId, Chat.ChatId);
                UpdateMessages();
            }
            MessageText = string.Empty;
        }

        public void DeleteMessage(int messageId)
        {
            _chatController.DeleteMessageFromDbWithMessageId(messageId);
            UpdateMessages();
        }

        public void DeleteChat()
        {
            _chatController.DeleteChatWithChatId(Chat.ChatId);
            GoBackToHomeCommand.Execute(null);
            App.HomeViewModel.GetChatsFromDbForUser();
        }
    }
}
