using Supermarket.MVVM.Model.EntityLayer;
using System;
using System.Collections.ObjectModel;
using System.Data.SqlClient;

namespace Supermarket.MVVM.Model.DataAccessLayer
{
    public class ProductDAL
    {
        public ObservableCollection<Product> GetAllProducts()
        {
            SqlConnection connection = DALHelper.Connection;
            try
            {
                SqlCommand cmd = new SqlCommand("GetAllProducts", connection);
                ObservableCollection<Product> products = new ObservableCollection<Product>();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Product product = new Product
                    {
                        Id = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        Barcode = reader.GetString(2),
                        IdCategory = reader.GetInt32(3),
                        Category = reader.GetString(4),
                        IdProducer = reader.GetInt32(5),
                        Producer = reader.GetString(6)
                    };
                    products.Add(product);
                }
                reader.Close();
                return products;
            }
            finally
            {
                connection.Close();
            }
        }

        public void InsertProduct(string insertName, string insertBarcode, int insertIdProducer, int insertIdCategory)
        {
            SqlConnection connection = DALHelper.Connection;
            try
            {
                SqlCommand cmd = new SqlCommand("InsertProduct", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@name", insertName));
                cmd.Parameters.Add(new SqlParameter("@barcode", insertBarcode));
                cmd.Parameters.Add(new SqlParameter("@idProducer", insertIdProducer));
                cmd.Parameters.Add(new SqlParameter("@idCategory", insertIdCategory));
                connection.Open();
                cmd.ExecuteNonQuery();
            }
            finally
            {
                connection.Close();
            }
        }

        public void DeleteProduct(int id)
        {
            SqlConnection connection = DALHelper.Connection;
            try
            {
                SqlCommand cmd = new SqlCommand("DeleteProduct", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@id", id));
                connection.Open();
                cmd.ExecuteNonQuery();
            }
            finally
            {
                connection.Close();
            }
        }

        public void UpdateProduct(int id, string newProductName, string newBarcode, int newIdProducer, int newIdCategory)
        {
            SqlConnection connection = DALHelper.Connection;
            try
            {
                SqlCommand cmd = new SqlCommand("UpdateProduct", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@id", id));
                cmd.Parameters.Add(new SqlParameter("@newProductName", newProductName));
                cmd.Parameters.Add(new SqlParameter("@newBarcode", newBarcode));
                cmd.Parameters.Add(new SqlParameter("@newIdProducer", newIdProducer));
                cmd.Parameters.Add(new SqlParameter("@newIdCategory", newIdCategory));
                connection.Open();
                cmd.ExecuteNonQuery();
            }
            finally
            {
                connection.Close();
            }
        }

        public ObservableCollection<Product> GetProducerProducts(int idProducer)
        {
            SqlConnection connection = DALHelper.Connection;
            try
            {
                SqlCommand cmd = new SqlCommand("GetProducerProducts", connection);
                ObservableCollection<Product> products = new ObservableCollection<Product>();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@idProducer", idProducer));
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Product product = new Product
                    {
                        Id = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        Barcode = reader.GetString(2),
                        IdCategory = reader.GetInt32(3),
                        Category = reader.GetString(4),
                        IdProducer = reader.GetInt32(5),
                        Producer = reader.GetString(6)
                    };
                    products.Add(product);
                }
                reader.Close();
                return products;
            }
            finally
            {
                connection.Close();
            }
        }

        public Product GetProductByBarcode(long v)
        {
            SqlConnection connection = DALHelper.Connection;
            try
            {
                SqlCommand cmd = new SqlCommand("GetProductByBarcode", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@barcode", v));
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    Product product = new Product
                    {
                        Id = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        Barcode = reader.GetString(2),
                        IdCategory = reader.GetInt32(3),
                        Category = reader.GetString(4),
                        IdProducer = reader.GetInt32(5),
                        Producer = reader.GetString(6)
                    };
                    reader.Close();
                    return product;
                }
                else
                {
                    return null;
                }
            }
            finally
            {
                connection.Close();
            }
        }

        public Product GetProductByDate(DateTime date)
        {
            SqlConnection connection = DALHelper.Connection;
            try
            {
                SqlCommand cmd = new SqlCommand("GetProductByDate", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@expiryDate", date));
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    Product product = new Product
                    {
                        Id = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        Barcode = reader.GetString(2),
                        IdCategory = reader.GetInt32(3),
                        Category = reader.GetString(4),
                        IdProducer = reader.GetInt32(5),
                        Producer = reader.GetString(6)
                    };
                    reader.Close();
                    return product;
                }
                else
                {
                    return null;
                }
            }
            finally
            {
                connection.Close();
            }
        }

        public Product GetProductByName(string searchBar)
        {
            SqlConnection connection = DALHelper.Connection;
            try
            {
                SqlCommand cmd = new SqlCommand("GetProductByName", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@name", searchBar));
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    Product product = new Product
                    {
                        Id = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        Barcode = reader.GetString(2),
                        IdCategory = reader.GetInt32(3),
                        Category = reader.GetString(4),
                        IdProducer = reader.GetInt32(5),
                        Producer = reader.GetString(6)
                    };
                    reader.Close();
                    return product;
                }
                else
                {
                    return null;
                }
            }
            finally
            {
                connection.Close();
            }
        }

        public Product GetProductByCategory(string searchBar)
        {
            SqlConnection connection = DALHelper.Connection;
            try
            {
                SqlCommand cmd = new SqlCommand("GetProductByCategory", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@category", searchBar));
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    Product product = new Product
                    {
                        Id = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        Barcode = reader.GetString(2),
                        IdCategory = reader.GetInt32(3),
                        Category = reader.GetString(4),
                        IdProducer = reader.GetInt32(5),
                        Producer = reader.GetString(6)
                    };
                    reader.Close();
                    return product;
                }
                else
                {
                    return null;
                }
            }
            finally
            {
                connection.Close();
            }
        }

        public Product GetProductByProducer(string searchBar)
        {
            SqlConnection connection = DALHelper.Connection;
            try
            {
                SqlCommand cmd = new SqlCommand("GetProductByProducer", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@producer", searchBar));
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    Product product = new Product
                    {
                        Id = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        Barcode = reader.GetString(2),
                        IdCategory = reader.GetInt32(3),
                        Category = reader.GetString(4),
                        IdProducer = reader.GetInt32(5),
                        Producer = reader.GetString(6)
                    };
                    reader.Close();
                    return product;
                }
                else
                {
                    return null;
                }
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
