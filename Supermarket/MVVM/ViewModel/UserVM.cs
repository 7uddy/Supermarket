using GalaSoft.MvvmLight.Command;
using Supermarket.Commands;
using Supermarket.MVVM.Model;
using Supermarket.MVVM.Model.BusinessLogicLayer;
using Supermarket.MVVM.View;
using Supermarket.Stores;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Supermarket.MVVM.ViewModel
{
    public class UserVM:ViewModelBase
    {
        UserBLL userBLL = new UserBLL();

        private ObservableCollection<User> _usersList;

        public ObservableCollection<User> UsersList
        {
            get => _usersList;
            set => _usersList = value;
        }

        public ICommand NavigateToAdmin { get; set; }
        public ICommand NavigateToUserEarnings { get; set; }

        public UserVM(Navigation navigation, Func<AdminVM> createAdminVM,
            Func<UserMonthEarningsVM> createUserEarningsVM)
        {
            NavigateToAdmin = new NavigateCommand(navigation,createAdminVM);
            NavigateToUserEarnings = new NavigateCommand(navigation, createUserEarningsVM);
            _usersList = userBLL.GetAllUsers();
        }

        private User _selectedUser;
        public User SelectedUser
        {
            get => _selectedUser;
            set
            {
                _selectedUser = value;
                if (_selectedUser != null)
                {
                    newUsername = _selectedUser.Username;
                    newPassword = _selectedUser.Password;
                    newUserType = _selectedUser.UserType;
                }
                OnPropertyChanged(nameof(SelectedUser));
            }
        }

        private string newUsername;
        public string NewUsername
        {
            get => newUsername;
            set
            {
                newUsername = value;
                OnPropertyChanged(nameof(NewUsername));
            }
        }

        private string newPassword;
        public string NewPassword
        {
            get => newPassword;
            set
            {
                newPassword = value;
                OnPropertyChanged(nameof(NewPassword));
            }
        }

        private string newUserType;
        public string NewUserType
        {
            get => newUserType;
            set
            {
                newUserType = value;
                OnPropertyChanged(nameof(NewUserType));
            }
        }

        private RelayCommand updateCommand;

        public ICommand UpdateCommand
        {
            get
            {
                if (updateCommand == null)
                {
                    updateCommand = new RelayCommand(Update);
                }

                return updateCommand;
            }
        }

        private void Update()
        {
            userBLL.UpdateUser(SelectedUser.Id,newUsername,newPassword,newUserType);
            _usersList = userBLL.GetAllUsers();
            OnPropertyChanged(nameof(UsersList));
            CloseAction?.Invoke();
        }
        public List<string> UserTypes { get; } = new List<string> { "Admin", "Employee" };
        public Action CloseAction { get; set; }

        public ICommand DeleteUser
        {
            get
            {
                return new RelayCommand(() =>
                {
                    userBLL.DeleteUser(SelectedUser.Id);
                    _usersList = userBLL.GetAllUsers();
                    OnPropertyChanged(nameof(UsersList));
                });
            }
        }

        private RelayCommand insertCommand;

        private string _insertUsername;
        public string InsertUsername
        {
            get => _insertUsername;
            set
            {
                _insertUsername = value;
                OnPropertyChanged(nameof(InsertUsername));
            }
        }
        private string _insertPassword;
        public string InsertPassword
        {
            get => _insertPassword;
            set
            {
                _insertPassword = value;
                OnPropertyChanged(nameof(InsertPassword));
            }
        }
        private string _insertUserType;
        public string InsertUserType
        {
            get => _insertUserType;
            set
            {
                _insertUserType = value;
                OnPropertyChanged(nameof(InsertUserType));
            }
        }


        public ICommand InsertCommand
        {
            get
            {
                if (insertCommand == null)
                {
                    insertCommand = new RelayCommand(Insert);
                }

                return insertCommand;
            }
        }

        private void Insert()
        {
            if(_insertUsername == null || _insertPassword == null || _insertUserType == null)
            {
                MessageBox.Show("Please fill all fields.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;

            }
            userBLL.InsertUser(_insertUsername, _insertPassword, _insertUserType);
            _insertUsername = null;
            _insertPassword = null;
            _insertUserType = null;
            _usersList = userBLL.GetAllUsers();
            OnPropertyChanged(nameof(UsersList));
            CloseAction?.Invoke();
        }

    }
}
