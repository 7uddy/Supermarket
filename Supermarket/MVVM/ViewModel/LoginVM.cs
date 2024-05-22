using GalaSoft.MvvmLight.Command;
using Supermarket.Commands;
using Supermarket.MVVM.Model;
using Supermarket.MVVM.Model.BusinessLogicLayer;
using Supermarket.Stores;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace Supermarket.MVVM.ViewModel
{
    public class LoginVM:ViewModelBase
    {
        UserBLL userBLL = new UserBLL();

        private string _username;
        public string Username
        {
            get => _username;
            set
            {
                _username = value;
                OnPropertyChanged(nameof(Username));
                OnPropertyChanged(nameof(LoginEnabled));
            }
        }
        private string _password;
        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
                OnPropertyChanged(nameof(LoginEnabled));
            }
        }

        private ObservableCollection<User> _usersList;

        public ObservableCollection<User> UsersList
        {
            get => _usersList;
            set => _usersList = value;
        }

        //public LoginVM()
        //{
        //    _usersList = userBLL.GetAllUsers();
        //}

        public ICommand LoginCommand
        {
            get
            {
                return new RelayCommand(Login);
            }
        }

        private void Login()
        {
           if(userBLL.Login(_username, _password)!=null)
            {
                if(App._user.UserType=="Admin")
                {
                    NavigateToAdmin.Execute(null);
                }
                else
                {
                    NavigateToCashier.Execute(null);
                }
            }
            else
            {
                MessageBox.Show("Login failed. Please check credentials", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        public bool LoginEnabled
        {
            get
            {
                return !string.IsNullOrEmpty(Username) && !string.IsNullOrEmpty(Password);
            }
        }
        public ICommand NavigateToAdmin { get;}
        public ICommand NavigateToCashier { get; }

        public LoginVM(Navigation navigation,Func<AdminVM> createAdminVM, Func<CashierVM> createCashierVM)
        {
            NavigateToAdmin = new NavigateCommand(navigation, createAdminVM);
            NavigateToCashier = new NavigateCommand(navigation, createCashierVM);
        }

    }
}
