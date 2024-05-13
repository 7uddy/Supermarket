using Supermarket.MVVM.Model.DataAccessLayer;
using Supermarket.MVVM.Model.EntityLayer;
using System.Collections.ObjectModel;

namespace Supermarket.MVVM.Model.BusinessLogicLayer
{
    public class ProductBLL
    {
        public ObservableCollection<Product> ProductsList { get; set; }
        ProductDAL productDAL = new ProductDAL();

        public ObservableCollection<Product> GetAllProducts()
        {
            return productDAL.GetAllProducts();
        }
    }
}
