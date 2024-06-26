﻿using System.Configuration;
using System.Data.SqlClient;

namespace Supermarket.MVVM.Model.DataAccessLayer
{
    public static class DALHelper
    {
        private static readonly string connectionString = ConfigurationManager.ConnectionStrings["SupermarketDB"].ConnectionString;

        public static SqlConnection Connection
        {
            get
            {
                return new SqlConnection("Data Source=TUDDYSASUS\\SQLEXPRESS;Initial Catalog=SupermarketDB;Integrated Security=True;Encrypt=False");
                //
                //"Data Source=TUDDYSASUS\\SQLEXPRESS;Initial Catalog=SupermarketDB;Integrated Security=True;Encrypt=False"
                //"Data Source = TUDDYsPC\\SQLEXPRESS; Initial Catalog = SupermarketDB; Integrated Security = True; Encrypt = False"
            }
        }
    }
}
