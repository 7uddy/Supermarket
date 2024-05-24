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
    public class ReceiptProductDAL
    {
        public ObservableCollection<ReceiptProduct> GetReceiptProducts(Receipt selectedReceipt)
        {
            SqlConnection connection = DALHelper.Connection;
            try
            {
                SqlCommand command = new SqlCommand("GetReceiptProducts", connection);
                ObservableCollection<ReceiptProduct> receiptProducts = new ObservableCollection<ReceiptProduct>();
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@receiptId", selectedReceipt.Id));
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
    }
}
