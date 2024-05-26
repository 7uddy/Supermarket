using Supermarket.MVVM.Model.DataAccessLayer;
using Supermarket.MVVM.Model.EntityLayer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.MVVM.Model.BusinessLogicLayer
{
    public class UserMonthEarningsBLL
    {
        private UserMonthEarningsDAL userMonthEarningsDAL = new UserMonthEarningsDAL();

        public ObservableCollection<UserMonthEarning> GetMonthEarnings(User selectedUser, DateTime selectedDate)
        {
            return userMonthEarningsDAL.GetMonthEarnings(selectedUser, selectedDate);
        }
    }
}
