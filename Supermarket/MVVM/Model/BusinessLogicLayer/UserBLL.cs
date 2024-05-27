using Supermarket.MVVM.Model.DataAccessLayer;
using System.Collections.ObjectModel;

namespace Supermarket.MVVM.Model.BusinessLogicLayer
{
    public class UserBLL
    {
       public static ObservableCollection<User> UsersList { get; set; }
       public static ObservableCollection<User> EmployeesList { get; set; }
       UserDAL userDAL = new UserDAL();

        public ObservableCollection<User> GetAllUsers()
        {
            UsersList= userDAL.GetAllUsers();
            EmployeesList = GetEmployees();
            return UsersList;
        }

        private ObservableCollection<User> GetEmployees()
        {
            ObservableCollection<User> EmployeesList= new ObservableCollection<User>();
            foreach (User user in UsersList)
            {
                if (user.UserType == "Employee")
                {
                    EmployeesList.Add(user);
                }
            }
            return EmployeesList;
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
