using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MyCustomControlsWPF
{
    public partial class ButtonCrossChat : UserControl
    {
        public ButtonCrossChat()
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

        public static readonly RoutedEvent ClickEvent =
            EventManager.RegisterRoutedEvent(
                "Click",
                RoutingStrategy.Bubble,
                typeof(RoutedEventHandler),
                typeof(ButtonChat));

        public event RoutedEventHandler Click
        {
            add { AddHandler(ClickEvent, value); }
            remove { RemoveHandler(ClickEvent, value); }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            RoutedEventArgs args = new RoutedEventArgs(ClickEvent, this);
            RaiseEvent(args);
        }
    }
}
