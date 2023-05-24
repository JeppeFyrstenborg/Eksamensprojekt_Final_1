using DTO.Models;
using Eksamensprojekt_Final_1_WPFApp.ViewModels;
using MyCustomControlsWPF;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace Eksamensprojekt_Final_1_WPFApp.Views
{
    /// <summary>
    /// Interaction logic for ChatView.xaml
    /// </summary>
    public partial class ChatView : UserControl
    {
        public ChatView()
        {
            InitializeComponent();
            if (App.MainViewModel.CurrentViewModel is ChatViewModel chatViewModel)
            {
                DataContext = App.MainViewModel.CurrentViewModel;
                SetName();
                chatViewModel.UpdateMessages();
                UpdateMessages();



                //Subscribing to lists
                chatViewModel.PropertyChanged += ViewModelPropertyChanged;
            }
        }

        private void ViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "SortedMessages")
            {
                UpdateMessages();
            }
        }

        private void SendMessageClick(object sender, RoutedEventArgs e)
        {
            UpdateMessages();
        }
        private void SetName()
        {
            if (DataContext is ChatViewModel chatViewModel)
            {
                textBoxChatName.Text = chatViewModel.Chat.ChatName;
            }
        }

        private void UpdateMessages()
        {
            MessagesStackPanel.Children.Clear();

            if (DataContext is ChatViewModel chatViewModel)
            {
                List<Message> sortedMessages = chatViewModel.SortedMessages;

                foreach (var message in sortedMessages)
                {
                    MessageChat tempMessageControl = new MessageChat
                    {
                        MessageText = message.MessageText
                    };

                    if (message.User.UserId == App.HomeViewModel.User.UserId)
                    {
                        tempMessageControl.SenderName = "Me";
                        tempMessageControl.HorizontalAlignment = HorizontalAlignment.Right;
                        tempMessageControl.MessageSender = MessageSenders.Self;
                    }
                    else
                    {
                        tempMessageControl.SenderName = message.User.Username;
                        tempMessageControl.HorizontalAlignment = HorizontalAlignment.Left;
                        tempMessageControl.MessageSender = MessageSenders.Other;
                    }
                    tempMessageControl.MessageTime = message.CreatedTime.ToString("dd-MM-yyyy HH:mm");
                    tempMessageControl.MouseDoubleClick += DeleteMessage;
                    tempMessageControl.MessageId = message.MessageId;
                    MessagesStackPanel.Children.Add(tempMessageControl);
                }
            }
        }

        private void DeleteMessage(object sender, RoutedEventArgs e)
        {
            if (sender is MessageChat messagechat && App.MainViewModel.CurrentViewModel is ChatViewModel chatViewModel)
            {
                if (messagechat.MessageSender == MessageSenders.Self)
                {
                    bool result = MessageBox.Show("Vil Du virkelig slette beskeden?", "Confirmation",
                        MessageBoxButton.OKCancel) == MessageBoxResult.OK;
                    if (result)
                    {
                        chatViewModel.DeleteMessage(messagechat.MessageId);
                    }
                }
            }

        }

        private void EditChatname(object sender, RoutedEventArgs e)
        {
            textBoxChatName.IsReadOnly = false;
            textBoxChatName.Focus();
            textBoxChatName.SelectAll();
        }

        private void TextBoxChatNameLostFocus(object sender, RoutedEventArgs e)
        {

            textBoxChatName.IsReadOnly = true;
            if (DataContext is ChatViewModel chatViewModel)
            {
                chatViewModel.Chat.ChatName = textBoxChatName.Text;
                chatViewModel.UpdateChatCommand.Execute(null);
                textBoxChatName.Text = chatViewModel.Chat.ChatName;
            }
        }
        private void BtnClearClick(object sender, RoutedEventArgs e)
        {
            txtInputMessage.Clear();
        }
        private void TxtInputTextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtInputMessage.Text))
                tbPlaceholder.Visibility = Visibility.Visible;
            else tbPlaceholder.Visibility = Visibility.Hidden;
        }

        private void DeleteChatClick(object sender, RoutedEventArgs e)
        {
            if (App.MainViewModel.CurrentViewModel is ChatViewModel chatViewModel)
            {
                bool result = MessageBox.Show("Du er ved at slette denne chat!\n" +
                "Ønsker du at fortsætte?", "Confirmation",
                        MessageBoxButton.YesNo) == MessageBoxResult.Yes;
                if (result)
                {
                    chatViewModel.DeleteChat();
                }
            }
        }
    }
}
