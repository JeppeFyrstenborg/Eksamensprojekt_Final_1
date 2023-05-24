using System;
using System.Collections.Generic;
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
using Eksamensprojekt_Final_1_WPFApp.ViewModels;

namespace Eksamensprojekt_Final_1_WPFApp.Views
{
    /// <summary>
    /// Interaction logic for HomeView.xaml
    /// </summary>
    public partial class HomeView : UserControl
    {
        public HomeView()
        {
            InitializeComponent();
            if (App.MainViewModel.CurrentViewModel is HomeViewModel)
            {
                DataContext = App.MainViewModel.CurrentViewModel;
            }
        }

        private void EnterChat_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (App.MainViewModel.CurrentViewModel is HomeViewModel)
            {
                App.HomeViewModel.GoToSelectedChatCommand.Execute(null);
            }
        }
    }
}
