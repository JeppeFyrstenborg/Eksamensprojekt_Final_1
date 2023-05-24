using DAL;
using DTO.Models;
using System.Windows;

namespace Eksamensprojekt_Final_1_WPFApp
{
    public partial class MainWindow : Window
    {
        private DatabaseContext databaseContext;
        public MainWindow()
        {
            databaseContext = new DatabaseContext();
            InitializeComponent();
            DataContext = App.MainViewModel;
        }
    }
}