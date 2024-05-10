using GalaSoft.MvvmLight.Command;
using Supermarket.MVVM.Model;
using Supermarket.MVVM.Model.BusinessLogicLayer;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Supermarket.MVVM.ViewModel
{
    public class UserVM:ViewModelBase
    {
        UserBLL userBLL = new UserBLL();

        private string _username;
        public string Username
        {
            get => _username;
            set
            {
                _username = value;
                OnPropertyChanged("Username");
            }
        }
        private string _password;
        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged("Password");
            }
        }
        private bool _userType;
        public bool UserType
        {
            get => _userType;
            set
            {
                _userType = value;
                OnPropertyChanged("UserType");
            }
        }

        private ObservableCollection<User> _usersList;

        public ObservableCollection<User> UsersList
        {
            get => _usersList;
            set => _usersList = value;
        }

        public UserVM()
        {
            _usersList = userBLL.GetAllUsers();
        }

        public ICommand LoginCommand
        {
            get
            {
                return new RelayCommand(Login);
            }
        }

        private void Login()
        {
           if(userBLL.Login(_username, _password))
            {
                UserType = true;
            }
            else
            {
                UserType = false;
            }
        }
    }
}
