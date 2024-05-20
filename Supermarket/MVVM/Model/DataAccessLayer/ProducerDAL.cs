using Supermarket.MVVM.Model.EntityLayer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.MVVM.Model.DataAccessLayer
{
    public class ProducerDAL
    {
        public ObservableCollection<Producer> GetAllProducers()
        {
            SqlConnection sqlConnection=DALHelper.Connection;
            try
            {
                SqlCommand sqlCommand = new SqlCommand("GetAllProducers", sqlConnection);
                ObservableCollection<Producer> producers = new ObservableCollection<Producer>();
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                sqlConnection.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    Producer producer = new Producer
                    {
                        Id = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        Country = reader.GetString(2)
                    };
                    producers.Add(producer);
                }
                reader.Close();
                return producers;
            }
            finally
            {
                sqlConnection.Close();
            }
        }

        public void InsertProducer(string insertName, string insertCountry)
        {
            SqlConnection sqlConnection = DALHelper.Connection;
            try
            {
                SqlCommand sqlCommand = new SqlCommand("InsertProducer", sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                sqlCommand.Parameters.Add(new SqlParameter("@name", insertName));
                sqlCommand.Parameters.Add(new SqlParameter("@country", insertCountry));
                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
            }
            finally
            {
                sqlConnection.Close();
            }
        }

        public void UpdateProducer(int id, string newName, string newCountry)
        {
            SqlConnection sqlConnection = DALHelper.Connection;
            try
            {
                SqlCommand sqlCommand = new SqlCommand("UpdateProducer", sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                sqlCommand.Parameters.Add(new SqlParameter("@id", id));
                sqlCommand.Parameters.Add(new SqlParameter("@name", newName));
                sqlCommand.Parameters.Add(new SqlParameter("@country", newCountry));
                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
            }
            finally
            {
                sqlConnection.Close();
            }
        }

        public void DeleteProducer(int id)
        {
            SqlConnection sqlConnection = DALHelper.Connection;
            try
            {
                SqlCommand sqlCommand = new SqlCommand("DeleteProducer", sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                sqlCommand.Parameters.Add(new SqlParameter("@id", id));
                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
            }
            finally
            {
                sqlConnection.Close();
            }
        }
    }
}
