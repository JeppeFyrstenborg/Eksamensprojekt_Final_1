using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace MyCustomControlsWPF
{
    public enum ArrowDirections
    {
        Left,
        Right
    }
    public partial class ButtonArrowChat : UserControl, INotifyPropertyChanged
    {
        public ButtonArrowChat()
        {
            DataContext = this;
            InitializeComponent();
        }

        public string FrontColor
        {
            get { return (string)GetValue(FrontColorProperty); }
            set { SetValue(FrontColorProperty, value); }
        }

        public static readonly DependencyProperty FrontColorProperty =
            DependencyProperty.Register("FrontColor", typeof(string), typeof(ButtonArrowChat), new PropertyMetadata("Black"));

        public ICommand ButtonCommand
        {
            get { return (ICommand)GetValue(ButtonCommandProperty); }
            set { SetValue(ButtonCommandProperty, value); }
        }

        public static readonly DependencyProperty ButtonCommandProperty =
            DependencyProperty.Register("ButtonCommand", typeof(ICommand), typeof(ButtonChat), new PropertyMetadata(null, OnButtonCommandChanged));

        private static void OnButtonCommandChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var buttonChat = (ButtonChat)d;
            buttonChat.SendButton.Command = (ICommand)e.NewValue;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        //private string _frontColor;
        //public string FrontColor
        //{
        //    get { return _frontColor; }
        //    set
        //    {
        //        _frontColor = value;
        //        OnPropertyChanged(nameof(FrontColor));
        //    }
        //}

        private ArrowDirections _arrowDirection;
        public ArrowDirections ArrowDirection
        {
            get { return _arrowDirection; }
            set
            {
                _arrowDirection = value;
                OnPropertyChanged(nameof(ArrowDirection));
                UpdateArrowData();
            }
        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void UpdateArrowData()
        {
            if (ArrowDirection == ArrowDirections.Left)
            {
                ArrowPath.Data = Geometry.Parse("M 5,10 L 15,0 M 5,10 L 15,20");
            }
            else if (ArrowDirection == ArrowDirections.Right)
            {
                ArrowPath.Data = Geometry.Parse("M 15,10 L 5,0 M 15,10 L 5,20");
            }
        }
    }
}
