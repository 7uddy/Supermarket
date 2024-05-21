﻿using Supermarket.MVVM.Model.DataAccessLayer;
using Supermarket.MVVM.Model.EntityLayer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.MVVM.Model.BusinessLogicLayer
{
    public class StockBLL
    {
        private ObservableCollection<Stock> stockList;
        private StockDAL stockDAL = new StockDAL();

        public ObservableCollection<Stock> GetAllStock()
        {
            return stockDAL.GetAllStock();
        }

        public void InsertStock(int selectedProductId, int quantity, DateTime insertSupplyDate, DateTime insertExpirationDate, decimal purchasePrice, decimal sellPrice)
        {
            stockDAL.InsertStock(selectedProductId, quantity, insertSupplyDate, insertExpirationDate, purchasePrice, sellPrice);
        }

        public void UpdateStock(int stockID, int newProductId, int newQuantity, DateTime newSupplyDate, DateTime newExpirationDate, decimal newSalePrice)
        {
            stockDAL.UpdateStock(stockID, newProductId, newQuantity, newSupplyDate, newExpirationDate, newSalePrice);
        }

        public void DeleteStock(int stockID)
        {
            stockDAL.DeleteStock(stockID);
        }
    }
}