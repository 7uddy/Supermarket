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

namespace Supermarket.MVVM.ViewModel
{
    public class ProductVM:ViewModelBase
    {
        public ICommand NavigateToAdmin { get; set; }

        public ProductVM(Navigation navigation, Func<AdminVM> createAdminVM)
        {
            NavigateToAdmin = new NavigateCommand(navigation, createAdminVM);
            _productsList = productBLL.GetAllProducts();
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

        public Action CloseAction { get; internal set; }
    }
}
