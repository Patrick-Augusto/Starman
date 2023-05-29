using System;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a connection string.
            string connectionString = "Data Source=localhost;Initial Catalog=mydb;Integrated Security=True;";

            // Create an Entity Framework context.
            var context = new MyDbContext(connectionString);

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

            // Add the stock item to the context.
            context.StockItems.Add(stockItem);

            // Save the changes to the database.
            context.SaveChanges();

            // Close the context.
            context.Dispose();

            // Delete a stock item.
            int id = int.Parse(StockItemIdTextBox.Text);

            // Delete the stock item from the context.
            context.StockItems.Remove(context.StockItems.SingleOrDefault(s => s.Id == id));

            // Save the changes to the database.
            context.SaveChanges();

            // Close the context.
            context.Dispose();

            // Update a stock item.
            id = int.Parse(StockItemIdTextBox.Text);
            name = NameTextBox.Text;
            quantity = int.Parse(QuantityTextBox.Text);
            unitPrice = decimal.Parse(UnitPriceTextBox.Text);

            // Update the stock item in the context.
            var stockItem = context.StockItems.SingleOrDefault(s => s.Id == id);
            stockItem.Name = name;
            stockItem.Quantity = quantity;
            stockItem.UnitPrice = unitPrice;

            // Save the changes to the database.
            context.SaveChanges();

            // Close the context.
            context.Dispose();

            // Clear the form.
            NameTextBox.Text = "";
            QuantityTextBox.Text = "";
            UnitPriceTextBox.Text = "";
        }
    }

    public class MyDbContext : DbContext
    {
        public DbSet<StockItem> StockItems { get; set; }

        public MyDbContext(string connectionString) : base(connectionString)
        {
        }
    }

    public class StockItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
