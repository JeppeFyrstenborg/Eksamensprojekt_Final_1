using Eksamensprojekt_Final_1_WPF_API.ViewModels;
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

namespace Eksamensprojekt_Final_1_WPF_API.Views
{
    /// <summary>
    /// Interaction logic for MessagesView.xaml
    /// </summary>
    public partial class MessagesView : UserControl
    {
        public MessagesView()
        {
            InitializeComponent();
            if (App.MainViewModel.CurrentViewModel is MessagesViewModel)
            {
                DataContext = App.MainViewModel.CurrentViewModel;
            }
        }
    }
}
