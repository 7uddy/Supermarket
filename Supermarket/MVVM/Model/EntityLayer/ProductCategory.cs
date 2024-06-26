﻿using System;

namespace Supermarket.MVVM.Model.EntityLayer
{
    public class ProductCategory
    {
        private int _categoryID;
        public int CategoryID
        {
            get { return _categoryID; }
            set { _categoryID = value; }
        }
        private string _categoryName;
        public string CategoryName
        {
            get { return _categoryName; }
            set { _categoryName = value; }
        }
        private Decimal _totalPrice;
        public Decimal TotalPrice
        {
            get { return _totalPrice; }
            set { _totalPrice = value; }
        }
    }
}
