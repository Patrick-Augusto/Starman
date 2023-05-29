## Starman

Exemplo de Aplicativo de Gerenciamento de Itens de Estoque

## Descrição

Este é um exemplo simples de um aplicativo de gerenciamento de itens de estoque usando o Entity Framework. O aplicativo permite adicionar, atualizar e excluir itens de estoque em um banco de dados.

## Como usar

1. Clone este repositório para sua máquina local.
2. Certifique-se de ter o Visual Studio instalado.
3. Abra o projeto no Visual Studio.
4. Abra o arquivo `Program.cs`.
5. No método `Main`, localize a variável `connectionString` e atualize-a com as informações de conexão corretas para o seu banco de dados.
6. Execute o aplicativo.

## Requisitos

- Visual Studio
- Entity Framework
- Banco de dados SQL Server (ou outro banco de dados compatível com o Entity Framework)

## Instalação

1. Clone este repositório para sua máquina local.
2. Abra o projeto no Visual Studio.
3. Restaure os pacotes NuGet necessários.
4. Certifique-se de ter um banco de dados configurado e atualize a string de conexão no arquivo `Program.cs` com as informações corretas do banco de dados.
5. Compile e execute o aplicativo.

## Exemplos

Aqui estão alguns exemplos de como usar o aplicativo:

- Adicionar um novo item de estoque:

```csharp
string name = "Nome do Item";
int quantity = 10;
decimal unitPrice = 9.99;

// Crie um novo item de estoque.
StockItem stockItem = new StockItem()
{
    Name = name,
    Quantity = quantity,
    UnitPrice = unitPrice
};

// Adicione o item de estoque ao contexto.
context.StockItems.Add(stockItem);

// Salve as alterações no banco de dados.
context.SaveChanges();
```

- Excluir um item de estoque existente:

```csharp
int id = 1;

// Exclua o item de estoque do contexto.
var stockItem = context.StockItems.SingleOrDefault(s => s.Id == id);
context.StockItems.Remove(stockItem);

// Salve as alterações no banco de dados.
context.SaveChanges();
```

- Atualizar um item de estoque existente:

```csharp
int id = 1;
string name = "Novo Nome";
int quantity = 5;
decimal unitPrice = 7.99;

// Atualize o item de estoque no contexto.
var stockItem = context.StockItems.SingleOrDefault(s => s.Id == id);
stockItem.Name = name;
stockItem.Quantity = quantity;
stockItem.UnitPrice = unitPrice;

// Salve as alterações no banco de dados.
context.SaveChanges();
```

Certifique-se de substituir os valores de exemplo pelos dados corretos do item de estoque que você deseja adicionar, atualizar ou excluir.

Lembre-se de fechar o contexto após cada operação e limpar o formulário, se necessário.


## Licença

Este projeto está licenciado sob a [Licença MIT](LICENSE).
