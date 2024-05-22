using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.MVVM.Model.EntityLayer
{
    public class UserMonthEarning
    {
        private DateTime _date;
        public DateTime Date
        {
            get { return _date; }
            set { _date = value; }
        }
        private Decimal _totalEarning;
        public Decimal TotalEarning
        {
            get { return _totalEarning; }
            set { _totalEarning = value; }
        }
    }
}
