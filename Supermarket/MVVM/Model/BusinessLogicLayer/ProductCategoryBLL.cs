using Supermarket.MVVM.Model.DataAccessLayer;
using Supermarket.MVVM.Model.EntityLayer;
using System.Collections.ObjectModel;

namespace Supermarket.MVVM.Model.BusinessLogicLayer
{
    public class ProductCategoryBLL
    {
        public ObservableCollection<ProductCategory> ProductCategoryList { get; set; }
        ProductCategoryDAL productCategoryDAL = new ProductCategoryDAL();

        public ObservableCollection<ProductCategory> GetAllProductCategories()
        {
            return productCategoryDAL.GetAllProductCategories();
        }

        public void InsertProductCategory(string insertProductCategoryName)
        {
            productCategoryDAL.InsertProductCategory(insertProductCategoryName);
        }

        public void UpdateProductCategory(object id, string newProductCategoryName)
        {
            productCategoryDAL.UpdateProductCategory(id, newProductCategoryName);
        }

        internal void DeleteProductCategory(int categoryID)
        {
            productCategoryDAL.DeleteProductCategory(categoryID);
        }
    }
}
