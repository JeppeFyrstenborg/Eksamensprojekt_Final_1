using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace MyCustomControlsWPF
{
    public partial class InputBoxChat : UserControl, INotifyPropertyChanged
    {
        public InputBoxChat()
        {
            DataContext = this;
            SizeFont = 16;
            InitializeComponent();
        }

        private string _placeholder;

        private double _sizeFont;

        public double SizeFont
        {
            get { return _sizeFont; }
            set
            {
                _sizeFont = value;
                OnPropertyChanged(nameof(SizeFont));
            }
        }

        public static readonly DependencyProperty TextProperty =
    DependencyProperty.Register("Text", typeof(string), typeof(InputBoxChat), new FrameworkPropertyMetadata(string.Empty));

        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public string Placeholder
        {
            get { return _placeholder; }
            set
            {
                _placeholder = value;
                OnPropertyChanged(nameof(Placeholder));
            }
        }

        private void BtnClearClick(object sender, RoutedEventArgs e)
        {
            txtInput.Clear();
            txtInput.Focus();
        }

        private void TxtInputTextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtInput.Text))
                tbPlaceholder.Visibility = Visibility.Visible;
            else tbPlaceholder.Visibility = Visibility.Hidden;
        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
