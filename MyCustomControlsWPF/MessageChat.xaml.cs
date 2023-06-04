using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace MyCustomControlsWPF
{

    public enum MessageSenders
    {
        Self,
        Other
    }

    public partial class MessageChat : UserControl, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string _messageText;

        public string MessageText
        {
            get { return _messageText; }
            set
            {
                _messageText = value;
                OnPropertyChanged(nameof(MessageText));
            }
        }

        public int SizeFont
        {
            get { return (int)GetValue(SizeFontProperty); }
            set { SetValue(SizeFontProperty, value); }
        }

        public static readonly DependencyProperty SizeFontProperty =
            DependencyProperty.Register("SizeFont", typeof(int), typeof(MessageChat), new PropertyMetadata(14));

        public int MessageId
        {
            get { return (int)GetValue(MessageIdProperty); }
            set { SetValue(MessageIdProperty, value); }
        }

        public static readonly DependencyProperty MessageIdProperty =
            DependencyProperty.Register("MessageId", typeof(int), typeof(MessageChat), new PropertyMetadata(0));


        private MessageSenders _messageSender;

        public MessageSenders MessageSender
        {
            get { return _messageSender; }
            set
            {
                _messageSender = value;
                OnPropertyChanged(nameof(MessageSender));
                SetColorsOfMessage();
            }
        }

        private string _senderName;
        public string SenderName
        {
            get { return _senderName; }
            set
            {
                _senderName = value;
                OnPropertyChanged(nameof(SenderName));
            }
        }

        private string _messageTime;
        public string MessageTime
        {
            get { return _messageTime; }
            set
            {
                _messageTime = value;
                OnPropertyChanged(nameof(MessageTime));
            }
        }

        public MessageChat()
        {
            DataContext = this;
            InitializeComponent();
        }



        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void SetColorsOfMessage()
        {
            if (MessageSender == MessageSenders.Self)
            {
                borderForTxtMessage.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#fdc401");
                txtBlockMessage.Foreground = (SolidColorBrush)new BrushConverter().ConvertFrom("#FF387752");
                txtBlockName.Foreground = (SolidColorBrush)new BrushConverter().ConvertFrom("#FF387752");
                txtBlockTime.Foreground = (SolidColorBrush)new BrushConverter().ConvertFrom("#FF387752");

            }
            else if (MessageSender == MessageSenders.Other)
            {
                borderForTxtMessage.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#FF387752");
                txtBlockMessage.Foreground = (SolidColorBrush)new BrushConverter().ConvertFrom("#fdc401");
                txtBlockName.Foreground = (SolidColorBrush)new BrushConverter().ConvertFrom("#fdc401");
                txtBlockTime.Foreground = (SolidColorBrush)new BrushConverter().ConvertFrom("#fdc401");
            }
        }
    }
}
