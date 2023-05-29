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
            string name = NameTextBox.Text;
            int quantity = int.Parse(QuantityTextBox.Text);
            decimal unitPrice = decimal.Parse(UnitPriceTextBox.Text);

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
            context.SaveChanges();

            // Fechar o contexto.
            context.Dispose();

            // Excluir um item de estoque.
            int id = int.Parse(StockItemIdTextBox.Text);

            // Excluir o item de estoque do contexto.
            context.StockItems.Remove(context.StockItems.SingleOrDefault(s => s.Id == id));

            // Salvar as alterações no banco de dados.
            context.SaveChanges();

            // Fechar o contexto.
            context.Dispose();

            // Atualizar um item de estoque.
            id = int.Parse(StockItemIdTextBox.Text);
            name = NameTextBox.Text;
            quantity = int.Parse(QuantityTextBox.Text);
            unitPrice = decimal.Parse(UnitPriceTextBox.Text);

            // Atualizar o item de estoque no contexto.
            var stockItem = context.StockItems.SingleOrDefault(s => s.Id == id);
            stockItem.Name = name;
            stockItem.Quantity = quantity;
            stockItem.UnitPrice = unitPrice;

            // Salvar as alterações no banco de dados.
            context.SaveChanges();

            // Fechar o contexto.
            context.Dispose();

            // Limpar o formulário.
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
