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

            // Add a new stock item.
            string name = NameTextBox.Text;
            int quantity = int.Parse(QuantityTextBox.Text);
            decimal unitPrice = decimal.Parse(UnitPriceTextBox.Text);

            // Create a new stock item.
            StockItem stockItem = new StockItem()
            {
                Name = name,
                Quantity = quantity,
                UnitPrice = unitPrice
            };

            // Add the stock item to the database.
            SqlCommand command = new SqlCommand("INSERT INTO StockItems (Name, Quantity, UnitPrice) VALUES (@Name, @Quantity, @UnitPrice)", connection);
            SqlParameter nameParameter = new SqlParameter("@Name", SqlDbType.NVarChar, 50);
            nameParameter.Value = name;

            SqlParameter quantityParameter = new SqlParameter("@Quantity", SqlDbType.Int);
            quantityParameter.Value = quantity;

            SqlParameter unitPriceParameter = new SqlParameter("@UnitPrice", SqlDbType.Decimal);
            unitPriceParameter.Value = unitPrice;

            command.Parameters.Add(nameParameter);
            command.Parameters.Add(quantityParameter);
            command.Parameters.Add(unitPriceParameter);
            command.ExecuteNonQuery();

            // Close the connection.
            connection.Close();

            // Delete a stock item.
            int id = int.Parse(StockItemIdTextBox.Text);

            // Delete the stock item from the database.
            command = new SqlCommand("DELETE FROM StockItems WHERE Id = @Id", connection);
            SqlParameter idParameter = new SqlParameter("@Id", SqlDbType.Int);
            idParameter.Value = id;

            command.Parameters.Add(idParameter);
            command.ExecuteNonQuery();

            // Close the connection.
            connection.Close();

            // Update a stock item.
            id = int.Parse(StockItemIdTextBox.Text);
            name = NameTextBox.Text;
            quantity = int.Parse(QuantityTextBox.Text);
            unitPrice = decimal.Parse(UnitPriceTextBox.Text);

            // Update the stock item in the database.
            command = new SqlCommand("UPDATE StockItems SET Name = @Name, Quantity = @Quantity, UnitPrice = @UnitPrice WHERE Id = @Id", connection);
            nameParameter = new SqlParameter("@Name", SqlDbType.NVarChar, 50);
            nameParameter.Value = name;

            quantityParameter = new SqlParameter("@Quantity", SqlDbType.Int);
            quantityParameter.Value = quantity;

            unitPriceParameter = new SqlParameter("@UnitPrice", SqlDbType.Decimal);
            unitPriceParameter.Value = unitPrice;

            idParameter = new SqlParameter("@Id", SqlDbType.Int);
            idParameter.Value = id;

            command.Parameters.Add(nameParameter);
            command.Parameters.Add(quantityParameter);
            command.Parameters.Add(unitPriceParameter);
            command.Parameters.Add(idParameter);
            command.ExecuteNonQuery();

            // Close the connection.
            connection.Close();

            // Clear the form.
            NameTextBox.Text = "";
            QuantityTextBox.Text = "";
            UnitPriceTextBox.Text = "";
        }
    }
}
