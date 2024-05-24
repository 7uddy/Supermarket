﻿using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using Supermarket.Commands;
using Supermarket.MVVM.Model.BusinessLogicLayer;
using Supermarket.MVVM.Model.EntityLayer;
using Supermarket.Stores;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Supermarket.MVVM.ViewModel
{
    public class CreateReceiptVM:ViewModelBase
    {
        public ICommand NavigateToCashier { get; set; }

        public CreateReceiptVM(Navigation navigation,Func<CashierVM>createCashierVM)
        {
           NavigateToCashier = new NavigateCommand(navigation, createCashierVM);
           UpdateProducts();
        }

        private ObservableCollection<ReceiptProduct> _addedProductsList=new ObservableCollection<ReceiptProduct>();
        public ObservableCollection<ReceiptProduct> AddedProductsList
        {
            get => _addedProductsList;
            set
            {
                _addedProductsList = value;
                OnPropertyChanged("AddedProductsList");
            }
        }

        private ReceiptProduct _selectedProduct;
        public ReceiptProduct SelectedProduct
        {
            get => _selectedProduct;
            set
            {
                _selectedProduct = value;
                OnPropertyChanged("SelectedProduct");
            }
        }

        private ProductBLL productBLL = new ProductBLL();
        private ObservableCollection<KeyValuePair<int, string>> _productsList;
        public ObservableCollection<KeyValuePair<int, string>> ProductsList
        {
            get
            {
                return _productsList;
            }
            set
            {
                _productsList = value;
                OnPropertyChanged("ProductList");
            }
        }

        public void UpdateProducts()
        {
            foreach (Product product in productBLL.GetAllProducts())
            {
                if (_productsList == null)
                {
                    _productsList = new ObservableCollection<KeyValuePair<int, string>>();
                }
                _productsList.Add(new KeyValuePair<int, string>(product.Id, product.Name));
            }
        }

        private int _insertProductId;
        public int InsertProductId
        {
            get => _insertProductId;
            set
            {
                _insertProductId = value;
                OnPropertyChanged("InsertProductId");
            }
        }

        private int _insertQuantity;
        public int InsertQuantity
        {
            get => _insertQuantity;
            set
            {
                _insertQuantity = value;
                OnPropertyChanged("InsertQuantity");
            }
        }

        private StockBLL stockBLL = new StockBLL();

        private RelayCommand _addProduct;
        public RelayCommand AddProduct
        {
            get
            {
                return _addProduct ?? (_addProduct = new RelayCommand(() =>
                {
                    decimal InsertPrice = stockBLL.GetProductPriceAndCheckStock(InsertProductId, InsertQuantity);
                    if(InsertPrice==0 || InsertQuantity==0)
                    {
                        MessageBox.Show("There isn't enough stock for the selected product", "Error", 
                            MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                    _addedProductsList.Add(new ReceiptProduct
                    {
                        ProductId = InsertProductId,
                        ProductName = ProductsList.Where(x => x.Key == InsertProductId).Select(x => x.Value).FirstOrDefault(),
                        Quantity = InsertQuantity,
                        Price = InsertPrice*InsertQuantity
                    });
                    InsertProductId = 0;
                    InsertQuantity = 0;
                    OnPropertyChanged("TotalAmount");
                    CloseAction?.Invoke();
                }));
            }
        }

        private RelayCommand _deleteCommand;
        public RelayCommand DeleteCommand
        {
            get
            {
                return _deleteCommand ?? (_deleteCommand = new RelayCommand(() =>
                {
                    _addedProductsList.Remove(SelectedProduct);
                    OnPropertyChanged("TotalAmount");
                }));
            }
        }

        public decimal TotalAmount
        {
            get => _addedProductsList.Sum(x => x.Price);
        }

        private RelayCommand _createReceiptCommand;
        public RelayCommand CreateReceiptCommand
        {
            get
            {
                return _createReceiptCommand ?? (_createReceiptCommand = new RelayCommand(() =>
                {
                    Receipt receipt = new Receipt
                    {
                        Date = DateTime.Now,
                        CashierId = App._user.Id,
                        CashierName = App._user.Username,
                        TotalAmount = TotalAmount
                    };
                    ReceiptBLL receiptBLL = new ReceiptBLL();
                    receiptBLL.CreateReceipt(receipt, _addedProductsList);
                    MessageBox.Show("Receipt created successfully", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    _addedProductsList.Clear();
                    OnPropertyChanged("TotalAmount");
                }));
            }
        }

        public Action CloseAction { get; internal set; }
    }
}
