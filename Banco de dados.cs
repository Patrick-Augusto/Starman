using System;
using System.Data;
using System.Data.SqlClient;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a connection string.
            string connectionString = "Data Source=localhost;Initial Catalog=mydb;Integrated Security=True;";

            // Create a connection object.
            SqlConnection connection = new SqlConnection(connectionString);

            // Open the connection.
            connection.Open();

            // Do something with the database.
            // For example, you can execute queries, retrieve data, and update data.

            // Close the connection.
            connection.Close();
        }
    }
}
