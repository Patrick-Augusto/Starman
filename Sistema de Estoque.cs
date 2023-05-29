using System;
using System.Data;
using System.Data.SqlClient;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            // Criar uma string de conexão.
            string connectionString = "Data Source=localhost;Initial Catalog=mydb;Integrated Security=True;";

            // Criar um objeto de conexão.
            SqlConnection connection = new SqlConnection(connectionString);

            // Abrir a conexão.
            connection.Open();

            // Fazer algo com o banco de dados.
            // Por exemplo, você pode executar consultas, recuperar dados e atualizar dados.

            // Adicionar um novo item de estoque.
            string nome = CaixaDeTextoNome.Text;
            int quantidade = int.Parse(CaixaDeTextoQuantidade.Text);
            decimal precoUnitario = decimal.Parse(CaixaDeTextoPrecoUnitario.Text);

            // Criar um novo item de estoque.
            ItemEstoque itemEstoque = new ItemEstoque()
            {
                Nome = nome,
                Quantidade = quantidade,
                PrecoUnitario = precoUnitario
            };

            // Adicionar o item de estoque ao banco de dados.
            SqlCommand command = new SqlCommand("INSERT INTO StockItems (Name, Quantity, UnitPrice) VALUES (@Name, @Quantity, @UnitPrice)", connection);
            SqlParameter nameParameter = new SqlParameter("@Name", SqlDbType.NVarChar, 50);
            nameParameter.Value = nome;

            SqlParameter quantityParameter = new SqlParameter("@Quantity", SqlDbType.Int);
            quantityParameter.Value = quantidade;

            SqlParameter unitPriceParameter = new SqlParameter("@UnitPrice", SqlDbType.Decimal);
            unitPriceParameter.Value = precoUnitario;

            command.Parameters.Add(nameParameter);
            command.Parameters.Add(quantityParameter);
            command.Parameters.Add(unitPriceParameter);
            command.ExecuteNonQuery();

            // Fechar a conexão.
            connection.Close();

            // Excluir um item de estoque.
            int id = int.Parse(CaixaDeTextoIdItemEstoque.Text);

            // Excluir o item de estoque do banco de dados.
            command = new SqlCommand("DELETE FROM StockItems WHERE Id = @Id", connection);
            SqlParameter idParameter = new SqlParameter("@Id", SqlDbType.Int);
            idParameter.Value = id;

            command.Parameters.Add(idParameter);
            command.ExecuteNonQuery();

            // Fechar a conexão.
            connection.Close();

            // Atualizar um item de estoque.
            id = int.Parse(CaixaDeTextoIdItemEstoque.Text);
            nome = CaixaDeTextoNome.Text;
            quantidade = int.Parse(CaixaDeTextoQuantidade.Text);
            precoUnitario = decimal.Parse(CaixaDeTextoPrecoUnitario.Text);

            // Atualizar o item de estoque no banco de dados.
            command = new SqlCommand("UPDATE StockItems SET Name = @Name, Quantity = @Quantity, UnitPrice = @UnitPrice WHERE Id = @Id", connection);
            nameParameter = new SqlParameter("@Name", SqlDbType.NVarChar, 50);
            nameParameter.Value = nome;

            quantityParameter = new SqlParameter("@Quantity", SqlDbType.Int);
            quantityParameter.Value = quantidade;

            unitPriceParameter = new SqlParameter("@UnitPrice", SqlDbType.Decimal);
            unitPriceParameter.Value = precoUnitario;

            idParameter = new SqlParameter("@Id", SqlDbType.Int);
            idParameter.Value = id;

            command.Parameters.Add(nameParameter);
            command.Parameters.Add(quantityParameter);
            command.Parameters.Add(unitPriceParameter);
            command.Parameters.Add(idParameter);
            command.ExecuteNonQuery();

            // Fechar a conexão.
            connection.Close();

            // Limpar o formulário.
            CaixaDeTextoNome.Text = "";
            CaixaDeTextoQuantidade.Text = "";
            CaixaDeTextoPre
