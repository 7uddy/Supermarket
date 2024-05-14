using Supermarket.MVVM.Model.EntityLayer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.MVVM.Model.DataAccessLayer
{
    public class ProductCategoryDAL
    {
        public ObservableCollection<ProductCategory> GetAllProductCategories()
        {
           SqlConnection sqlConnection = DALHelper.Connection;
            try
            {
                SqlCommand sqlCommand = new SqlCommand("GetAllProductCategories", sqlConnection);
                ObservableCollection<ProductCategory> productsCategories = new ObservableCollection<ProductCategory>();
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                sqlConnection.Open();
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    ProductCategory productsCategory = new ProductCategory
                    {
                        CategoryID = sqlDataReader.GetInt32(0),
                        CategoryName = sqlDataReader.GetString(1)
                    };
                    productsCategories.Add(productsCategory);
                }
                sqlDataReader.Close();
                return productsCategories;
            }
            finally
            {
                sqlConnection.Close();
            }
        }

        public void InsertProductCategory(string insertProductCategoryName)
        {
           SqlConnection sqlConnection = DALHelper.Connection;
            try
            {
                SqlCommand sqlCommand = new SqlCommand("InsertProductCategory", sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                sqlCommand.Parameters.Add(new SqlParameter("@categoryName", insertProductCategoryName));
                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
            }
            finally
            {
                sqlConnection.Close();
            }
        }

        public void UpdateProductCategory(object id, string newProductCategoryName)
        {
           SqlConnection sqlConnection = DALHelper.Connection;
            try
            {
                SqlCommand sqlCommand = new SqlCommand("UpdateProductCategory", sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                sqlCommand.Parameters.Add(new SqlParameter("@categoryID", id));
                sqlCommand.Parameters.Add(new SqlParameter("@categoryName", newProductCategoryName));
                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
            }
            finally
            {
                sqlConnection.Close();
            }
        }

        public void DeleteProductCategory(int categoryID)
        {
            SqlConnection sqlConnection = DALHelper.Connection;
            try
            {
                SqlCommand sqlCommand = new SqlCommand("DeleteProductCategory", sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                sqlCommand.Parameters.Add(new SqlParameter("@categoryID", categoryID));
                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
            }
            finally
            {
                sqlConnection.Close();
            }
        }
    }
}
