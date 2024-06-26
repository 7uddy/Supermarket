﻿using Supermarket.MVVM.Model.EntityLayer;
using System.Collections.ObjectModel;
using System.Data.SqlClient;

namespace Supermarket.MVVM.Model.DataAccessLayer
{
    public class ReceiptDAL
    {
        public ObservableCollection<Receipt> GetAllReceipts()
        {
            SqlConnection connection = DALHelper.Connection;
            try
            {
                SqlCommand cmd = new SqlCommand("GetAllReceipts", connection);
                ObservableCollection<Receipt> receipts = new ObservableCollection<Receipt>();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Receipt receipt = new Receipt
                    {
                        Id = reader.GetInt32(0),
                        Date = reader.GetDateTime(1),
                        CashierId = reader.GetInt32(2),
                        CashierName = reader.GetString(3),
                        TotalAmount = reader.GetDecimal(4)
                    };
                    receipts.Add(receipt);
                }
                reader.Close();
                return receipts;
            }
            finally
            {
                connection.Close();
            }
        }

        public int CreateReceipt(Receipt receipt)
        {
            SqlConnection connection = DALHelper.Connection;
            try
            {
                SqlCommand cmd = new SqlCommand("CreateReceipt", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@date", receipt.Date));
                cmd.Parameters.Add(new SqlParameter("@cashierId", receipt.CashierId));
                cmd.Parameters.Add(new SqlParameter("@totalAmount", receipt.TotalAmount));
                connection.Open();
                return (int)cmd.ExecuteScalar();
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
