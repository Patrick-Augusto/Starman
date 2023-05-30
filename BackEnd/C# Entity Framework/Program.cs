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
            // Criar uma string de conexão.
            string connectionString = "Data Source=localhost;Initial Catalog=mydb;Integrated Security=True;";

             // Criar um contexto do Entity Framework.
            var context = new MyDbContext(connectionString);

            // Adicionar um novo item de estoque.
            AddItem(context, NameTextBox.Text, int.Parse(QuantityTextBox.Text), decimal.Parse(UnitPriceTextBox.Text));

            // Excluir um item de estoque.
            DeleteItem(context, int.Parse(StockItemIdTextBox.Text));

            // Atualizar um item de estoque.
            UpdateItem(context, int.Parse(StockItemIdTextBox.Text), NameTextBox.Text, int.Parse(QuantityTextBox.Text), decimal.Parse(UnitPriceTextBox.Text));

            // Limpar o formulário.
            NameTextBox.Text = "";
            QuantityTextBox.Text = "";
            UnitPriceTextBox.Text = "";
        }

        public static void AddItem(MyDbContext context, string name, int quantity, decimal unitPrice)
        {
            // Criar um novo item de estoque.
            StockItem stockItem = new StockItem()
            {
                Name = name,
                Quantity = quantity,
                UnitPrice = unitPrice
            };

             // Adicionar o item de estoque ao contexto.
            context.StockItems.Add(stockItem);

           // Salvar as alterações no banco de dados.
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    context.SaveChanges();
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }

        public static void DeleteItem(MyDbContext context, int id)
        {
            // Excluir o item de estoque do contexto.
            context.StockItems.Remove(context.StockItems.SingleOrDefault(s => s.Id == id));

            // Salvar as alterações no banco de dados.
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    context.SaveChanges();
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }

        public static void UpdateItem(MyDbContext context, int id, string name, int quantity, decimal unitPrice)
        {
            // Atualizar o item de estoque no contexto.
            var stockItem = context.StockItems.SingleOrDefault(s => s.Id == id);
            stockItem.Name = name;
            stockItem.Quantity = quantity;
            stockItem.UnitPrice = unitPrice;

           // Salvar as alterações no banco de dados.
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    context.SaveChanges();
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw;
                }
            }
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

