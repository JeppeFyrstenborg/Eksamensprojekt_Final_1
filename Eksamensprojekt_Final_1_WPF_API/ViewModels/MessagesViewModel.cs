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
    public class MessagesViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private MessageController MessageController { get;}

        public MessagesViewModel()
        {
            this.MessageController = new MessageController();
            UpdateMessages();
        }

        //private IRelayCommand _goToEditUserCommand;

        //public IRelayCommand GoToEditUserCommand
        //{
        //    get
        //    {
        //        if (_goToEditUserCommand == null)
        //        {
        //            _goToEditUserCommand = new RelayCommand(GoToEditUser);
        //        }
        //        return _goToEditUserCommand;
        //    }
        //}

        //private Chat _selectedChat;

        //public Chat SelectedChat
        //{
        //    get { return _selectedChat; }
        //    set
        //    {
        //        _selectedChat = value;
        //        OnPropertyChanged("SelectedChat");
        //        GoToSelectedChatCommand.NotifyCanExecuteChanged();
        //    }
        //}


        private List<Message> _messages;

        public List<Message> Messages
        {
            get { return _messages; }
            set
            {
                _messages = value;
                OnPropertyChanged("Messages");
            }
        }

        public void UpdateMessages()
        {
            Messages = this.MessageController.FetchAllMessages();
        }
    }
}
