using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.MVVM.Model.EntityLayer
{
    public class Stock
    {
        private int _stockID;
        public int StockID
        {
            get { return _stockID; }
            set { _stockID = value; }
        }
     
        private int _productID;
        public int ProductID
        {
            get { return _productID; }
            set { _productID = value; }
        } 

        private string _productName;
        public string ProductName
        {
            get { return _productName; }
            set { _productName = value; }
        }

        private int _quantity;
        public int Quantity
        {
            get { return _quantity; }
            set { _quantity = value; }
        }

        private DateTime _supplyDate;
        public DateTime SupplyDate
        {
            get { return _supplyDate; }
            set { _supplyDate = value; }
        }
        
        private DateTime _expirationDate;
        public DateTime ExpirationDate
        {
            get { return _expirationDate; }
            set { _expirationDate = value; }
        }

        private Decimal _purchasePrice;
        public Decimal PurchasePrice
        {
            get { return _purchasePrice; }
            set { _purchasePrice = value; }
        }

        private Decimal _salePrice;
        public Decimal SalePrice
        {
            get { return _salePrice; }
            set { _salePrice = value; }
        }
    }
}
