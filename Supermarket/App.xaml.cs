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
            return new AdminVM(_navigation,CreateUserViewModel,CreateProductVM,CreateCategoryVM,
                CreateProducerViewModel,CreateStockVM);
        }

        private ProductsCategoryVM CreateCategoryVM()
        {
            return new ProductsCategoryVM(_navigation,CreateAdminViewModel);
        }

        private ProductVM CreateProductVM()
        {
            return new ProductVM(_navigation,CreateAdminViewModel);
        }

        private ProducerVM CreateProducerViewModel()
        {
            return new ProducerVM(_navigation,CreateAdminViewModel);
        }

        private StockVM CreateStockVM()
        {
            return new StockVM(_navigation,CreateAdminViewModel);
        }
        private UserVM CreateUserViewModel()
        {
            return new UserVM(_navigation,CreateAdminViewModel,CreateUserMonthEarningsViewModel);
        }

        private ReceiptVM CreateReceiptViewModel()
        {
            return new ReceiptVM();
        }

        private CreateReceiptVM CreateCreateReceiptViewModel()
        {
            return new CreateReceiptVM(_navigation,CreateCashierViewModel);
        }

        private UserMonthEarningsVM CreateUserMonthEarningsViewModel()
        {
            return new UserMonthEarningsVM(_navigation,CreateUserViewModel);
        }

        private CashierVM CreateCashierViewModel()
        {
            return new CashierVM(_navigation,CreateReceiptViewModel, CreateCreateReceiptViewModel);
        }
    }
}
