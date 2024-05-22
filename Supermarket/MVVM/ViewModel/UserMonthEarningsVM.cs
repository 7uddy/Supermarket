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
                OnPropertyChanged(nameof(SelectedUser));
            }
        }

        private ObservableCollection<User> _usersList = UserBLL.UsersList;
        public ObservableCollection<User> UsersList
        {
            get => _usersList;
            set
            {
                _usersList = value;
                OnPropertyChanged(nameof(UsersList));
            }
        }

        private ObservableCollection<UserMonthEarning> _monthEarningsList;
        public ObservableCollection<UserMonthEarning> MonthEarningsList
        {
            get => _monthEarningsList;
            set
            {
                _monthEarningsList = value;
                OnPropertyChanged(nameof(MonthEarningsList));
            }
        }


    }
}
