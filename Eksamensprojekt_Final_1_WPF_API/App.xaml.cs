using Eksamensprojekt_Final_1_WPF_API.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Eksamensprojekt_Final_1_WPF_API
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static MainViewModel MainViewModel { get; private set; }
        public static HomeViewModel HomeViewModel { get; private set; }
        public static UsersViewModel UsersViewModel { get; private set; }
        public static MessagesViewModel MessagesViewModel { get; private set; }
        public static CreateUserViewModel CreateUserViewModel { get; private set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            HomeViewModel = new HomeViewModel();
            UsersViewModel = new UsersViewModel();
            MessagesViewModel = new MessagesViewModel();
            CreateUserViewModel = new CreateUserViewModel();
            MainViewModel = new MainViewModel
            {
                CurrentViewModel = HomeViewModel
            };

            base.OnStartup(e);
        }
    }
}
