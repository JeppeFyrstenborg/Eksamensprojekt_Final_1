using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
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
using BLL.Services;
using DAL.Repositories;
using Eksamensprojekt_Final_1_WPFApp.ViewModels;

namespace Eksamensprojekt_Final_1_WPFApp.Views
{
    /// <summary>
    /// Interaction logic for LoginView.xaml
    /// </summary>
    public partial class LoginView : UserControl
    {
        public LoginView()
        {
            InitializeComponent();

            if (App.MainViewModel.CurrentViewModel is LoginViewModel)
            {
                DataContext = App.MainViewModel.CurrentViewModel;
            }
        }

        private void Temporary(object sender, RoutedEventArgs e)
        {
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (this.DataContext != null)
            { ((dynamic)this.DataContext).Password = ((PasswordBox)sender).SecurePassword; }
        }

        //private void LoginButton_Click(object sender, RoutedEventArgs e)
        //{
        //        // Authentication failed
        //        MessageBox.Show("Invalid email or password");
        //}
    }
}
