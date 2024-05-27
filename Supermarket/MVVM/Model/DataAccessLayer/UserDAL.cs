using System.Collections.ObjectModel;
using System.Data.SqlClient;

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

        public User Login(string username, string password)
        {
            SqlConnection connection = DALHelper.Connection;
            try
            {
                SqlCommand cmd = new SqlCommand("Login", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password);
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    App._user=new User
                    {
                        Id = reader.GetInt32(0),
                        Username = reader.GetString(1),
                        Password = reader.GetString(2),
                        UserType = reader.GetString(3)
                    };
                    return App._user;
                    
                }
                return null;
            }
            finally
            {
                connection.Close();
            }
        }
        public void UpdateUser(int id,string username,string password,string usertype)
        {
            SqlConnection connection = DALHelper.Connection;
            try
            {
                SqlCommand cmd = new SqlCommand("UpdateUser", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password);
                cmd.Parameters.AddWithValue("@userType", usertype);
                connection.Open();
                cmd.ExecuteNonQuery();
            }
            finally
            {
                connection.Close();
            }
        }

        public void DeleteUser(int id)
        {
            SqlConnection connection = DALHelper.Connection;
            try
            {
                SqlCommand cmd = new SqlCommand("DeleteUser", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                connection.Open();
                cmd.ExecuteNonQuery();
            }
            finally
            {
                connection.Close();
            }
        }

        public void InsertUser(string newUsername, string newPassword, string newUserType)
        {
            SqlConnection connection = DALHelper.Connection;
            try
            {
                SqlCommand cmd = new SqlCommand("InsertUser", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@username", newUsername);
                cmd.Parameters.AddWithValue("@password", newPassword);
                cmd.Parameters.AddWithValue("@userType", newUserType);
                connection.Open();
                cmd.ExecuteNonQuery();
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
