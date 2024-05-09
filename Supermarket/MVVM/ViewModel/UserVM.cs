using Supermarket.MVVM.Model;
using Supermarket.MVVM.Model.BusinessLogicLayer;
using System.Collections.ObjectModel;

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

        public UserVM()
        {
            _usersList = userBLL.GetAllUsers();
        }

    }
}
