using Supermarket.Commands;
using Supermarket.MVVM.Model.BusinessLogicLayer;
using Supermarket.MVVM.Model;
using Supermarket.Stores;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Supermarket.MVVM.Model.EntityLayer;
using GalaSoft.MvvmLight.Command;
using System.Windows;

namespace Supermarket.MVVM.ViewModel
{
    public class ProductVM:ViewModelBase
    {
        public ICommand NavigateToAdmin { get; set; }

        public ProductVM(Navigation navigation, Func<AdminVM> createAdminVM)
        {
            NavigateToAdmin = new NavigateCommand(navigation, createAdminVM);
            _productsList = productBLL.GetAllProducts();
            UpdateProducers();
            UpdateCategories();
        }

        ProductBLL productBLL = new ProductBLL();

        private ObservableCollection<Product> _productsList;
        public ObservableCollection<Product> ProductsList
        {
            get => _productsList;
            set => _productsList = value;
        }

        private Product _selectedProduct;
        public Product SelectedProduct
        {
            get => _selectedProduct;
            set
            {
                _selectedProduct = value;
                if (_selectedProduct != null)
                {
                    newProductName = _selectedProduct.Name;
                    newBarcode=_selectedProduct.Barcode;
                    newIdProducer=_selectedProduct.IdProducer;
                    newIdCategory = _selectedProduct.IdCategory;
                }
                OnPropertyChanged(nameof(SelectedProduct));
            }
        }
        private string newProductName;
        public string NewProductName
        {
            get => newProductName;
            set
            {
                newProductName = value;
                OnPropertyChanged(nameof(NewProductName));
            }
        }
        private int newIdProducer;
        public int NewIdProducer
        {
            get => newIdProducer;
            set
            {
                newIdProducer = value;
                OnPropertyChanged(nameof(NewIdProducer));
            }
        }
        private string newBarcode;
        public string NewBarcode
        {
            get => newBarcode;
            set
            {
                newBarcode = value;
                OnPropertyChanged(nameof(NewBarcode));
            }
        }
        private int newIdCategory;
        public int NewIdCategory
        {
            get => newIdCategory;
            set
            {
                newIdCategory = value;
                OnPropertyChanged(nameof(NewIdCategory));
            }
        }
        private string _insertName;
        public string InsertName
        {
            get => _insertName;
            set
            {
                _insertName = value;
                OnPropertyChanged(nameof(InsertName));
            }
        }
        private string _insertBarcode;
        public string InsertBarcode
        {
            get => _insertBarcode;
            set
            {
                _insertBarcode = value;
                OnPropertyChanged(nameof(InsertBarcode));
            }
        }
        private int _insertIdProducer;
        public int InsertIdProducer
        {
            get => _insertIdProducer;
            set
            {
                _insertIdProducer = value;
                OnPropertyChanged(nameof(InsertIdProducer));
            }
        }
        private int _insertIdCategory;
        public int InsertIdCategory
        {
            get => _insertIdCategory;
            set
            {
                _insertIdCategory = value;
                OnPropertyChanged(nameof(InsertIdCategory));
            }
        }

        private ProducerBLL producerBLL= new ProducerBLL();

        private ObservableCollection<KeyValuePair<int, string>> _producerId;
        public ObservableCollection<KeyValuePair<int, string>> ProducerId
        {
            get => _producerId;
            set => _producerId = value;
        }

        private void UpdateProducers()
        {
            foreach (Producer producer in producerBLL.GetAllProducers())
            {
                if (_producerId==null)
                {
                    _producerId = new ObservableCollection<KeyValuePair<int, string>>();
                }
                _producerId.Add(new KeyValuePair<int, string>(producer.Id, producer.Name));
            }
        }

        private ProductCategoryBLL categoryBLL= new ProductCategoryBLL();

        private ObservableCollection<KeyValuePair<int, string>> _categoryId;
        public ObservableCollection<KeyValuePair<int, string>> CategoryId
        {
            get => _categoryId;
            set => _categoryId = value;
        }

        private void UpdateCategories()
        {
            foreach (ProductCategory category in categoryBLL.GetAllProductCategories())
            {
                if(_categoryId==null)
                {
                    _categoryId = new ObservableCollection<KeyValuePair<int, string>>();
                }
                _categoryId.Add(new KeyValuePair<int, string>(category.CategoryID, category.CategoryName));
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
                        if(InsertName==null || InsertBarcode==null || InsertIdProducer==0 || InsertIdCategory==0)
                        {
                            MessageBox.Show("Please fill all fields.", "Error", 
                                MessageBoxButton.OK, MessageBoxImage.Error);
                            return;
                        }
                        productBLL.InsertProduct(InsertName, InsertBarcode, InsertIdProducer, InsertIdCategory);
                        InsertName = null;
                        InsertBarcode = null;
                        InsertIdProducer = 0;
                        InsertIdCategory = 0;
                        ProductsList = productBLL.GetAllProducts();
                        OnPropertyChanged(nameof(ProductsList));
                        CloseAction?.Invoke();
                    });
                }
                return _insertCommand;
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
                        productBLL.DeleteProduct(SelectedProduct.Id);
                        ProductsList = productBLL.GetAllProducts();
                        OnPropertyChanged(nameof(ProductsList));
                    });
                }
                return _deleteCommand;
            }
        }

        private RelayCommand _updateCommand;
        public ICommand UpdateCommand
        {
            get
            {
                if (_updateCommand == null)
                {
                    _updateCommand = new RelayCommand(() =>
                    {
                        if(NewProductName==null || NewBarcode==null || NewIdProducer==0 || NewIdCategory==0)
                        {
                            MessageBox.Show("Please fill all fields.", "Error", 
                                                               MessageBoxButton.OK, MessageBoxImage.Error);
                            return;
                        }
                        productBLL.UpdateProduct(SelectedProduct.Id, NewProductName, NewBarcode, NewIdProducer, NewIdCategory);
                        ProductsList = productBLL.GetAllProducts();
                        OnPropertyChanged(nameof(ProductsList));
                        CloseAction?.Invoke();
                    });
                }
                return _updateCommand;
            }
        }

        public Action CloseAction { get; internal set; }
    }
}
