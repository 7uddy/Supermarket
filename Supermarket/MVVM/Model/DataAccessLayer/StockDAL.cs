﻿using Supermarket.MVVM.Model.EntityLayer;
using System;
using System.Collections.ObjectModel;
using System.Data.SqlClient;

namespace Supermarket.MVVM.Model.DataAccessLayer
{
    public class StockDAL
    {
        public ObservableCollection<Stock> GetAllStock()
        {
            SqlConnection connection = DALHelper.Connection;
            try
            {
                SqlCommand cmd = new SqlCommand("GetAllStock", connection);
                ObservableCollection<Stock> stocks = new ObservableCollection<Stock>();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Stock stock = new Stock
                    {
                        StockID = reader.GetInt32(0),
                        ProductID = reader.GetInt32(1),
                        ProductName = reader.GetString(2),
                        Quantity = reader.GetInt32(3),
                        SupplyDate = reader.GetDateTime(4),
                        ExpirationDate = reader.GetDateTime(5),
                        PurchasePrice = reader.GetDecimal(6),
                        SalePrice = reader.GetDecimal(7)
                    };
                    stocks.Add(stock);
                }
                reader.Close();
                return stocks;
            }
            finally
            {
                connection.Close();
            }
        }

        public void InsertStock(int selectedProductId, int quantity, DateTime insertSupplyDate, DateTime insertExpirationDate, decimal purchasePrice, decimal sellPrice)
        {
            SqlConnection connection = DALHelper.Connection;
            try
            {
                SqlCommand cmd = new SqlCommand("InsertStock", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@productID", selectedProductId));
                cmd.Parameters.Add(new SqlParameter("@quantity", quantity));
                cmd.Parameters.Add(new SqlParameter("@supplyDate", insertSupplyDate));
                cmd.Parameters.Add(new SqlParameter("@expirationDate", insertExpirationDate));
                cmd.Parameters.Add(new SqlParameter("@purchasePrice", purchasePrice));
                cmd.Parameters.Add(new SqlParameter("@salePrice", sellPrice));
                connection.Open();
                cmd.ExecuteNonQuery();
            }
            finally
            {
                connection.Close();
            }
        }

        public void UpdateStock(int stockID, int newProductId, int newQuantity, DateTime newSupplyDate, DateTime newExpirationDate, decimal newSalePrice)
        {
            SqlConnection connection = DALHelper.Connection;
            try
            {
                SqlCommand cmd = new SqlCommand("UpdateStock", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@stockID", stockID));
                cmd.Parameters.Add(new SqlParameter("@productID", newProductId));
                cmd.Parameters.Add(new SqlParameter("@quantity", newQuantity));
                cmd.Parameters.Add(new SqlParameter("@supplyDate", newSupplyDate));
                cmd.Parameters.Add(new SqlParameter("@expirationDate", newExpirationDate));
                cmd.Parameters.Add(new SqlParameter("@salePrice", newSalePrice));
                connection.Open();
                cmd.ExecuteNonQuery();
            }
            finally
            {
                connection.Close();
            }
        }

        public void DeleteStock(int stockID)
        {
            SqlConnection connection = DALHelper.Connection;
            try
            {
                SqlCommand cmd = new SqlCommand("DeleteStock", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@stockID", stockID));
                connection.Open();
                cmd.ExecuteNonQuery();
            }
            finally
            {
                connection.Close();
            }
        }

        public decimal GetProductPriceAndCheckStock(int insertProductId,int insertQuantity)
        {
            SqlConnection connection = DALHelper.Connection;
            try
            {
                SqlCommand cmd = new SqlCommand("GetProductPriceAndCheckStock", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@productID", insertProductId));
                cmd.Parameters.Add(new SqlParameter("@quantity", insertQuantity));
                connection.Open();
                return Convert.ToDecimal(cmd.ExecuteScalar());
            }
            finally
            {
                connection.Close();
            }
        }

        public void UpdateStockQuantity(int productId, int quantity)
        {
            SqlConnection connection = DALHelper.Connection;
            try
            {
                SqlCommand cmd = new SqlCommand("UpdateStockQuantity", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@productID", productId));
                cmd.Parameters.Add(new SqlParameter("@quantity", quantity));
                connection.Open();
                cmd.ExecuteNonQuery();
            }
            finally
            {
                connection.Close();
            }
        }

        public void CleanStocks()
        {
            SqlConnection connection = DALHelper.Connection;
            try
            {
                SqlCommand cmd = new SqlCommand("CleanStocks", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                connection.Open();
                cmd.ExecuteNonQuery();
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
