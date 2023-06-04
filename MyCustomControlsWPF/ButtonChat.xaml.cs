using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace MyCustomControlsWPF
{
    public partial class ButtonChat : UserControl
    {
        public ButtonChat()
        {
            DataContext = this;
            InitializeComponent();
        }

        public string TextContent
        {
            get { return (string)GetValue(TextContentProperty); }
            set { SetValue(TextContentProperty, value); }
        }

        public static readonly DependencyProperty TextContentProperty =
            DependencyProperty.Register("TextContent", typeof(string), typeof(ButtonChat), new PropertyMetadata(string.Empty));

        public int SizeFont
        {
            get { return (int)GetValue(SizeFontProperty); }
            set { SetValue(SizeFontProperty, value); }
        }

        public static readonly DependencyProperty SizeFontProperty =
            DependencyProperty.Register("SizeFont", typeof(int), typeof(ButtonChat), new PropertyMetadata(14));


        public static readonly DependencyProperty CommandProperty =
            DependencyProperty.Register("Command", typeof(ICommand), typeof(ButtonChat), new PropertyMetadata(null));

        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
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
            if (Command != null && Command.CanExecute(null))
                Command.Execute(null);

            RoutedEventArgs args = new RoutedEventArgs(ClickEvent, this);
            RaiseEvent(args);
        }
    }
}