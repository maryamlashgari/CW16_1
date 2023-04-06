using CW16_1.Models;
using System.Data;
using System.Data.SqlClient;
using System.Reflection.PortableExecutable;

namespace CW16_1.Repository
{
    public class ProdcutRepository : IProdcutRepository
    {
        string connectionString = "Data Source=.;Initial Catalog=CW16_1;Integrated Security=True;TrustServerCertificate=True;";

        public void InsertProduct(Product product)
        {
            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    var cmd = new SqlCommand("insert into Product values (@Id,@Name,@Price)", conn);
                    cmd.Parameters.AddWithValue("@Id", product.Id);
                    cmd.Parameters.AddWithValue("@Name", product.Name);
                    cmd.Parameters.AddWithValue("@Price", product.Price);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void UpdateProduct(Product product)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                var command = new SqlCommand(
                    "UPDATE Product SET  Name = @Name , Price = @Price" +
                    " WHERE Id = @Id", conn);
                // Add the parameters for the UpdateCommand.
                command.Parameters.AddWithValue("@Id", product.Id);
                command.Parameters.AddWithValue("@Name", product.Name);
                command.Parameters.AddWithValue("@Price", product.Price);
                conn.Open();
                command.ExecuteNonQuery();
                conn.Close();
            }

        }

        public void DeleteProduct(int id)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                var command = new SqlCommand(
                    "Delete From Product " +
                    " WHERE Id = @Id", conn);
                // Add the parameters for the UpdateCommand.
                command.Parameters.AddWithValue("@Id", id);
                conn.Open();
                command.ExecuteNonQuery();
                conn.Close();
            }

        }
        public List<Product> GetListOfProducts()
        {
            List<Product> products = new List<Product>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("SELECT * FROM Product", connection);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        int id = (int)reader["Id"];
                        string name = (string)reader["Name"];
                        double price = (double)reader["Price"];
                        //Console.WriteLine("Student ID: {0}, Name: {1}", id, name);
                        products.Add(new Product()
                        {
                            Id = id,
                            Name = name,
                            Price = price,
                        });
                    }


                    reader.Close();
                    connection.Close();
                    return products;
                }

                catch (Exception e)
                {
                    throw e;
                }

                finally
                {
                    connection.Close();
                }
            }
        }

        public Product GetProductById(int id)
        {
            Product product = null;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("SELECT * FROM Product WHERE Id = @Id", connection);
                    command.Parameters.AddWithValue("@Id", id);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        string name = (string)reader["Name"];
                        double price = (double)reader["Price"];
                        //Console.WriteLine("Student ID: {0}, Name: {1}", id, name);
                        product = new Product()
                        {
                            Id = id,
                            Name = name,
                            Price = price,
                        };
                    }


                    reader.Close();
                    connection.Close();
                    return product;
                }

                catch (Exception e)
                {
                    throw e;
                }

                finally
                {
                    connection.Close();
                }
            }
        }
    }
}
