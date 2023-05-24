using Eksamensprojekt_Final_1_WPFApp.ViewModels;
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

namespace Eksamensprojekt_Final_1_WPFApp.Views
{
    /// <summary>
    /// Interaction logic for CreateChatView.xaml
    /// </summary>
    public partial class CreateChatView : UserControl
    {
        public CreateChatView()
        {
            InitializeComponent();
            if (App.MainViewModel.CurrentViewModel is CreateChatViewModel createChatViewModel)
            {
                DataContext = App.MainViewModel.CurrentViewModel;

                createChatViewModel.UpdateAllUsers();
            }
        }

        private void ViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "")
            {
                
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

    }
}
