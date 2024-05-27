using GalaSoft.MvvmLight.Command;
using Supermarket.Commands;
using Supermarket.MVVM.Model.BusinessLogicLayer;
using Supermarket.MVVM.Model.EntityLayer;
using Supermarket.Stores;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace Supermarket.MVVM.ViewModel
{
    public class CashierVM:ViewModelBase
    {
        public ICommand NavigateToReceipt { get; set; }
        public ICommand NavigateToCreateReceipt { get; set; }
        public ICommand NavigateToLogin { get; set; }
        public CashierVM(Navigation navigation,Func<ReceiptVM> createReceiptVM,Func<CreateReceiptVM> createCreateReceiptVM,
            Func<LoginVM> createLoginVM)
        {
            NavigateToReceipt = new NavigateCommand(navigation, createReceiptVM);
            NavigateToCreateReceipt = new NavigateCommand(navigation, createCreateReceiptVM);
            NavigateToLogin = new NavigateCommand(navigation, createLoginVM);
        }

        public string CashierName
        {
            get => App._user.Username;
        }

        private string _searchBar;
        public string SearchBar
        {
            get => _searchBar;
            set
            {
                _searchBar = value;
                OnPropertyChanged("SearchBar");
            }
        }

        private Product _searchedProduct;
        public Product SearchedProduct
        {
            get => _searchedProduct;
            set
            {
                _searchedProduct = value;
                OnPropertyChanged("SearchedProduct");
            }
        }

        private RelayCommand _searchCommand;
        public RelayCommand SearchCommand
        {
            get
            {
                return _searchCommand ?? (_searchCommand = new RelayCommand(() =>
                {
                    if(_searchBar==null)
                    {
                        MessageBox.Show("Please enter a product name","Error",MessageBoxButton.OK,MessageBoxImage.Error);
                        return;
                    }
                    ProductBLL productBLL = new ProductBLL();
                    if(_searchBar.All(char.IsDigit))
                    {
                        if (long.TryParse(_searchBar, out long barcode))
                        {
                            Product possibleProduct = productBLL.GetProductByBarcode(barcode);
                            if (possibleProduct!=null)
                            {
                                SearchedProduct = possibleProduct;
                                return;
                            }
                        }
                    }
                    else if (DateTime.TryParse(_searchBar, out DateTime date))
                    {
                        Product possibleProduct=productBLL.GetProductByDate(date);
                        if (possibleProduct != null)
                        {
                            SearchedProduct = possibleProduct;
                            return;
                        }
                    }
                    else
                    {
                        if(productBLL.GetProductByName(_searchBar) != null)
                        {
                            SearchedProduct = productBLL.GetProductByName(_searchBar);
                            return;
                        }
                        else if(productBLL.GetProductByCategory(_searchBar) != null)
                        {
                            SearchedProduct = productBLL.GetProductByCategory(_searchBar);
                            return;
                        }
                        else if(productBLL.GetProductByProducer(_searchBar) != null)
                        {
                            SearchedProduct = productBLL.GetProductByProducer(_searchBar);
                            return;
                        }
                        else
                        {
                            MessageBox.Show("Product not found","Error",MessageBoxButton.OK,MessageBoxImage.Error);
                            return;
                        }
                    }
                }));
            }
        }

        private RelayCommand _logoutCommand;
        public RelayCommand LogoutCommand
        {
            get
            {
                return _logoutCommand ?? (_logoutCommand = new RelayCommand(() =>
                {
                    App._user = null;
                    NavigateToLogin.Execute(null);
                }));
            }
        }
    }
}
