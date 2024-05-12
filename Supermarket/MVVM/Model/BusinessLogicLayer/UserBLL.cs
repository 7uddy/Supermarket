using Supermarket.MVVM.Model.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.MVVM.Model.BusinessLogicLayer
{
    public class UserBLL
    {
       public ObservableCollection<User> UsersList { get; set; }
       UserDAL userDAL = new UserDAL();

        public ObservableCollection<User> GetAllUsers()
        {
            return userDAL.GetAllUsers();
        }

        public User Login(string username, string password)
        {
            return userDAL.Login(username, password);
        }
    }
}
