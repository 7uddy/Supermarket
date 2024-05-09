using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Markup;

namespace Supermarket.MVVM.Model.DataAccessLayer
{
    public static class DALHelper
    {
        private static readonly string connectionString = ConfigurationManager.ConnectionStrings["SupermarketDB"].ConnectionString;

        public static SqlConnection Connection
        {
            get
            {
                return new SqlConnection("Data Source = TUDDYsPC\\SQLEXPRESS; Initial Catalog = SupermarketDB; Integrated Security = True; Encrypt = False");
            }
        }
    }
}
