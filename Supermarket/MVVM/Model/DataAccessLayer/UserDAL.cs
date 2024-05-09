using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.MVVM.Model.DataAccessLayer
{
    public class UserDAL
    {
        public ObservableCollection<User> GetAllUsers()
        {
           SqlConnection connection = DALHelper.Connection;
            try
            {
                SqlCommand cmd= new SqlCommand("GetAllUsers", connection);
                ObservableCollection<User> users = new ObservableCollection<User>();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    User user = new User
                    {
                        Id = reader.GetInt32(0),
                        Username = reader.GetString(1),
                        Password = reader.GetString(2),
                        UserType = reader.GetString(3)
                    };
                    users.Add(user);
                }
                reader.Close();
                return users;
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
