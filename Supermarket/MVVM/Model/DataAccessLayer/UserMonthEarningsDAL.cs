using Supermarket.MVVM.Model.EntityLayer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.MVVM.Model.DataAccessLayer
{
    public class UserMonthEarningsDAL
    {
        public ObservableCollection<UserMonthEarning> GetMonthEarnings(User selectedUser, DateTime selectedDate)
        {
            SqlConnection connection= DALHelper.Connection;
            try
            {
                SqlCommand cmd = new SqlCommand("GetMonthEarnings", connection);
                cmd.Parameters.AddWithValue("@userId", selectedUser.Id);
                cmd.Parameters.AddWithValue("@month", selectedDate.Month);
                ObservableCollection<UserMonthEarning> users = new ObservableCollection<UserMonthEarning>();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    UserMonthEarning user = new UserMonthEarning
                    {
                        Date = reader.GetDateTime(0),
                        TotalEarning = reader.GetDecimal(1)
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
