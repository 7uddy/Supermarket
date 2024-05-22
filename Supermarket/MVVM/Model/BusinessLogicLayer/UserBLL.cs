using Supermarket.MVVM.Model.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.MVVM.Model.BusinessLogicLayer
{
    public class UserBLL
    {
       public static ObservableCollection<User> UsersList { get; set; }
       UserDAL userDAL = new UserDAL();

        public ObservableCollection<User> GetAllUsers()
        {
            UsersList= userDAL.GetAllUsers();
            return UsersList;
        }

        public User Login(string username, string password)
        {
            return userDAL.Login(username, password);
        }

        public void UpdateUser(int id, string username, string password, string usertype)
        {
            userDAL.UpdateUser(id,username,password,usertype);
        }

        public void DeleteUser(int id)
        {
           userDAL.DeleteUser(id);
        }

        public void InsertUser(string newUsername, string newPassword, string newUserType)
        {
            userDAL.InsertUser(newUsername, newPassword, newUserType);
        }
    }
}
