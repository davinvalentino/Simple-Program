using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using Project_AMDP3.Model;

namespace Project_AMDP3.Repository
{
    class ProductRepository
    {
        public void Insert(Product product)
        {
            SqlConnection connection = new SqlConnection(@"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=marketDB;Data Source=localhost\SQLEXPRESS");
            SqlCommand command = new SqlCommand();
            SqlDataReader reader;

            string query = "INSERT INTO products(Name, Quantity, Price) VALUES (@Name, @Quantity, @Price)";

            command.Parameters.Add("@Name", SqlDbType.VarChar, 100).Value = product.name;
            command.Parameters.Add("@Quantity", SqlDbType.Int).Value = product.quantity;
            command.Parameters.Add("@Price", SqlDbType.Int).Value = product.price;

            command.Connection = connection;
            command.CommandType = CommandType.Text;
            command.CommandText = query;

            connection.Open();
            command.ExecuteNonQuery();

            command.Dispose();
            connection.Close();
        }

        public List<Product> GetAll()
        {
            SqlConnection connection = new SqlConnection(@"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=marketDB;Data Source=DESKTOP-L45BS70\SQLEXPRESS");
            SqlCommand command = new SqlCommand();
            SqlDataReader reader;
            List<Product> productList = new List<Product>();

            string query = "SELECT * FROM products";

            command.Connection = connection;
            command.CommandType = CommandType.Text;
            command.CommandText = query;

            connection.Open();

            reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Product product = new Product();
                    product.ID = int.Parse(reader["ID"].ToString());
                    product.name = reader["Name"].ToString();
                    product.quantity = int.Parse(reader["Quantity"].ToString());
                    product.price = int.Parse(reader["Price"].ToString());

                    productList.Add(product);
                }
            }

            reader.Close();
            command.Dispose();
            connection.Close();

            return productList;
        }

        public void Delete(Product product)
        {
            SqlConnection connection = new SqlConnection(@"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=marketDB;Data Source=localhost\SQLEXPRESS");
            SqlCommand command = new SqlCommand();
            SqlDataReader reader;

            string query = "DELETE FROM products WHERE ID= @ID";

            command.Parameters.Add("@ID", SqlDbType.Int).Value = product.ID;

            command.Connection = connection;
            command.CommandType = CommandType.Text;
            command.CommandText = query;

            connection.Open();
            command.ExecuteNonQuery();

            command.Dispose();
            connection.Close();
        }

        public void Update(Product product)
        {
            SqlConnection connection = new SqlConnection(@"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=marketDB;Data Source=localhost\SQLEXPRESS");
            SqlCommand command = new SqlCommand();
            SqlDataReader reader;

            string query = "UPDATE products SET Name= @Name, Price= @Price, Quantity= @Quantity WHERE ID= @ID";

            command.Parameters.Add("@ID", SqlDbType.Int).Value = product.ID;
            command.Parameters.Add("@Name", SqlDbType.VarChar, 100).Value = product.name;
            command.Parameters.Add("@Quantity", SqlDbType.Int).Value = product.quantity;
            command.Parameters.Add("@Price", SqlDbType.Int).Value = product.price;

            command.Connection = connection;
            command.CommandType = CommandType.Text;
            command.CommandText = query;

            connection.Open();
            command.ExecuteNonQuery();

            command.Dispose();
            connection.Close();
        }

        
    }
}
