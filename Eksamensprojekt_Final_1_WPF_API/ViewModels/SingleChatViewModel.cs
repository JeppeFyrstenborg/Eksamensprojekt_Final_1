﻿using Eksamensprojekt_Final_1_WPF_API.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eksamensprojekt_Final_1_WPF_API.ViewModels
{
    public class SingleChatViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public SingleChatViewModel()
        {
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

        private Chat _selectedChat;

        public Chat SelectedChat
        {
            get { return _selectedChat; }
            set
            {
                _selectedChat = value;
                OnPropertyChanged("SelectedChat");
                //GoToSelectedChatCommand.NotifyCanExecuteChanged();
            }
        }

    }
}
