using Supermarket.MVVM.Model;
using Supermarket.MVVM.ViewModel;
using Supermarket.Stores;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Supermarket
{
    public partial class App : Application
    {
        private readonly Navigation _navigation = new Navigation();
        public static User _user;
        protected override void OnStartup(StartupEventArgs e)
        {
            _navigation.CurrentViewModel = CreateLoginViewModel();
            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(_navigation)
            };
            MainWindow.Show();
            base.OnStartup(e);
        }

        private LoginVM CreateLoginViewModel()
        {
            return new LoginVM(_navigation,CreateAdminViewModel,CreateCashierViewModel);
        }

        private AdminVM CreateAdminViewModel()
        {
            return new AdminVM(_navigation,CreateUserViewModel);
        }

        private UserVM CreateUserViewModel()
        {
            return new UserVM(_navigation,CreateAdminViewModel);
        }

        private CashierVM CreateCashierViewModel()
        {
            return new CashierVM();
        }
    }
}
