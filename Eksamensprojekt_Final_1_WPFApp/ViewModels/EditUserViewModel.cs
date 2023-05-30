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
    public class EditUserViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private UserController _userController;
        private MessageController _messageController;


        public EditUserViewModel(User user)
        {
            UserForEdit = user;
            _userController = new UserController(new UserRepository(), new UserAuthRepository());
            _messageController = new MessageController(new MessageRepository());
            GetMessagesForUser();
        }

        private User _userForEdit;

        public User UserForEdit
        {
            get { return _userForEdit; }
            set
            {
                _userForEdit = value;
                OnPropertyChanged("UserForEdit");
                SaveEditedUserCommand.NotifyCanExecuteChanged();
            }
        }
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


        private IRelayCommand _saveEditedUserCommand;

        public IRelayCommand SaveEditedUserCommand
        {
            get
            {
                if (_saveEditedUserCommand == null)
                {
                    _saveEditedUserCommand = new RelayCommand(SaveChangesForUser, CanSaveChangesForUser);
                }
                return _saveEditedUserCommand;
            }
        }
        public void GoToHomeView()
        {
            App.MainViewModel.CurrentViewModel = App.HomeViewModel;
        }

        private bool CanSaveChangesForUser()
            => UserForEdit != null;

        public void SaveChangesForUser()
        {
            _userController.UpdateUserWithDetails(UserForEdit.Email, UserForEdit.Username, 
                UserForEdit.UserId, UserForEdit.Birthday);
            GoBackToHomeCommand.Execute(null);
        }

        public void GetMessagesForUser()
        {
            Messages = _messageController.GetMessagesForUserId(UserForEdit.UserId);
        }

    }
}
