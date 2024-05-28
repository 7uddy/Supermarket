using Supermarket.MVVM.Model.EntityLayer;
using System;
using System.Collections.ObjectModel;
using System.Data.SqlClient;

namespace Supermarket.MVVM.Model.DataAccessLayer
{
    public class ReceiptProductDAL
    {
        public ObservableCollection<ReceiptProduct> GetReceiptProducts(int id)
        {
            SqlConnection connection = DALHelper.Connection;
            try
            {
                SqlCommand command = new SqlCommand("GetReceiptProducts", connection);
                ObservableCollection<ReceiptProduct> receiptProducts = new ObservableCollection<ReceiptProduct>();
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@receiptId", id));
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    ReceiptProduct receiptProduct = new ReceiptProduct
                    {
                        ProductName = reader.GetString(0),
                        Quantity = reader.GetInt32(1),
                        Price = reader.GetDecimal(2)
                    };
 //                 receiptProduct.Price= receiptProduct.Price / receiptProduct.Quantity;
                    receiptProducts.Add(receiptProduct);
                }
                reader.Close();
                return receiptProducts;
            }
            finally
            {
                connection.Close();
            }


        }

        public void CreateReceiptProduct(int receiptId, ReceiptProduct receiptProduct)
        {
            SqlConnection connection = DALHelper.Connection;
            try
            {
                SqlCommand command = new SqlCommand("CreateReceiptProduct", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@receiptId", receiptId));
                command.Parameters.Add(new SqlParameter("@productId", receiptProduct.ProductId));
                command.Parameters.Add(new SqlParameter("@quantity", receiptProduct.Quantity));
                command.Parameters.Add(new SqlParameter("@price", receiptProduct.Price));
                connection.Open();
                command.ExecuteNonQuery();
            }
            finally
            {
                connection.Close();
            }
        }

        public int GetHighestReceiptId(DateTime date)
        {
            SqlConnection connection = DALHelper.Connection;
            try
            {
                SqlCommand command = new SqlCommand("GetHighestReceiptId", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@date", date));
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    return reader.GetInt32(0);
                }
                return 0;
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
