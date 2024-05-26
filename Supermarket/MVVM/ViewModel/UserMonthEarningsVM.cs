using Supermarket.Commands;
using Supermarket.MVVM.Model;
using Supermarket.MVVM.Model.BusinessLogicLayer;
using Supermarket.MVVM.Model.EntityLayer;
using Supermarket.Stores;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Supermarket.MVVM.ViewModel
{
    public class UserMonthEarningsVM:ViewModelBase
    {
        public ICommand NavigateToUsers { get; }
        public UserMonthEarningsVM(Navigation navigation,Func<UserVM> createUserVM)
        {
            NavigateToUsers = new NavigateCommand(navigation, createUserVM);
        }

        private DateTime _selectedDate= DateTime.Now;
        public DateTime SelectedDate
        {
            get => _selectedDate;
            set
            {
                _selectedDate = value;
                if(_user!=null) UpdateMonthEarnings();
                OnPropertyChanged(nameof(SelectedDate));
            }
        }
        private User _user;
        public User SelectedUser
        {
            get => _user;
            set
            {
                _user = value;
                if(_selectedDate!=null) UpdateMonthEarnings();
                OnPropertyChanged(nameof(SelectedUser));
            }
        }

        private ObservableCollection<User> _usersList = UserBLL.EmployeesList;
        public ObservableCollection<User> UsersList
        {
            get => _usersList;
            set
            {
                _usersList = value;
                OnPropertyChanged(nameof(UsersList));
            }
        }

        private ObservableCollection<UserMonthEarning> _monthEarningsList=new ObservableCollection<UserMonthEarning>();
        public ObservableCollection<UserMonthEarning> MonthEarningsList
        {
            get => _monthEarningsList;
            set
            {
                _monthEarningsList = value;
                OnPropertyChanged(nameof(MonthEarningsList));
            }
        }

        private UserMonthEarningsBLL UserMonthEarningBLL = new UserMonthEarningsBLL();

        private void UpdateMonthEarnings()
        {
            var earnings = UserMonthEarningBLL.GetMonthEarnings(SelectedUser, SelectedDate);
            MonthEarningsList.Clear();
            foreach (var earning in earnings)
            {
                MonthEarningsList.Add(earning);
            }
        }

        private UserMonthEarning _selectedReceipt;
        public UserMonthEarning SelectedReceipt
        {
            get => _selectedReceipt;
            set
            {
                _selectedReceipt = value;
                UpdateDetails();
                OnPropertyChanged("SelectedReceipt");
            }
        }

        private ReceiptProductBLL receiptProductBLL = new ReceiptProductBLL();

        private ObservableCollection<ReceiptProduct> _selectedReceiptProducts;
        public ObservableCollection<ReceiptProduct> SelectedReceiptProducts
        {
            get => _selectedReceiptProducts;
            set
            {
                _selectedReceiptProducts = value;
                OnPropertyChanged("SelectedReceiptProducts");
            }
        }

        public Action CloseAction { get; internal set; }

        private void UpdateDetails()
        {
            _selectedReceiptProducts = receiptProductBLL.GetHighestReceiptProducts(_selectedReceipt.Date);
        }


    }
}
