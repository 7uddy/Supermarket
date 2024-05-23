using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.MVVM.Model.EntityLayer
{
    public class Receipt
    {
        private int _id;
        public int Id
        {
            get => _id;
            set => _id = value;
        }
        private DateTime _date;
        public DateTime Date
        {
            get => _date;
            set => _date = value;
        }
        private int _cashierId;
        public int CashierId
        {
            get => _cashierId;
            set => _cashierId = value;
        }

        private string _cashierName;
        public string CashierName
        {
            get => _cashierName;
            set => _cashierName = value;
        }

        private Decimal _totalAmount;
        public Decimal TotalAmount
        {
            get => _totalAmount;
            set => _totalAmount = value;
        }
    }
}
