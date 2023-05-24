using Eksamensprojekt_Final_1_WPFApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Eksamensprojekt_Final_1_WPFApp
{
    public partial class App : Application
    {

        public static MainViewModel MainViewModel { get; private set; }
        public static HomeViewModel HomeViewModel { get; private set; }
        public static LoginViewModel LoginViewModel { get; private set; }
        public static ChatViewModel ChatViewModel { get; private set; }
        public static CreateChatViewModel CreateChatViewModel { get; private set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            LoginViewModel = new LoginViewModel();
            HomeViewModel = new HomeViewModel();
            ChatViewModel = new ChatViewModel();
            CreateChatViewModel = new CreateChatViewModel();
            MainViewModel = new MainViewModel
            {
                CurrentViewModel = LoginViewModel
            };

            base.OnStartup(e);
        }

    }

}
