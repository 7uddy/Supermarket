using GalaSoft.MvvmLight.Command;
using Supermarket.Commands;
using Supermarket.MVVM.Model.BusinessLogicLayer;
using Supermarket.MVVM.Model.DataAccessLayer;
using Supermarket.MVVM.Model.EntityLayer;
using Supermarket.Stores;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Supermarket.MVVM.ViewModel
{
    public class ProductsCategoryVM:ViewModelBase
    {
        public ICommand NavigateToAdmin { get; set; }
        public ProductsCategoryVM(Navigation navigation, Func<AdminVM> createAdminVM)
        {
            NavigateToAdmin = new NavigateCommand(navigation, createAdminVM);
            ProductsCategoriesList = productCategoryBLL.GetAllProductCategories();
        }

        public ObservableCollection<ProductCategory> ProductsCategoriesList { get; set; }
        ProductCategoryBLL productCategoryBLL = new ProductCategoryBLL();

        private ProductCategory _selectedProductCategory;
        public ProductCategory SelectedProductCategory
        {
            get => _selectedProductCategory;
            set
            {
                _selectedProductCategory = value;
                if (_selectedProductCategory != null)
                {
                    newProductCategoryName = _selectedProductCategory.CategoryName;
                }
                OnPropertyChanged(nameof(SelectedProductCategory));
            }
        }
        public Action CloseAction { get; internal set; }

        private string newProductCategoryName;
        public string NewProductCategoryName
        {
            get => newProductCategoryName;
            set
            {
                newProductCategoryName = value;
                OnPropertyChanged(nameof(NewProductCategoryName));
            }
        }

        private RelayCommand updateCommand;

        public ICommand UpdateCommand
        {
            get
            {
                if (updateCommand == null)
                {
                    updateCommand = new RelayCommand(Update);
                }

                return updateCommand;
            }
        }

        private void Update()
        {
            productCategoryBLL.UpdateProductCategory(SelectedProductCategory.CategoryID, newProductCategoryName);
            ProductsCategoriesList = productCategoryBLL.GetAllProductCategories();
            OnPropertyChanged(nameof(ProductsCategoriesList));
            CloseAction?.Invoke();
        }
        
        private string insertProductCategoryName;
        public string InsertName
        {
            get => insertProductCategoryName;
            set
            {
                insertProductCategoryName = value;
                OnPropertyChanged(nameof(InsertName));
            }
        }

        private RelayCommand insertCommand;

        public ICommand InsertCommand
        {
            get
            {
                if (insertCommand == null)
                {
                    insertCommand = new RelayCommand(Insert);
                }

                return insertCommand;
            }
        }
        private void Insert()
        {
            productCategoryBLL.InsertProductCategory(insertProductCategoryName);
            insertProductCategoryName="";
            ProductsCategoriesList = productCategoryBLL.GetAllProductCategories();
            OnPropertyChanged(nameof(ProductsCategoriesList));
            CloseAction?.Invoke();
        }

        private RelayCommand deleteProductCategory;
        public ICommand DeleteProductCategory
        {
            get
            {
                if (deleteProductCategory == null)
                {
                    deleteProductCategory = new RelayCommand(Delete);
                }

                return deleteProductCategory;
            }
        }

        private void Delete()
        {
            productCategoryBLL.DeleteProductCategory(SelectedProductCategory.CategoryID);
            ProductsCategoriesList = productCategoryBLL.GetAllProductCategories();
            OnPropertyChanged(nameof(ProductsCategoriesList));
            CloseAction?.Invoke();
        }
    }
}
