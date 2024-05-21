using Supermarket.MVVM.Model.DataAccessLayer;
using Supermarket.MVVM.Model.EntityLayer;
using System;
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

        public void InsertProduct(string insertName, string insertBarcode, int insertIdProducer, int insertIdCategory)
        {
            productDAL.InsertProduct(insertName, insertBarcode, insertIdProducer, insertIdCategory);
        }

        public void DeleteProduct(int id)
        {
            productDAL.DeleteProduct(id);
        }

        public void UpdateProduct(int id, string newProductName, string newBarcode, int newIdProducer, int newIdCategory)
        {
            productDAL.UpdateProduct(id, newProductName, newBarcode, newIdProducer, newIdCategory);
        }
    }
}
