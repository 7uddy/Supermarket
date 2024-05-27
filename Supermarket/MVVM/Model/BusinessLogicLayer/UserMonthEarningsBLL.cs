using Supermarket.MVVM.Model.DataAccessLayer;
using Supermarket.MVVM.Model.EntityLayer;
using System;
using System.Collections.ObjectModel;

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
