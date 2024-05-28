using GalaSoft.MvvmLight.Command;
using Supermarket.Commands;
using Supermarket.MVVM.Model.BusinessLogicLayer;
using Supermarket.MVVM.Model.EntityLayer;
using Supermarket.Stores;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace Supermarket.MVVM.ViewModel
{
    public class StockVM:ViewModelBase
    {
        private int kCommercialExcess;

        private StockBLL stockBLL = new StockBLL();

        private ObservableCollection<Stock> _stockList;
        public ObservableCollection<Stock> StockList
        {
            get
            {
                return _stockList;
            }
            set
            {
                _stockList = value;
                OnPropertyChanged("StockList");
            }
        }

        public ICommand NavigateToAdmin { get; set; }
        public StockVM(Navigation navigation, Func<AdminVM> createAdminVM)
        {
            NavigateToAdmin = new NavigateCommand(navigation, createAdminVM);
            _stockList = stockBLL.GetAllStock();
            UpdateProducts();
            kCommercialExcess = ReadFromFile();
        }

        private Stock _selectedStock;
        public Stock SelectedStock
        {
            get
            {
                return _selectedStock;
            }
            set
            {
                _selectedStock = value;
                if (_selectedStock != null)
                {
                    NewProductId = _selectedStock.ProductID;
                    NewQuantity = _selectedStock.Quantity;
                    NewSupplyDate = _selectedStock.SupplyDate;
                    NewExpirationDate = _selectedStock.ExpirationDate;
                    NewSalePrice = _selectedStock.SalePrice;
                }
                OnPropertyChanged("SelectedStock");
            }
        }

        ProductBLL productBLL = new ProductBLL();
        private ObservableCollection<KeyValuePair<int,string>> _productsList;
        public ObservableCollection<KeyValuePair<int,string>> ProductsList
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
                if(_productsList==null)
                {
                    _productsList = new ObservableCollection<KeyValuePair<int, string>>();
                }
                _productsList.Add(new KeyValuePair<int, string>(product.Id, product.Name));
            }
        }

        private int _selectedProductId;
        public int SelectedProductId
        {
            get
            {
                return _selectedProductId;
            }
            set
            {
                _selectedProductId = value;
                OnPropertyChanged("SelectedProductId");
            }
        }

        private string _insertQuantity;
        public string InsertQuantity
        {
            get
            {
                return _insertQuantity;
            }
            set
            {
                if (value.All(char.IsDigit) || string.IsNullOrEmpty(value))
                {
                    _insertQuantity = value; 
                }
                OnPropertyChanged("InsertQuantity");
            }
        }

        private DateTime _insertSupplyDate= DateTime.Today;
        public DateTime InsertSupplyDate
        {
            get
            {
                return _insertSupplyDate;
            }
            set
            {
                _insertSupplyDate = value;
                OnPropertyChanged("InsertSupplyDate");
            }
        }

        private DateTime _insertExpirationDate = DateTime.Today;
        public DateTime InsertExpirationDate
        {
            get
            {
                return _insertExpirationDate;
            }
            set
            {
                if(value.CompareTo(_insertSupplyDate) < 0)
                {
                    MessageBox.Show("The expiration date must be after the supply date.", "Error", 
                                                                      MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                _insertExpirationDate = value;
                OnPropertyChanged("InsertExpirationDate");
            }
        }

        private string _insertPurchasePrice;
        public string InsertPurchasePrice
        {
            get
            {
                return _insertPurchasePrice;
            }
            set
            {
                if (value.All(char.IsDigit) && !string.IsNullOrEmpty(value))
                {
                    _insertPurchasePrice = value;
                    double commercialExcessPercentage = kCommercialExcess / 100.0;

                    // Calculate the sale price
                    double purchasePrice = double.Parse(value);
                    double salePrice = purchasePrice + (commercialExcessPercentage * purchasePrice);

                    _insertSalePrice = salePrice.ToString("F2");
                    OnPropertyChanged("InsertPurchasePrice");
                    OnPropertyChanged("InsertSalePrice");
                }
                else if (string.IsNullOrEmpty(value))
                {
                    _insertPurchasePrice = value;
                    _insertSalePrice = value;
                    OnPropertyChanged("InsertPurchasePrice");
                    OnPropertyChanged("InsertSalePrice");
                }
            }
        }

        private string _insertSalePrice;
        public string InsertSalePrice
        {
            get
            {
                return _insertSalePrice;
            }
            set
            {
                _insertSalePrice = value;
                OnPropertyChanged("InsertSalePrice");

            }
        }

        private RelayCommand _insertCommand;
        public ICommand InsertCommand
        {
            get
            {
                if (_insertCommand == null)
                {
                    _insertCommand = new RelayCommand(() =>
                    {
                        if (SelectedProductId == 0 || string.IsNullOrEmpty(InsertQuantity) || InsertQuantity=="0"|| InsertPurchasePrice=="0"||
                        string.IsNullOrEmpty(InsertPurchasePrice)|| _insertSupplyDate.CompareTo(_insertExpirationDate) > 0)
                        {
                            MessageBox.Show("Please check all fields.", "Error", 
                                MessageBoxButton.OK, MessageBoxImage.Error);
                            return;
                        }
                        stockBLL.InsertStock(SelectedProductId, int.Parse(InsertQuantity), InsertSupplyDate, InsertExpirationDate, decimal.Parse(InsertPurchasePrice), decimal.Parse(InsertSalePrice));
                        SelectedProductId= 0;
                        InsertQuantity = "";
                        InsertPurchasePrice = "";
                        InsertSalePrice = "";
                        InsertSupplyDate= DateTime.Today;
                        InsertExpirationDate = DateTime.Today;
                        StockList = stockBLL.GetAllStock();
                        OnPropertyChanged("StockList");
                        CloseAction?.Invoke();
                    });
                }
                return _insertCommand;
            }
        }

        private int _newProductId;
        public int NewProductId
        {
            get
            {
                return _newProductId;
            }
            set
            {
                _newProductId = value;
                OnPropertyChanged("NewProductId");
            }
        }
        private int _newQuantity;
        public int NewQuantity
        {
            get
            {
                return _newQuantity;
            }
            set
            {
                _newQuantity = value;
                OnPropertyChanged("NewQuantity");
            }
        }
        private DateTime _newSupplyDate;
        public DateTime NewSupplyDate
        {
            get
            {
                return _newSupplyDate;
            }
            set
            {
                _newSupplyDate = value;
                OnPropertyChanged("NewSupplyDate");
            }
        }
        private DateTime _newExpirationDate;
        public DateTime NewExpirationDate
        {
            get
            {
                return _newExpirationDate;
            }
            set
            {
                if(value.CompareTo(_newSupplyDate) < 0)
                {
                    MessageBox.Show("The expiration date must be after the supply date.", "Error", 
                                               MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                _newExpirationDate = value;
                OnPropertyChanged("NewExpirationDate");
            }
        }
        public decimal NewPurchasePrice
        {
            get
            {
                return _selectedStock.PurchasePrice;
            }
        }
        private decimal _newSalePrice;
        public decimal NewSalePrice
        {
            get
            {
                return _newSalePrice;
            }
            set
            {
                _newSalePrice = value;
                OnPropertyChanged("NewSalePrice");
            }
        }

        public RelayCommand updateCommand;
        public ICommand UpdateCommand
        {
            get
            {
                if (updateCommand == null)
                {
                    updateCommand = new RelayCommand(() =>
                    {
                        if (NewProductId == 0 || NewQuantity == 0 || NewSalePrice == 0|| NewSalePrice<NewPurchasePrice ||
                        _newSupplyDate.CompareTo(_newExpirationDate)>0)
                        {
                            MessageBox.Show("Please verify all the fields.", "Error", 
                                MessageBoxButton.OK, MessageBoxImage.Error);
                            return;
                        }
                        stockBLL.UpdateStock(SelectedStock.StockID, NewProductId, NewQuantity, NewSupplyDate, NewExpirationDate, NewSalePrice);
                        StockList = stockBLL.GetAllStock();
                        OnPropertyChanged("StockList");
                        CloseAction?.Invoke();
                    });
                }
                return updateCommand;
            }
        }

        private RelayCommand _deleteCommand;
        public ICommand DeleteCommand
        {
            get
            {
                if (_deleteCommand == null)
                {
                    _deleteCommand = new RelayCommand(() =>
                    {
                        stockBLL.DeleteStock(SelectedStock.StockID);
                        StockList = stockBLL.GetAllStock();
                        OnPropertyChanged("StockList");
                    });
                }
                return _deleteCommand;
            }
        }

        public Action CloseAction { get; internal set; }
        private int ReadFromFile()
        {
            try
            {
                string content = File.ReadAllText("../../Resources/CommercialExcess.txt");

                if (int.TryParse(content, out int result))
                {
                    return result;
                }
                else
                {
                    throw new FormatException("The file does not contain a valid integer.");
                }
            }
            catch (FileNotFoundException)
            {
                throw new FileNotFoundException("The specified file was not found.");
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while reading the file.", ex);
            }
        }
    }
}
